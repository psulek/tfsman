using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;


using TFSManager.Core;
using TFSManager.Core.WinForms;
using TFSManager.Forms;

using UrielGuy.SyntaxHighlightingTextBox;

namespace TFSManager.Controls
{
    public partial class ControlWorkItems : UserControl, IControlWorkItems
    {
        private const string field_BuildIn = "Microsoft.VSTS.Build.FoundIn";
        private const string field_IntegrationBuild = "Microsoft.VSTS.Build.IntegrationBuild";

        private readonly List<int> backup_Selected = new List<int>();
        internal readonly List<string> selectedProjects = new List<string>();
        private readonly ListViewSortInfo sortInfo = new ListViewSortInfo(0, SortOrder.Descending);
        private bool blockSelectedChange = false;
        private List<WorkItem> cachedWorkItems;
        private int lastSelectedQuery = -1;
        private int lastSelectedTeamProject = -1;
        //private FormMain mainForm;
        internal int selectedTeamProjectIndex;
        private Dictionary<string, StoredQueryCollection> sortedProjects;

        private string lastQueryTeamProject = null;
        private string lastQueryText = null;
        private bool sqlEditorInitialized = false;

        DisplayFieldList displayFields;

        private int COLUMN_FOUNDIN = -1;
        private int COLUMN_INTEGRATIONBUILD = -1;

        private List<string> defaultFields = new List<string>
        {
            "System.Id",
            "System.WorkItemType",
            "System.Title",
            "System.ChangedDate",
            "System.TeamProject"
        };


        public ControlWorkItems()
        {
            InitializeComponent();
        }

        internal void Initialize()
        {
            InitSqlEditor();

            //this.mainForm = mainForm;
            this.cmbTeamProjects.Items.Clear();
            Enabled = Context.IsConnected;
            if (!Context.IsConnected)
            {
                return;
            }

            this.cmbTeamProjects.Items.Add("All projects");

            ProjectCollection projects = Context.ItemStore.Projects;
            this.sortedProjects = new Dictionary<string, StoredQueryCollection>();
            var tempProjects = new List<Project>();
            foreach (Project project in projects)
            {
                tempProjects.Add(project);
            }
            tempProjects.Sort((x, y) =>
            {
                return string.Compare(x.Name, y.Name);
            });

            tempProjects.ForEach(project => this.sortedProjects.Add(project.Name, project.StoredQueries));

            foreach (var project in this.sortedProjects)
            {
                this.cmbTeamProjects.Items.Add(project.Key);
            }

            this.blockSelectedChange = true;
            try
            {
                this.cmbTeamProjects.SelectedIndex = 0;
            }
            finally
            {
                this.blockSelectedChange = false;
            }
        }

        private void InitSqlEditor()
        {
            if (sqlEditorInitialized) return;

            //Some seperators
            sqlEditor.Seperators.Add(' ');
            sqlEditor.Seperators.Add('\r');
            sqlEditor.Seperators.Add('\n');
            sqlEditor.Seperators.Add(',');
            sqlEditor.Seperators.Add('.');
            sqlEditor.Seperators.Add(')');
            sqlEditor.Seperators.Add('(');
//            sqlEditor.Seperators.Add(']');
//            sqlEditor.Seperators.Add('[');
            sqlEditor.Seperators.Add('}');
            sqlEditor.Seperators.Add('{');
            sqlEditor.Seperators.Add('+');
            sqlEditor.Seperators.Add('=');
            sqlEditor.Seperators.Add('\t');
            //these seperators screw up highlighting of comments
            // sqlEditor.Seperators.Add('/');
            //sqlEditor.Seperators.Add('-');
            sqlEditor.AddHighlightDescriptor(DescriptorRecognition.StartsWith, "/*", DescriptorType.ToCloseToken, "*/", Color.Green, null, false);
            //comments, note these could be relaced with a RegEx like: "--.*$";
            sqlEditor.AddHighlightDescriptor(DescriptorRecognition.StartsWith, "--", DescriptorType.ToEOL, Color.Green, null, false);

            sqlEditor.AddHighlightDescriptor(DescriptorRecognition.StartsWith, "[", DescriptorType.ToCloseToken, "]", Color.DarkMagenta, null, false);


//            sqlEditor.WordWrap = false;
//            sqlEditor.ScrollBars = RichTextBoxScrollBars.Both;// & RichTextBoxScrollBars.ForcedVertical;            
            XmlDocument doc = new XmlDocument();
            string sqlReservedWords = Util.ExtractResourceFile("TFSManager.SQLReservedWords.xml");
            doc.LoadXml(sqlReservedWords);
            XmlNodeList NodeList = doc.SelectSingleNode("SQLReservedWords").ChildNodes;

            Font tmp = new Font(sqlEditor.Font, FontStyle.Bold /*| FontStyle.Italic*/);
            //SQL Keywords
            foreach (XmlNode n in NodeList)
                sqlEditor.AddHighlightDescriptor(DescriptorRecognition.WholeWord, n.Name, DescriptorType.Word, Color.Blue, tmp, true);


            //text between after a ", or untill another " is found.
            //strings
            sqlEditor.AddHighlightDescriptor(DescriptorRecognition.StartsWith, "\"", DescriptorType.ToCloseToken, "\"", Color.Red, null, true);
            sqlEditor.AddHighlightDescriptor(DescriptorRecognition.StartsWith, "\'", DescriptorType.ToCloseToken, "\'", Color.Red, null, true);
            
            //New feature ToEndOfWord
            tmp = new Font(sqlEditor.Font, FontStyle.Underline);
            sqlEditor.AddHighlightDescriptor(DescriptorRecognition.StartsWith, "@", DescriptorType.ToEOW, Color.Firebrick, tmp, true);

            //RegEx to do the same exact thing... almost. Only highlights is a closing " is found. 
            //also allows for escaping the ", which DescriptorType.ToCloseToken does not do.
            string regBase = "b[^ex]*(?:x.[^ex]*)*[e]";
            string sEx = regBase.Replace("e", "\\\"").Replace("b", "\\\"").Replace("x", "\\\\");
            sqlEditor.AddHighlightDescriptor(DescriptorRecognition.RegEx, sEx, DescriptorType.Word, Color.Red, tmp, false);
            tmp = new Font(sqlEditor.Font, FontStyle.Bold);
            //highlight numbers, 
            sqlEditor.AddHighlightDescriptor(DescriptorRecognition.RegEx, "\\b(?:[0-9]*\\.)?[0-9]+\\b", DescriptorType.Word, Color.Magenta, tmp, false);

            sqlEditorInitialized = true;
        }

        private void lvWI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mniBuildAssign_Click(sender, e);
        }

        private void LocateIn_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var action = menuItem.OwnerItem.Tag as string;

            bool globalList = action == "0";
            LocateIn(sender, globalList);
        }

        private void mniBuildAssign_Click(object sender, EventArgs e)
        {
            int selCount = this.lvWI.SelectedItems.Count;
            if (selCount == 0)
            {
                return;
            }

            string foundIn = null;
            string integrationBuild = null;
            //List<int> savedWI_IDs = new List<int>();
            bool contains_BuildIn = false;
            bool contains_IntegrationBuild = false;
            string teamProject;
            var workItems = new List<WorkItem>();
            bool multiSelect;

            if (selCount == 1)
            {
                ListViewItem viewItem = this.lvWI.SelectedItems[0];
                var workItem = this.lvWI.SelectedItems[0].Tag as WorkItem;
                workItems.Add(workItem);

                foundIn = COLUMN_FOUNDIN > -1 ? viewItem.SubItems[COLUMN_FOUNDIN].Text : null;
                integrationBuild = COLUMN_INTEGRATIONBUILD > -1 ? viewItem.SubItems[COLUMN_INTEGRATIONBUILD].Text : null;

                contains_BuildIn = workItem.Type.FieldDefinitions.Contains(field_BuildIn);
                contains_IntegrationBuild = workItem.Type.FieldDefinitions.Contains(field_IntegrationBuild);
                teamProject = workItem.Project.Name;
                multiSelect = false;
            }
            else
            {
                teamProject = (this.lvWI.SelectedItems[0].Tag as WorkItem).Project.Name;
                multiSelect = true;

                foreach (ListViewItem viewItem in this.lvWI.SelectedItems)
                {
                    var workItem = viewItem.Tag as WorkItem;
                    //savedWI_IDs.Add(workItem.Id);
                    workItems.Add(workItem);
                }
            }

            string selectedBuild1;
            string selectedBuild2;

            bool result = FormBuildAssign.DialogShow(teamProject, contains_BuildIn, foundIn,
                contains_IntegrationBuild, integrationBuild, multiSelect, out selectedBuild1, out selectedBuild2);

            if (result && (!string.IsNullOrEmpty(selectedBuild1) || !string.IsNullOrEmpty(selectedBuild2)))
            {
                try
                {
                    foreach (WorkItem workItem in workItems)
                    {
                        workItem.Open();

                        var old_foundIn = workItem.Fields[field_BuildIn].Value as string;
                        var old_integrationBuild = workItem.Fields[field_IntegrationBuild].Value as string;

                        bool change_BuildIn = !string.IsNullOrEmpty(selectedBuild1) && (selectedBuild1 != foundIn);
                        bool change_IntegrationBuild = !string.IsNullOrEmpty(selectedBuild2)
                            && (selectedBuild2 != integrationBuild);

                        workItem.History =
                            string.Format(
                                "Assigned team build(s) association to this work item (BuildIn to: '{0}', IntegrationBuild to: '{1}')",
                                change_BuildIn ? selectedBuild1 : "-no change-",
                                change_IntegrationBuild ? selectedBuild2 : "-no change-"
                                );

                        bool cleared_FoundIn = false;
                        bool cleared_IntegrationBuild = false;

                        if (change_BuildIn)
                        {
                            workItem.Fields[field_BuildIn].Value = selectedBuild1;
                            cleared_FoundIn = selectedBuild1 == Context.BUILD_NONE;
                        }
                        if (change_IntegrationBuild)
                        {
                            workItem.Fields[field_IntegrationBuild].Value = selectedBuild2;
                            cleared_IntegrationBuild = selectedBuild2 == Context.BUILD_NONE;
                        }

                        workItem.Save();

                        if (change_BuildIn)
                        {
                            string buildNumber = cleared_FoundIn ? old_foundIn : selectedBuild1;
                            ChangeBuildAssigment(teamProject, workItem, buildNumber, cleared_FoundIn);
                        }

                        if (change_IntegrationBuild)
                        {
                            string buildNumber = cleared_IntegrationBuild ? old_integrationBuild : selectedBuild2;
                            ChangeBuildAssigment(teamProject, workItem, buildNumber, cleared_IntegrationBuild);
                        }
                    }

                    TreeNode selectedNode = UIContext.Instance.GetGlobalListSelectedNode();
                    if (selectedNode != null)
                    {
                        List<int> wi_ids = workItems.ConvertAll(input => input.Id);

                        //FindRelatedWI(selectedNode, wi_ids);
                    }

                    RefreshQuery();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Error saving changes: " + e1.Message);
                }
            }
        }

        private void menuWorkItems_Opening(object sender, CancelEventArgs e)
        {
            this.mniSetBuildAssigment.Enabled = this.lvWI.SelectedItems.Count > 0;
            this.mniRemoveBuildAssigment.Enabled = this.lvWI.SelectedItems.Count > 0;

            if (this.lvWI.SelectedItems.Count == 1)
            {
                ListViewItem viewItem = this.lvWI.SelectedItems[0];
                var workItem = this.lvWI.SelectedItems[0].Tag as WorkItem;

                string foundIn = COLUMN_FOUNDIN > -1 ? viewItem.SubItems[COLUMN_FOUNDIN].Text : null;
                string integrationBuild = COLUMN_INTEGRATIONBUILD > -1
                    ? viewItem.SubItems[COLUMN_INTEGRATIONBUILD].Text : null;

                bool contains_BuildIn = workItem.Type.FieldDefinitions.Contains(field_BuildIn);
                bool contains_IntegrationBuild = workItem.Type.FieldDefinitions.Contains(field_IntegrationBuild);

                bool enabledFoundIn = contains_BuildIn
                    && (!String.IsNullOrEmpty(foundIn) && foundIn != Context.BUILD_NONE);
                bool enabledIntegrationBuild = contains_IntegrationBuild
                    && (!string.IsNullOrEmpty(integrationBuild) && integrationBuild != Context.BUILD_NONE);

                this.mniGL_FoundIn.Enabled = enabledFoundIn;
                this.mniGL_IntegrationBuild.Enabled = enabledIntegrationBuild;

                this.mniTB_FoundIn.Enabled = enabledFoundIn;
                this.mniTB_IntegrationBuild.Enabled = enabledIntegrationBuild;
            }
            else
            {
                this.mniGL_FoundIn.Enabled = false;
                this.mniGL_IntegrationBuild.Enabled = false;
                this.mniTB_FoundIn.Enabled = false;
                this.mniTB_IntegrationBuild.Enabled = false;
            }
        }

        private void LocateIn(object sender, bool globalList)
        {
            var menuItem = sender as ToolStripMenuItem;
            var action = menuItem.Tag as string;

            if (this.lvWI.SelectedItems.Count != 1)
            {
                return;
            }
            ListViewItem viewItem = this.lvWI.SelectedItems[0];
            var workItem = this.lvWI.SelectedItems[0].Tag as WorkItem;

            string foundIn = COLUMN_FOUNDIN > -1 ? viewItem.SubItems[COLUMN_FOUNDIN].Text : null;
            string integrationBuild = COLUMN_INTEGRATIONBUILD > -1
                ? viewItem.SubItems[COLUMN_INTEGRATIONBUILD].Text : null;
            
            bool contains_BuildIn = workItem.Type.FieldDefinitions.Contains(field_BuildIn);
            bool contains_IntegrationBuild = workItem.Type.FieldDefinitions.Contains(field_IntegrationBuild);

            string foundValue = null;
            if (action == "0" && contains_BuildIn)
            {
                foundValue = foundIn;
            }
            else if (action == "1" && contains_IntegrationBuild)
            {
                foundValue = integrationBuild;
            }

            if (foundValue != null)
            {
                if (globalList)
                {
                    XmlNode buildNode =
                        Context.GlobalLists.DocumentElement.SelectSingleNode(string.Format("//LISTITEM[@value='{0}']",
                            foundValue));

                    if (buildNode != null)
                    {
                        TreeNode node = UIContext.Instance.FindNode(UIContext.Instance.GlobalListTree, buildNode);
                        if (node != null)
                        {
                            UIContext.Instance.SetGlobalListSelectedNode(node);
                            node.EnsureVisible();
                            UIContext.Instance.SetMainTabPage(FormMain.TABIDX_GLOBALLIST);
                        }
                    }
                }
                else
                {
                    IControlTeamBuilds controlTeamBuilds = UIContext.Instance.ControlTeamBuilds;
                    //var control = this.mainForm.tabTeamBuilds.Controls[0] as ControlTeamBuilds;
                    var teamProject = workItem.Fields[CoreField.TeamProject].Value as string;
                    controlTeamBuilds.FocusAndSelectTeamBuild(teamProject, foundValue);

                    UIContext.Instance.SetMainTabPage(FormMain.TABIDX_TEAMBUILDS);
                }
            }
        }

        private void ChangeBuildAssigment(string teamProject, WorkItem workItem, string buildNumber, bool removeAction)
        {
            IBuildDetail buildDetail = Context.GetBuild(teamProject, buildNumber);
            if (buildDetail == null)
            {
                return;
            }
            try
            {
                List<IBuildInformationNode> nodes = buildDetail.Information.GetNodesByType("AssociatedWorkItem");
                IBuildInformationNode associatedWI_Node = nodes.Find(node =>
                {
                    return node.Fields["WorkItemUri"] == workItem.Uri.ToString();
                });

                if (removeAction)
                {
                    if (associatedWI_Node != null)
                    {
                        associatedWI_Node.Delete();
                    }
                }
                else
                {
                    if (associatedWI_Node == null)
                    {
                        IBuildInformationNode node = buildDetail.Information.CreateNode();
                        node.Type = "AssociatedWorkItem";
                        node.Fields[CoreField.Title.ToString()] = workItem.Title;
                        node.Fields[CoreField.AssignedTo.ToString()] =
                            workItem.Fields[CoreField.AssignedTo].Value as string;
                        node.Fields["WorkItemUri"] = workItem.Uri.ToString();
                        node.Fields["Status"] = workItem.State;
                        node.Fields["WorkItemId"] = workItem.Id.ToString();
                        node.Save();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    string.Format("Changing build assigment for workitem id: {0} ('{1}') failed, message: {2}",
                        workItem.Id, workItem.Title, e.Message), "Change build assigment", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void removeBuildAssignedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lvWI.SelectedItems.Count == 0)
            {
                return;
            }

            if (
                MessageBox.Show("Do you really want to remove build assigment from work item(s) ?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        == DialogResult.No)
            {
                return;
            }

            try
            {
                foreach (ListViewItem viewItem in this.lvWI.SelectedItems)
                {
                    var workItem = viewItem.Tag as WorkItem;
                    bool contains_BuildIn = workItem.Fields.Contains(field_BuildIn);
                    bool contains_IntegrationBuild = workItem.Fields.Contains(field_IntegrationBuild);

                    if (!contains_BuildIn && !contains_IntegrationBuild)
                    {
                        continue;
                    }

                    try
                    {
                        workItem.Open();

                        string foundIn = string.Empty;
                        string integrationBuild = string.Empty;

                        if (contains_BuildIn)
                        {
                            foundIn = workItem.Fields[field_BuildIn].Value as string;
                        }

                        if (contains_IntegrationBuild)
                        {
                            integrationBuild = workItem.Fields[field_IntegrationBuild].Value as string;
                        }

                        workItem.History =
                            string.Format(
                                "Removed team build(s) association(s) from this work item (Found in: '{0}', Integration build: '{1}')",
                                foundIn, integrationBuild);

                        var teamProject = workItem.Fields[CoreField.TeamProject].Value as string;

                        if (contains_BuildIn)
                        {
                            workItem.Fields[field_BuildIn].Value = Context.BUILD_NONE;
                        }

                        if (contains_IntegrationBuild)
                        {
                            workItem.Fields[field_IntegrationBuild].Value = Context.BUILD_NONE;
                        }

                        workItem.Save();

                        if (contains_BuildIn)
                        {
                            ChangeBuildAssigment(teamProject, workItem, foundIn, true);
                        }

                        if (contains_IntegrationBuild)
                        {
                            ChangeBuildAssigment(teamProject, workItem, integrationBuild, true);
                        }

                        RefreshQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving work item changes: " + ex.Message);
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error saving changes: " + e1.Message);
            }
        }

        private void PopulateQueries()
        {
            this.cmbQueries.Items.Clear();
            this.cmbQueries.Items.Add(string.Empty);

            if (this.selectedProjects.Count == 1)
            {
                string teamProject = this.selectedProjects[0];
                StoredQueryCollection queries = this.sortedProjects[teamProject];
                foreach (StoredQuery query in queries)
                {
                    this.cmbQueries.Items.Add(query.Name);
                }
            }

            this.cmbQueries.SelectedIndex = 0;
        }

        internal void PopulateWI(bool resort)
        {
            PopulateWI(resort, null);
        }

        internal void PopulateWI(bool resort, HighlightFilter highlightings)
        {
            this.lvWI.BeginUpdate();
            try
            {
                BackupSelectedItems();

                if (resort)
                {
                    SortListData();
                }

                this.lvWI.Items.Clear();
                List<ColumnHeader> columnsToRemove = new List<ColumnHeader>();
                foreach (ColumnHeader column in lvWI.Columns)
                {
                    //string tag = column.Tag as string;
                    //bool canRemove = tag != "0";
                    bool canRemove = (column.Name == field_BuildIn || column.Name == field_IntegrationBuild);
                    if (canRemove)
                    {
                        columnsToRemove.Add(column);
                    }
                }
                columnsToRemove.ForEach(columnHeader => lvWI.Columns.Remove(columnHeader));

                COLUMN_FOUNDIN = -1;
                COLUMN_INTEGRATIONBUILD = -1;

                if (this.cachedWorkItems != null)
                {
                    foreach (FieldDefinition fieldDef in displayFields)
                    {
                        if (defaultFields.Contains(fieldDef.ReferenceName))
                        {
                            continue;
                        }

                        ColumnHeader columnHeader = this.lvWI.Columns.Add(fieldDef.Name);
                        columnHeader.Tag = "0";//fieldDef.ReferenceName;
                        columnHeader.Name = fieldDef.ReferenceName;

                        if (fieldDef.ReferenceName == field_BuildIn)
                        {
                            COLUMN_FOUNDIN = lvWI.Columns.Count - 1;
                        }
                        else if (fieldDef.ReferenceName == field_IntegrationBuild)
                        {
                            COLUMN_INTEGRATIONBUILD = lvWI.Columns.Count - 1;
                        }
                    }

                    string[] columnsTemp = new string[this.lvWI.Columns.Count];
                    int idx = 0;
                    foreach (ColumnHeader column in this.lvWI.Columns)
                    {
                        columnsTemp[idx++] = column.Text;
                    }

                    foreach (WorkItem workItem in this.cachedWorkItems)
                    {
                        ListViewItem viewItem = this.lvWI.Items.Add(workItem.Id.ToString());
                        viewItem.UseItemStyleForSubItems = false;
                        viewItem.Tag = workItem;
                        viewItem.SubItems.Add(workItem.Type.Name);
                        viewItem.SubItems.Add(workItem.Title);
                        viewItem.SubItems.Add(workItem.ChangedDate.ToString());
                        bool alreadyhightlighted = false;

                        foreach (FieldDefinition fieldDef in displayFields)
                        {
                            string workItemFieldContent = null;
                            if (defaultFields.Contains(fieldDef.ReferenceName) ||
                                !workItem.Fields.Contains(fieldDef.ReferenceName))
                            {
                                if (fieldDef.ReferenceName == field_BuildIn ||
                                    fieldDef.ReferenceName == field_IntegrationBuild)
                                {
                                    workItemFieldContent = string.Empty;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (workItemFieldContent == null)
                            {
                                workItemFieldContent = workItem[fieldDef.ReferenceName].ToString();
                            }

                            ListViewItem.ListViewSubItem subItem = viewItem.SubItems.Add(workItemFieldContent);

                            if (highlightings != null && highlightings.ContainsKey(fieldDef.ReferenceName))
                            {
                                HighlightCondition condition = highlightings[fieldDef.ReferenceName];
                                if (Util.StrEqual(subItem.Text, condition.Value, true))
                                {
                                    subItem.ForeColor = condition.ForeColor;

                                    if (!alreadyhightlighted)
                                    {
                                        subItem.BackColor = condition.BackColor;
                                        alreadyhightlighted = true;
                                    }
                                }
                            }
                        }

                        var teamProject = (string) workItem.Fields[CoreField.TeamProject].Value;
                        viewItem.Group = this.lvWI.Groups[teamProject];
                    }
                }
            }
            finally
            {
                this.lvWI.EndUpdate();
                RestoreSelectedItems();
            }
        }

        public void FindRelatedWorkItems(string teamProject, string query, HighlightFilter highlightings)
        {
            FindRelatedWorkItems(teamProject, query, new List<int>(), highlightings);
        }

        private void FindRelatedWorkItems(string teamProject, string query, List<int> focusByWI_IDs,
            HighlightFilter highlightings)
        {
            QueryItems(teamProject, query, focusByWI_IDs, highlightings);

            blockSelectedChange = true;
            try
            {
                this.cmbTeamProjects.Text = teamProject;
                PopulateQueries();
            }
            finally
            {
                blockSelectedChange = false;
            }
            SynchroTeamProjectText(null, EventArgs.Empty);
        }


        #region old OK

        //        internal void FindRelatedWI(TreeNode node)
        //        {
        //            FindRelatedWI(node, new List<int>());
        //        }
        //
        //        private void FindRelatedWI(TreeNode node, List<int> focusByWI_IDs)
        //        {
        //            string inCondition;
        //            TreeNode teamProjectNode;
        //            if (node.Tag == "Server")
        //            {
        //                if (node.Nodes.Count == 0)
        //                {
        //                    return;
        //                }
        //
        //                teamProjectNode = node;
        //
        //                inCondition = BuildINCondition(node);
        //            }
        //            else
        //            {
        //                inCondition = string.Format("'{0}'", node.Text);
        //                teamProjectNode = node.Parent;
        //            }
        //
        //            if (teamProjectNode == null)
        //            {
        //                return;
        //            }
        //
        //            string teamProject = GetTeamProjectName(teamProjectNode);
        //
        //            string query = string.Format(
        //                @"SELECT [System.Id], [System.Title], [System.TeamProject], [Microsoft.VSTS.Build.FoundIn], [Microsoft.VSTS.Build.IntegrationBuild] FROM WorkItems 
        //WHERE ([Microsoft.VSTS.Build.FoundIn] IN ({0}) OR [Microsoft.VSTS.Build.IntegrationBuild] IN ({0})) AND [System.TeamProject] = '{1}'
        //ORDER BY [System.TeamProject] ASC, [System.Id] DESC",
        //                inCondition, teamProject);
        //            QueryItems(teamProject, query, focusByWI_IDs);
        //
        //            this.cmbTeamProjects.Text = teamProject;
        //            SynchroTeamProjectText(null, EventArgs.Empty);
        //        }

        #endregion

        private void QueryItems(string teamProject, string query)
        {
            QueryItems(teamProject, query, new List<int>(), null);
        }

        private void QueryItems(string teamProject, string query, List<int> workItemIds,
            HighlightFilter highlightings)
        {
            if (UIContext.Instance.GetMainTabPage() != FormMain.TABIDX_WORKITEMS)
            {
                UIContext.Instance.SetMainTabPage(FormMain.TABIDX_WORKITEMS);
            }

            query = query.Replace("@PROJECT", "@project");

            var context = new Hashtable();
            context.Add("project", teamProject);
            WorkItemCollection items = null;
            try
            {
                items = Context.ItemStore.Query(query, context);
            }
            catch (Exception e)
            {
                MessageBox.Show("Validating query failed, reason: \n\r" + e.Message, "Validating query", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (items != null)
            {
                displayFields = items.DisplayFields;
                sqlEditor.Text = query;
                lastQueryText = query;
                lastQueryTeamProject = teamProject;

                this.cachedWorkItems = new List<WorkItem>();
                this.lvWI.Groups.Clear();
                var teamProjects = new List<string>();
                foreach (WorkItem workItem in items)
                {
                    this.cachedWorkItems.Add(workItem);

                    teamProject = (string) workItem.Fields[CoreField.TeamProject].Value;
                    if (!teamProjects.Contains(teamProject))
                    {
                        teamProjects.Add(teamProject);
                    }
                }

                teamProjects.Sort((x, y) =>
                {
                    return string.Compare(x, y);
                });
                teamProjects.ForEach(project => this.lvWI.Groups.Add(project, project));

                PopulateWI(true, highlightings);
                SelectWorkItems(workItemIds);
            }
        }

        private void lvWI_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView.ColumnHeaderCollection columns = this.lvWI.Columns;
            ColumnHeader column = columns[e.Column];

            object sd = column.Tag;
            SortOrder sortOrder;
            if (sd == null)
            {
                sortOrder = SortOrder.Ascending;
            }
            else
            {
                sortOrder = (SortOrder) Convert.ToInt32(sd as string);
                if (sortOrder == SortOrder.Ascending)
                {
                    sortOrder = SortOrder.Descending;
                }
                else
                {
                    sortOrder = SortOrder.Ascending;
                }
            }

            if (this.sortInfo.Index > -1)
            {
                columns[this.sortInfo.Index].ImageIndex = -1;
            }

            column.Tag = Convert.ToInt32(sortOrder).ToString();
            column.ImageIndex = sortOrder == SortOrder.Ascending ? 0 : 1;
            this.sortInfo.Index = e.Column;
            this.sortInfo.Order = sortOrder;

            SortListData();
            PopulateWI(false);
        }

        private void SelectWorkItems(List<int> workItemIds)
        {
            ListViewItem topItem = null;

            foreach (ListViewItem viewItem in this.lvWI.Items)
            {
                var workItem = viewItem.Tag as WorkItem;
                ListViewItem item = viewItem;

                if (workItemIds.Contains(workItem.Id))
                {
                    if (topItem == null || item.Position.Y < topItem.Position.Y)
                    {
                        topItem = item;
                    }

                    item.Selected = true;
                }
            }

            if (topItem != null)
            {
                topItem.Focused = true;
                topItem.EnsureVisible();
            }
        }


        private void RestoreSelectedItems()
        {
            this.lvWI.SelectedItems.Clear();
            SelectWorkItems(this.backup_Selected);
        }

        private void BackupSelectedItems()
        {
            this.backup_Selected.Clear();

            foreach (ListViewItem viewItem in this.lvWI.SelectedItems)
            {
                this.backup_Selected.Add((viewItem.Tag as WorkItem).Id);
            }
        }

        private void SortListData()
        {
            if (this.cachedWorkItems == null)
            {
                return;
            }

            this.cachedWorkItems.Sort((x, y) =>
            {
                int compared;

                if (this.sortInfo.Index == 0) // ID
                {
                    compared = x.Id - y.Id;
                }
                else if (this.sortInfo.Index == 1) // Type
                {
                    compared = string.CompareOrdinal(x.Type.Name, y.Type.Name);
                }
                else if (this.sortInfo.Index == 2) // Name
                {
                    compared = string.CompareOrdinal(x.Title, y.Title);
                }
                else if (this.sortInfo.Index == 3) // Found In
                {
                    string x_foundIn = string.Empty;
                    if (x.Fields.Contains(field_BuildIn))
                    {
                        x_foundIn = x[field_BuildIn].ToString();
                    }

                    string y_foundIn = string.Empty;
                    if (y.Fields.Contains(field_BuildIn))
                    {
                        y_foundIn = y[field_BuildIn].ToString();
                    }

                    compared = string.CompareOrdinal(x_foundIn, y_foundIn);
                }
                else if (this.sortInfo.Index == 4) // Integration Build
                {
                    string x_IntegrationBuild = string.Empty;
                    if (x.Fields.Contains(field_IntegrationBuild))
                    {
                        x_IntegrationBuild = x[field_IntegrationBuild].ToString();
                    }

                    string y_IntegrationBuild = string.Empty;
                    if (y.Fields.Contains(field_IntegrationBuild))
                    {
                        y_IntegrationBuild = y[field_IntegrationBuild].ToString();
                    }

                    compared = string.CompareOrdinal(x_IntegrationBuild, y_IntegrationBuild);
                }
                else // Changed date
                {
                    compared = DateTime.Compare(x.ChangedDate, y.ChangedDate);
                }

                if (this.sortInfo.Order == SortOrder.Descending)
                {
                    compared = compared * -1;
                }

                return compared;
            });
        }

        private void btnWIGo_Click(object sender, EventArgs e)
        {
            int id;
            bool newQuery;
            if (FormGotoWorkItem.DialogShow(out id, out newQuery))
            {
                if (newQuery)
                {
                    string query = string.Format(
                        @"SELECT [System.Id], [System.Title], [System.TeamProject], [Microsoft.VSTS.Build.FoundIn], [Microsoft.VSTS.Build.IntegrationBuild] FROM WorkItems 
WHERE [System.Id] IN ({0})
ORDER BY [System.TeamProject] ASC, [System.Id] DESC",
                        id);
                    QueryItems(string.Empty, query);
                }
                else
                {
                    List<int> workItemIds = new List<int>{id};
                    this.lvWI.SelectedItems.Clear();
                    SelectWorkItems(workItemIds);
                }
            }
        }

        private void SynchroTeamProjectText(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cmbTeamProjects.Text))
            {
                int idx = this.cmbTeamProjects.FindStringExact(this.cmbTeamProjects.Text);
                if (idx > -1)
                {
                    this.cmbTeamProjects.Text = this.cmbTeamProjects.Items[idx] as string;
                }
                else
                {
                    this.cmbTeamProjects.SelectedIndex = this.lastSelectedTeamProject;
                }
            }
        }

        private void SynchroQueryText(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cmbQueries.Text))
            {
                int idx = this.cmbQueries.FindStringExact(this.cmbQueries.Text);
                if (idx > -1)
                {
                    this.cmbQueries.Text = this.cmbQueries.Items[idx] as string;
                }
                else
                {
                    this.cmbQueries.SelectedIndex = this.lastSelectedQuery;
                }
            }
        }


        private void cmbTeamProjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SynchroTeamProjectText(sender, e);
            }
        }

        private void cmbTeamProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedProjects.Clear();

            this.selectedTeamProjectIndex = this.cmbTeamProjects.SelectedIndex;

            if (this.cmbTeamProjects.SelectedIndex == 0)
            {
                for (int i = 1; i < this.cmbTeamProjects.Items.Count; i++)
                {
                    this.selectedProjects.Add(this.cmbTeamProjects.Items[i] as string);
                }

                this.selectedProjects.Sort((x, y) => string.CompareOrdinal(x, y));
            }
            else
            {
                this.selectedProjects.Add(this.cmbTeamProjects.SelectedItem as string);
            }

            this.lastSelectedTeamProject = this.cmbTeamProjects.SelectedIndex;

            if (this.blockSelectedChange)
            {
                return;
            }

            PopulateWI(true);
            PopulateQueries();
        }

        private void cmbQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedProjects.Count == 1 && this.cmbQueries.SelectedIndex > 0)
            {
                string teamProject = this.selectedProjects[0];

                StoredQuery query = this.sortedProjects[teamProject][this.cmbQueries.SelectedIndex - 1];
                //StoredQuery query2 = query.Project.Store.GetStoredQuery(query.QueryGuid);
                QueryItems(query.Project.Name, query.QueryText);

                this.lastSelectedQuery = this.cmbQueries.SelectedIndex;
            }
        }

        private void cmbQueries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SynchroQueryText(sender, e);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.ofd.ShowDialog() == DialogResult.OK)
            {
                var document = new XmlDocument();
                document.Load(this.ofd.FileName);

                XmlNode teamProjectNode = document.SelectSingleNode("//TeamProject");
                XmlNode wiqlNode = document.SelectSingleNode("//Wiql");
                if (teamProjectNode != null && wiqlNode != null)
                {
                    string teamProject = teamProjectNode.InnerText;
                    this.blockSelectedChange = true;
                    try
                    {
                        int itemIndex = this.cmbTeamProjects.FindStringExact(teamProject);
                        this.cmbTeamProjects.SelectedIndex = itemIndex == -1 ? 0 : itemIndex;
                        PopulateQueries();
                    }
                    finally
                    {
                        this.blockSelectedChange = false;
                    }

                    this.cmbQueries.SelectedIndex = -1;

                    QueryItems(teamProject, wiqlNode.InnerText);
                }
            }
        }

        private void cmbQueries_Click(object sender, EventArgs e)
        {
//            string selectedQueryName = this.cmbQueries.SelectedItem as string;
//            if (string.IsNullOrEmpty(selectedQueryName)) return;
//
//            string teamProject = cmbTeamProjects.SelectedItem as string;
//            StoredQueryCollection queries = this.sortedProjects[teamProject];
//            StoredQuery foundQuery = null;
//            foreach (StoredQuery query in queries)
//            {
//                if (query.Name == selectedQueryName)
//                {
//                    foundQuery = query;
//                    break;
//                }
//            }
//
//            if (foundQuery != null)
//            {
//                QueryItems(teamProject, foundQuery.QueryText);
//            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshQuery();
        }

        private void RefreshQuery()
        {
            string teamProject;
            string query;
            RequestInfo(out teamProject, out query);

            QueryItems(teamProject, query);
        }

        private void RequestInfo(out string teamProject, out string query) 
        {
            teamProject = this.lastQueryTeamProject;
            query = this.lastQueryText;

            if (this.selectedProjects.Count > 0)
            {
                if (!Util.StrEqual(teamProject, this.selectedProjects[0], true))
                {
                    teamProject = this.selectedProjects[0];
                }
            }

            if (!string.IsNullOrEmpty(this.sqlEditor.Text) && !Util.StrEqual(query, this.sqlEditor.Text))
            {
                query = this.sqlEditor.Text;
            }
        }

        private void mniRefreshQuery_Click(object sender, EventArgs e)
        {
            RefreshQuery();
        }

        private void btnSaveQuery_Click(object sender, EventArgs e)
        {
            string teamProject;
            string query;
            RequestInfo(out teamProject, out query);

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                XmlTextWriter xml = new XmlTextWriter(sfd.FileName, Encoding.UTF8);
                xml.WriteStartElement("WorkItemQuery");
                xml.WriteAttributeString("Version", "1");
                xml.WriteElementString("TeamFoundationServer", Context.TfsServer.Uri.ToString());
                xml.WriteElementString("TeamProject", teamProject);
                xml.WriteElementString("Wiql", query);
                xml.WriteEndElement();
                xml.Flush();
                xml.Close();

                if (File.Exists(sfd.FileName))
                {
                    MessageBox.Show("Team query was successfully save to file: " + sfd.FileName,
                        "Save team query to file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error while saving team query to file.",
                        "Save team query to file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving team query to file. \n\rError: " + ex.Message,
                    "Save team query to file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}