using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

using TFSManager.Core;
using TFSManager.Core.WinForms;
using TFSManager.Forms;
using System.Linq;
using System.Linq.Expressions;

namespace TFSManager.Controls
{
    public partial class ControlBuildDefinitions: UserControl
    {
        private readonly List<IBuildDefinition> backupDefinitions_Selected = new List<IBuildDefinition>();
        private readonly List<BuildTemplate> backupTemplates_Selected = new List<BuildTemplate>();
        private readonly ListViewSortInfo sortInfoDefinition = new ListViewSortInfo(0, SortOrder.Ascending);
        private readonly ListViewSortInfo sortInfoTemplates = new ListViewSortInfo(1, SortOrder.Ascending);
        private List<IBuildDefinition> cachedDefinitions;
        private string lastAppliedFilterHashCode = string.Empty;
        //internal ControlTeamBuilds parentControl;

        public ControlBuildDefinitions()
        {
            InitializeComponent();
        }

        public void Initialize(/*ControlTeamBuilds parentControl*/)
        {
            //this.parentControl = parentControl;

            if (Context.BuildTemplates == null && !string.IsNullOrEmpty(Config.Instance.BuildTemplatesFileName))
            {
                OpenTemplates(Config.Instance.BuildTemplatesFileName, false);
            }

            UpdateExportButton();
        }

        private void UpdateExportButton()
        {
            this.btnExportTemplates.Text = Context.BuildTemplates == null ? "New Templates" : "Export Templates";
            this.btnExportTemplates.Tag = Context.BuildTemplates == null ? "0" : "1";
        }

        private void lvDefinitions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView.ColumnHeaderCollection columns = this.lvDefinitions.Columns;
            ColumnHeader column = columns[e.Column];

            object sd = column.Tag;
            SortOrder sortOrder;
            if (sd == null)
            {
                sortOrder = SortOrder.Ascending;
            }
            else
            {
                sortOrder = (SortOrder) sd;
                if (sortOrder == SortOrder.Ascending)
                {
                    sortOrder = SortOrder.Descending;
                }
                else
                {
                    sortOrder = SortOrder.Ascending;
                }
            }

            if (this.sortInfoDefinition.Index > -1)
            {
                columns[this.sortInfoDefinition.Index].ImageIndex = -1;
            }

            column.Tag = sortOrder;
            column.ImageIndex = sortOrder == SortOrder.Ascending ? 0 : 1;
            this.sortInfoDefinition.Index = e.Column;
            this.sortInfoDefinition.Order = sortOrder;

            SortDefinitionListData();
            PopulateBuildDefinitions(false, false, false);
        }

        internal void PopulateBuildDefinitions(bool refresh, bool resort, bool alsoTemplates)
        {
            this.lvDefinitions.BeginUpdate();

            BackupSelectedItems(true);

            //if (refresh || this.lastSelectedTeamProjectIndex != this.parentControl.selectedTeamProjectIndex)
            if (refresh || this.lastAppliedFilterHashCode != UIContext.Instance.ControlTeamBuildFilter.LastAppliedFilterHashCode)
            {
                this.cachedDefinitions = null;
            }

            if (this.cachedDefinitions == null)
            {
                this.cachedDefinitions = new List<IBuildDefinition>();
                this.lvDefinitions.Groups.Clear();

                string[] checkedProjects = UIContext.Instance.ControlTeamBuildFilter.CheckedProjects;

                UIContext.Instance.ProgressBegin(checkedProjects.Length, 1);

                try
                {
                    foreach (string teamProject in checkedProjects)
                    {
                        this.cachedDefinitions.AddRange(Context.BuildServer.QueryBuildDefinitions(teamProject));
                        this.lvDefinitions.Groups.Add(teamProject, teamProject);

                        UIContext.Instance.ProgressDoStep();
                    }

                    this.lastAppliedFilterHashCode = UIContext.Instance.ControlTeamBuildFilter.LastAppliedFilterHashCode;
                }
                finally
                {
                    UIContext.Instance.ProgressEnd();
                }
            }

            UIContext.Instance.ProgressBegin(this.cachedDefinitions.Count, 1);

            if (resort)
            {
                SortDefinitionListData();
            }

            this.lvDefinitions.Visible = true;
            try
            {
                this.lvDefinitions.Items.Clear();

                Dictionary<string, IBuildAgentSpec> buildAgentSpec = new Dictionary<string, IBuildAgentSpec>();

                this.cachedDefinitions.ForEach(definition =>
                {
                    ListViewItem viewItem = this.lvDefinitions.Items.Add(definition.Name);
                    viewItem.Tag = definition;
                    viewItem.SubItems.Add(definition.Enabled ? "Yes" : "No");
                    viewItem.SubItems.Add(definition.Schedules.Count.ToString());
                    //viewItem.SubItems.Add(definition.DefaultBuildAgent != null ? definition.DefaultBuildAgent.Name : string.Empty);
                    viewItem.SubItems.Add(string.Empty);
                    viewItem.SubItems.Add(definition.Uri.ToString());
                    viewItem.Group = this.lvDefinitions.Groups[definition.TeamProject];

//                    if (!buildAgentSpec.ContainsKey(definition.TeamProject))
//                    {
//                        buildAgentSpec.Add(definition.TeamProject, Context.BuildServer.CreateBuildAgentSpec(definition.TeamProject));
//                    }

                    UIContext.Instance.ProgressDoStep();
                });


                this.mniChangeDefaultAgent.DropDownItems.Clear();
                this.mniChangeDefaultAgentTemplate.DropDownItems.Clear();

                if (buildAgentSpec.Count > 0)
                {
                    var buildAgents = Context.BuildServer.QueryBuildAgents(buildAgentSpec.Values.ToArray());

                    var distinctComparer = new CommonEqualityComparer<IBuildAgent, string>(buildAgent => buildAgent.Name);

                    var agents = buildAgents.SelectMany(result => result.Agents).Distinct(distinctComparer);

                    foreach (IBuildAgent buildAgent in agents)
                    {
                        ToolStripItem toolStripItem = this.mniChangeDefaultAgent.DropDownItems.Add(buildAgent.Name);
                        toolStripItem.Click += ChangeDefaultAgent_OnClick;
                        toolStripItem.Tag = buildAgent;

                        ToolStripItem stripItem = this.mniChangeDefaultAgentTemplate.DropDownItems.Add(buildAgent.Name);
                        stripItem.Click += ChangeDefaultAgentTemplate_OnClick;
                        stripItem.Tag = buildAgent;
                    }
                }
            }
            finally
            {
                this.lvDefinitions.EndUpdate();
                RestoreSelectedItems(true);
                UIContext.Instance.ProgressEnd();
            }

            if (alsoTemplates)
            {
                PopulateBuildTemplates(resort);
            }
        }

        private void ChangeDefaultAgentTemplate_OnClick(object sender, EventArgs e)
        {
            if (lvBuildTemplates.SelectedIndices.Count == 0)
            {
                return;
            }

            ToolStripItem toolStripItem = (sender as ToolStripItem);
            IBuildAgent buildAgent = toolStripItem.Tag as IBuildAgent;

            var buildTemplates = this.lvBuildTemplates.SelectedItems.ToCollection(o => (o as ListViewItem).Tag as BuildTemplate);

            MakeMultipleChangesOnBuildTemplates(buildTemplates, true,
                delegate(BuildTemplate buildTemplate)
                    {
                        buildTemplate.BuildControllerName = buildAgent.Name;
                        buildTemplate.BuildControllerUri = buildAgent.Uri.ToString();
                    });

//            foreach (ListViewItem viewItem in this.lvBuildTemplates.SelectedItems)
//            {
//                BuildTemplate buildTemplate = viewItem.Tag as BuildTemplate;
//                int index = Context.BuildTemplates.Templates.FindIndex(template => template == buildTemplate);
//                
//                if (Context.BuildTemplates.Templates[index].Timestamp == 0)
//                {
//                    buildTemplate.Timestamp = DateTime.Now.Ticks;
//                }
//                else
//                {
//                    buildTemplate.Timestamp = Context.BuildTemplates.Templates[index].Timestamp;
//                }
//
//                buildTemplate.BuildAgentName = buildAgent.Name;
//                buildTemplate.BuildAgentUri = buildAgent.Uri.ToString();
//
//                Context.BuildTemplates.Templates[index] = buildTemplate;
//            }
//
//            Context.BuildTemplates.SaveToFile(Context.BuildTemplates.Filename);
//            PopulateBuildTemplates(true);
        }

        private void MakeMultipleChangesOnBuildTemplates(IEnumerable<BuildTemplate> buildTemplates, 
            bool refreshGridOnEnd, Action<BuildTemplate> changeDataAction)
        {
            foreach (BuildTemplate buildTemplate in buildTemplates)
            {
                int index = Context.BuildTemplates.Templates.FindIndex(template => template == buildTemplate);
                if (Context.BuildTemplates.Templates[index].Timestamp == 0)
                {
                    buildTemplate.Timestamp = DateTime.Now.Ticks;
                }
                else
                {
                    buildTemplate.Timestamp = Context.BuildTemplates.Templates[index].Timestamp;
                }

                changeDataAction(buildTemplate);
                Context.BuildTemplates.Templates[index] = buildTemplate;
            }

            Context.BuildTemplates.SaveToFile(Context.BuildTemplates.Filename);

            if (refreshGridOnEnd)
            {
                PopulateBuildTemplates(true);
            }
        }

        private void ChangeDefaultAgent_OnClick(object sender, EventArgs eventArgs)
        {
/*
            if (lvDefinitions.SelectedIndices.Count == 0)
            {
                return;
            }

            ToolStripItem toolStripItem = (sender as ToolStripItem);
            IBuildAgent buildAgent = toolStripItem.Tag as IBuildAgent;

            foreach (ListViewItem viewItem in this.lvDefinitions.SelectedItems)
            {
                IBuildDefinition buildDefinition = viewItem.Tag as IBuildDefinition;
                buildDefinition.DefaultBuildAgent = buildAgent;
                buildDefinition.Save();
            }

            PopulateBuildDefinitions(false, true, false);
*/
        }

        private void BackupSelectedItems(bool definitions)
        {
            if (definitions)
            {
                this.backupDefinitions_Selected.Clear();
                foreach (ListViewItem viewItem in this.lvDefinitions.SelectedItems)
                {
                    this.backupDefinitions_Selected.Add(viewItem.Tag as IBuildDefinition);
                }
            }
            else
            {
                this.backupTemplates_Selected.Clear();
                foreach (ListViewItem viewItem in this.lvBuildTemplates.SelectedItems)
                {
                    this.backupTemplates_Selected.Add(viewItem.Tag as BuildTemplate);
                }
            }
        }

        private void RestoreSelectedItems(bool definitions)
        {
            if (definitions)
            {
                this.lvDefinitions.SelectedItems.Clear();
                SelectBuildDefinitions(this.backupDefinitions_Selected);
            }
            else
            {
                this.lvBuildTemplates.SelectedItems.Clear();
                SelectBuildTemplates(this.backupTemplates_Selected);
            }
        }

        private void SelectBuildDefinitions(List<IBuildDefinition> definitions)
        {
            ListViewItem topItem = null;

            foreach (ListViewItem viewItem in this.lvDefinitions.Items)
            {
                var itemDefinition = viewItem.Tag as IBuildDefinition;

                ListViewItem item = viewItem;
                definitions.ForEach(definition =>
                {
                    if (TempBuildDefinition.IsEqual(definition, itemDefinition))
                    {
                        if (topItem == null || item.Position.Y < topItem.Position.Y)
                        {
                            topItem = item;
                        }
                        item.Selected = true;
                        //item.Focused = true;
                    }
                });
            }

            if (topItem != null)
            {
                topItem.Focused = true;
                topItem.EnsureVisible();
            }
        }

        private void SortDefinitionListData()
        {
            this.cachedDefinitions.Sort((x, y) =>
            {
                int compared;

                if (this.sortInfoDefinition.Index == 0) // Name
                {
                    compared = string.CompareOrdinal(x.Name, y.Name);
                }
                else if (this.sortInfoDefinition.Index == 1) // Enabled
                {
                    compared = Convert.ToInt32(x.Enabled) - Convert.ToInt32(y.Enabled);
                }
                else if (this.sortInfoDefinition.Index == 2) // Schedules count
                {
                    compared = (x.Schedules.Count - y.Schedules.Count);
                }
                else if (this.sortInfoDefinition.Index == 3) // Default agent
                {
                    compared = 0; // string.CompareOrdinal(x.DefaultBuildAgent.Name, y.DefaultBuildAgent.Name);
                }
                else // uri
                {
                    compared = string.CompareOrdinal(x.Uri.ToString(), y.Uri.ToString());
                }

                if (this.sortInfoDefinition.Order == SortOrder.Descending)
                {
                    compared = compared * -1;
                }

                return compared;
            });
        }

        private void mniEdit_Click(object sender, EventArgs e)
        {
            var definition = this.lvDefinitions.SelectedItems[0].Tag as IBuildDefinition;
            FormDefinitionEdit.DialogShow(definition, FormActionMode.Edit);
        }

        private void ShowCurrentInfo(bool export)
        {
            MessageBox.Show(
                string.Format("Current list of team build templates is linked from file '{0}'",
                    Context.BuildTemplates.Filename),
                export ? "Export" : "Open" + " team build templates", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkOpenTemplates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private bool OpenTemplates(string fileName)
        {
            return OpenTemplates(fileName, true);
        }

        private bool OpenTemplates(string fileName, bool canShowInfo)
        {
            bool result = File.Exists(fileName);

            if (result)
            {
                BuildTemplateCollection templateCollection = BuildTemplateCollection.LoadFrom(fileName);
                bool openError = (templateCollection == null);

                if (openError)
                {
                    result = false;

                    MessageBox.Show(string.Format("Error opening team build templates from file '{0}'", fileName),
                        "Open team build templates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    result = templateCollection.CheckCurrentTFSServer();

                    if (result)
                    {
                        Context.BuildTemplates = templateCollection;
                        PopulateBuildTemplates(true);
                        Config.Instance.BuildTemplatesFileName = Context.BuildTemplates.Filename;
                        Config.Instance.SaveToFile();

                        lbCurrentTemplate.ToolTipText =
                            string.Format(
                                "Current build templates file: '{0}'. Right click to copy path to clipboard.",
                                Config.Instance.BuildTemplatesFileName);
                        //this.toolTip1.SetToolTip(this.lbCurrentTemplate, string.Format("Current build templates file: '{0}'. Right click to copy path to clipboard.", Config.Instance.BuildTemplatesFileName));
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format(
                                "Error opening team build templates from file '{0}', current tfs server: {1} ({2}) is not equal to file tfs server: {3} ({4})",
                                fileName, Context.TfsServer.Name, Context.TfsServer.InstanceId,
                                templateCollection.TeamFoundationServerName,
                                templateCollection.TeamFoundationServerInstanceId),
                            "Open team build templates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (result)
            {
                result = Context.BuildTemplates != null;
            }

            if (result && canShowInfo)
            {
                ShowCurrentInfo(false);
            }

            return result;
        }

        private void PopulateBuildTemplates(bool resort)
        {
            if (Context.BuildTemplates == null)
            {
                return;
            }

            this.lvBuildTemplates.BeginUpdate();

            BackupSelectedItems(false);

            if (resort)
            {
                SortTemplatesListData();
            }

            this.lvBuildTemplates.Groups.Clear();

            string[] checkedProjects = UIContext.Instance.ControlTeamBuildFilter.CheckedProjects;

            foreach (string teamProject in checkedProjects)
            {
                this.lvBuildTemplates.Groups.Add(teamProject, teamProject);
            }

            this.lvBuildTemplates.Visible = true;
            try
            {
                UIContext.Instance.ProgressBegin(Context.BuildTemplates.Templates.Count, 1);

                this.lvBuildTemplates.Items.Clear();

                List<BuildTemplate> brokenBuildTemplates = new List<BuildTemplate>();

                Context.BuildTemplates.Templates.ForEach(buildTemplate =>
                {
                    //if (this.parentControl.selectedProjects.Contains(buildTemplate.TeamProject))
                    if (UIContext.Instance.ControlTeamBuildFilter.IsCheckedProject(buildTemplate.TeamProject))
                    {
                        bool added = false;

                        try
                        {
                            IBuildController buildController = Context.BuildServer.GetBuildController(new Uri(buildTemplate.BuildControllerUri), false);

                            ListViewItem viewItem = this.lvBuildTemplates.Items.Add(buildTemplate.TemplateName);
                            added = true;
                            viewItem.Tag = buildTemplate;
                            viewItem.SubItems.Add(buildTemplate.DefinitionName);
                            viewItem.SubItems.Add(buildTemplate.BuildControllerName);
                            //viewItem.SubItems.Add(buildController != null ? buildController.MachineName : string.Empty);
                            viewItem.SubItems.Add(string.Empty);
                            viewItem.SubItems.Add(buildTemplate.DefaultDropLocation);
                            viewItem.SubItems.Add(buildTemplate.CommandLineArguments);
                            viewItem.Group = this.lvBuildTemplates.Groups[buildTemplate.TeamProject];
                        }
                        catch (Exception ex)
                        {
                            brokenBuildTemplates.Add(buildTemplate);

                            if (added)
                            {
                                this.lvBuildTemplates.Items.RemoveAt(this.lvBuildTemplates.Items.Count-1);
                            }

                            MessageBox.Show(string.Format("Error retrieving information about build template '{0}'.\n\r{1}\n\r\n\rThis build template will be removed from current list.", 
                                buildTemplate.TemplateName, ex.Message),  "Loading build templates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        UIContext.Instance.ProgressDoStep();
                    }
                });

                if (brokenBuildTemplates.Count > 0)
                {
                    brokenBuildTemplates.ForEach(buildTemplate => Context.BuildTemplates.Templates.Remove(buildTemplate));
                    Context.BuildTemplates.SaveToFile(Context.BuildTemplates.Filename);
                }
            }
            finally
            {
                this.btnExportTemplates.Enabled = this.lvBuildTemplates.Items.Count > 0;

                UIContext.Instance.ProgressEnd();

                this.lvBuildTemplates.EndUpdate();
                RestoreSelectedItems(false);
            }
        }

        private void SortTemplatesListData()
        {
            Context.BuildTemplates.Sort(this.sortInfoTemplates);
        }

        private void lvBuildTemplates_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView.ColumnHeaderCollection columns = this.lvBuildTemplates.Columns;
            ColumnHeader column = columns[e.Column];

            object sd = column.Tag;
            SortOrder sortOrder;
            if (sd == null)
            {
                sortOrder = SortOrder.Ascending;
            }
            else
            {
                sortOrder = (SortOrder) sd;
                if (sortOrder == SortOrder.Ascending)
                {
                    sortOrder = SortOrder.Descending;
                }
                else
                {
                    sortOrder = SortOrder.Ascending;
                }
            }

            if (this.sortInfoTemplates.Index > -1)
            {
                columns[this.sortInfoTemplates.Index].ImageIndex = -1;
            }

            column.Tag = sortOrder;
            column.ImageIndex = sortOrder == SortOrder.Ascending ? 0 : 1;
            this.sortInfoTemplates.Index = e.Column;
            this.sortInfoTemplates.Order = sortOrder;

            SortTemplatesListData();
            PopulateBuildTemplates(false);
        }

        private void mniCreateBuildTemplate_Click(object sender, EventArgs e)
        {
            if (Context.BuildTemplates == null)
            {
                MessageBox.Show(
                    "Use 'Open Templates' or 'New Templates' to setup storage for team build templates first.",
                    "Team build templates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var definition = (IBuildDefinition) this.lvDefinitions.SelectedItems[0].Tag;

            BuildTemplate buildTemplate = FormBuildTemplateEdit.DialogShow(null, definition, FormActionMode.New);
            if (buildTemplate != null)
            {
                Context.BuildTemplates.Templates.Add(buildTemplate);
                Context.BuildTemplates.SaveToFile(Context.BuildTemplates.Filename);
                PopulateBuildTemplates(true);
                SelectBuildTemplate(buildTemplate);
            }
        }

        private void SelectBuildTemplate(BuildTemplate buildTemplate)
        {
            SelectBuildTemplates(new List<BuildTemplate> {buildTemplate});
        }

        private void SelectBuildTemplates(List<BuildTemplate> buildTemplates)
        {
            ListViewItem topItem = null;
            this.lvBuildTemplates.Select();

            foreach (ListViewItem viewItem in this.lvBuildTemplates.Items)
            {
                var itemTemplate = viewItem.Tag as BuildTemplate;

                ListViewItem item = viewItem;

                buildTemplates.ForEach(template =>
                {
                    if (itemTemplate == template)
                    {
                        if (topItem == null || item.Position.Y < topItem.Position.Y)
                        {
                            topItem = item;
                        }
                        item.Selected = true;
                    }
                });
            }

            if (topItem != null)
            {
                topItem.Focused = true;
                topItem.EnsureVisible();
            }
        }


        private void menuList_Opening(object sender, CancelEventArgs e)
        {
            this.mniEditDefinition.Enabled = this.lvDefinitions.SelectedItems.Count == 1;
            this.mniCreateBuildTemplate.Enabled = this.mniEditDefinition.Enabled;
            this.mniEditProjectFile.Enabled = this.mniEditDefinition.Enabled;
        }

        private void menuTemplates_Opening(object sender, CancelEventArgs e)
        {
            this.mniEditBuildTemplate.Enabled = this.lvBuildTemplates.SelectedItems.Count == 1;
            this.mniQueueBuildTemplate.Enabled = this.mniEditBuildTemplate.Enabled;
            this.mniCopyBuildTemplate.Enabled = this.mniEditBuildTemplate.Enabled;
            this.mniDeleteBuildTemplate.Enabled = this.lvBuildTemplates.SelectedItems.Count > 0;

            this.mniQueueMultiBuildTemplate.Visible = this.lvBuildTemplates.SelectedItems.Count > 1;
        }

        private void mniEditBuildTemplate_Click(object sender, EventArgs e)
        {
            ListViewItem viewItem = this.lvBuildTemplates.SelectedItems[0];
            var buildTemplate = viewItem.Tag as BuildTemplate;
            int index = Context.BuildTemplates.Templates.FindIndex(template => template == buildTemplate);

            buildTemplate = FormBuildTemplateEdit.DialogShow(buildTemplate, null, FormActionMode.Edit);
            if (buildTemplate != null)
            {
                if (Context.BuildTemplates.Templates[index].Timestamp == 0)
                {
                    buildTemplate.Timestamp = DateTime.Now.Ticks;
                }
                else
                {
                    buildTemplate.Timestamp = Context.BuildTemplates.Templates[index].Timestamp;
                }

                Context.BuildTemplates.Templates[index] = buildTemplate;
                //Context.BuildTemplates.Templates[viewItem.Index] = buildTemplate;
                Context.BuildTemplates.SaveToFile(Context.BuildTemplates.Filename);
                PopulateBuildTemplates(true);
                SelectBuildTemplate(buildTemplate);
            }
        }

        private void lvBuildTemplates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lvBuildTemplates.SelectedItems.Count == 1)
            {
                mniEditBuildTemplate_Click(sender, e);
            }
        }

        private void lvDefinitions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lvDefinitions.SelectedItems.Count == 1)
            {
                mniEdit_Click(sender, e);
            }
        }

        private void mniDeleteBuildTemplate_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    string.Format("Do you want to delete selected {0} templates?",
                        this.lvBuildTemplates.SelectedItems.Count),
                    "Delete team build templates", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            var templates = new List<BuildTemplate>();
            foreach (ListViewItem selectedItem in this.lvBuildTemplates.SelectedItems)
            {
                templates.Add(selectedItem.Tag as BuildTemplate);
            }

            foreach (BuildTemplate template in templates)
            {
                Context.BuildTemplates.Templates.Remove(template);
            }

            Context.BuildTemplates.SaveToFile(Context.BuildTemplates.Filename);
            PopulateBuildTemplates(true);
        }

        private void mniCopyBuildTemplate_Click(object sender, EventArgs e)
        {
            var buildTemplate = this.lvBuildTemplates.SelectedItems[0].Tag as BuildTemplate;

            buildTemplate = FormBuildTemplateEdit.DialogShow(buildTemplate, null, FormActionMode.Copy);
            if (buildTemplate != null)
            {
                Context.BuildTemplates.Templates.Add(buildTemplate);
                Context.BuildTemplates.SaveToFile(Context.BuildTemplates.Filename);
                PopulateBuildTemplates(true);
                SelectBuildTemplate(buildTemplate);
            }
        }

        private void mniQueueBuildTemplate_Click(object sender, EventArgs e)
        {
            ListViewItem viewItem = this.lvBuildTemplates.SelectedItems[0];
            var buildTemplate = viewItem.Tag as BuildTemplate;

            bool saveChanges;
            buildTemplate = FormBuildTemplateEdit.DialogShow(buildTemplate, null, FormActionMode.View, out saveChanges);
            if (buildTemplate != null)
            {
                if (saveChanges)
                {
                    Context.BuildTemplates.Templates[viewItem.Index] = buildTemplate;
                    Context.BuildTemplates.SaveToFile(Context.BuildTemplates.Filename);
                    PopulateBuildTemplates(true);
                    SelectBuildTemplate(buildTemplate);
                }

                QueueBuildTemplate(buildTemplate);
            }
        }

        private void QueueBuildTemplate(BuildTemplate buildTemplate)
        {
            QueueBuildTemplate(buildTemplate, false);
        }

        private void QueueBuildTemplate(BuildTemplate buildTemplate, bool queueingMultiple)
        {
            IBuildDefinition buildDefinition = Context.BuildServer.GetBuildDefinition(buildTemplate.TeamProject,
                buildTemplate.DefinitionName);

            bool started = buildDefinition != null;
            string exc_msg = "-";
            IQueuedBuild queuedBuild = null;
            if (started)
            {
                try
                {
                    IBuildRequest request = buildDefinition.CreateBuildRequest();
                    //IBuildAgent buildAgent = Context.BuildServer.GetBuildAgent(new Uri(buildTemplate.BuildControllerUri));
                    IBuildController buildController = Context.BuildServer.GetBuildController(buildTemplate.BuildControllerName);
                    /*request.BuildAgent = buildAgent;
                    request.CommandLineArguments = buildTemplate.CommandLineArguments;*/
                    request.BuildController = buildController;

                    BuildProcessParameters buildProcessParameters = buildDefinition.GetBuildProcessParameters();
                    buildProcessParameters.MSBuildArguments = buildTemplate.CommandLineArguments;

                    request.ProcessParameters = buildProcessParameters.SaveToXml();
                    request.DropLocation = buildTemplate.DefaultDropLocation;
                    request.Postponed = buildTemplate.Postponed;
                    request.Priority = buildTemplate.RunPriority;
                    request.RequestedFor = Context.LoggedUser;

                    queuedBuild = Context.BuildServer.QueueBuild(request);

                    if (!queueingMultiple)
                    {
                        started = queuedBuild.WaitForBuildStart(10000, 10000);
                    }
                }
                catch (Exception e)
                {
                    exc_msg = e.Message;
                }
            }

            if (!queueingMultiple)
            {
                string message = started
                    ? string.Format("Team build template '{0}' started successfully", buildTemplate.TemplateName)
                    : string.Format("Team build template '{0}' failed to start, message: {1}", buildTemplate.TemplateName, exc_msg);

                ToolTipIcon icon = started ? ToolTipIcon.Info : ToolTipIcon.Warning;
                string caption = string.Format("Queue team build template '{0}'", buildTemplate.TemplateName);

                UIContext.Instance.ShowTrayTooltip(caption, message, icon, new NavigateToTeamBuildDefinitionHandler(buildTemplate));

                //MessageBox.Show(message, string.Format("Queue team build template '{0}'", buildTemplate.TemplateName), MessageBoxButtons.OK, icon););

                if (started && queuedBuild != null)
                {
                    //this.parentControl.FocusAndSelectTeamBuild(queuedBuild);
                    UIContext.Instance.ControlTeamBuilds.FocusAndSelectTeamBuild(queuedBuild);
                }
            }
        }

        public void FocusAndSelectDefinition(IBuildDefinition definition)
        {
            this.lvDefinitions.SelectedItems.Clear();

            SelectBuildDefinitions(new List<IBuildDefinition> {definition});
        }

        public void FocusAndSelectBuildTemplate(BuildTemplate buildTemplate)
        {
            this.lvBuildTemplates.SelectedItems.Clear();

            SelectBuildTemplates(new List<BuildTemplate> { buildTemplate });
        }

        private void lbCurrentTemplate_Click(object sender, EventArgs e)
        {
            toolTip1.Active = false;
            toolTip1.Active = true;
        }

        private void lbCurrentTemplate_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void mniReloadList_Click(object sender, EventArgs e)
        {
            OpenTemplates(Config.Instance.BuildTemplatesFileName, false);
        }

        private void btnOpenTemplates_Click(object sender, EventArgs e)
        {
            this.openTD.FileName = Context.BuildTemplates == null ? string.Empty : Context.BuildTemplates.Filename;
            if (this.openTD.ShowDialog() == DialogResult.OK)
            {
                OpenTemplates(this.openTD.FileName);
            }
        }

        private void btnExportTemplates_Click(object sender, EventArgs e)
        {
            var action = (sender as ToolStripItem).Tag as string;

            this.saveTD.Title = action == "0" ? "Create new team build templates file" :
                                                                                           "Export team build templates to file";

            if (action == "1" && (Context.BuildTemplates == null || this.lvBuildTemplates.Items.Count == 0))
            {
                return;
            }

            this.saveTD.FileName = action == "0" ? string.Empty : Context.BuildTemplates.Filename;
            if (this.saveTD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (action == "0")
                    {
                        Context.BuildTemplates = new BuildTemplateCollection();
                    }

                    Context.BuildTemplates.SaveToFile(this.saveTD.FileName);

                    if (File.Exists(this.saveTD.FileName))
                    {
                        DialogResult result = action == "0" ? DialogResult.Yes :
                                                                                   MessageBox.Show(
                                                                                       string.Format(
                                                                                           "Team build templates was successfully exported to file '{0}', Do you want to reload current list from this file?",
                                                                                           this.saveTD.FileName),
                                                                                       "Export team build templates",
                                                                                       MessageBoxButtons.YesNo,
                                                                                       MessageBoxIcon.Question,
                                                                                       MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            if (OpenTemplates(this.saveTD.FileName))
                            {
                                UpdateExportButton();
                            }
                        }
                        else
                        {
                            ShowCurrentInfo(true);
                        }
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(
                        string.Format("Error exporting team build templates to file '{0}', error: {1}",
                            this.saveTD.FileName, e1.Message),
                        "Export team build templates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void lbCurrentTemplate_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Clipboard.SetText(Config.Instance.BuildTemplatesFileName);
            }
        }

        private void mniEditProjectFile_Click(object sender, EventArgs e)
        {
            var definition = this.lvDefinitions.SelectedItems[0].Tag as IBuildDefinition;
            Item buildFileItem = Context.GetProjectBuildFileItem(definition);
            if (buildFileItem == null)
            {
                MessageBox.Show("Could not find project file!", "Edit Project File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tempFileName = Path.GetTempFileName();
            string tempDir = Path.GetDirectoryName(tempFileName);
            tempDir = Path.Combine(tempDir, Path.GetFileName(tempFileName));
            File.Delete(tempFileName);
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            string serverProjectFileName = buildFileItem.ServerItem;
            string realBuildFilePath = Path.Combine(tempDir, Context.BUILD_FILE);
            Workspace workspace = null;
            string fileContent = null;

            Func<string> reloadFromServerFunc = delegate
                {
                    buildFileItem.DownloadFile(realBuildFilePath);
                    return File.ReadAllText(realBuildFilePath);
                };

            Func<string> initialLoadFromServerFunc = delegate
                {
                    workspace = Context.GetTemporaryWorkspaceAndMap(definition.GetConfigurationFolderPath(), tempDir);
                    workspace.Get(VersionSpec.Latest, GetOptions.GetAll | GetOptions.Overwrite);

                    fileContent = File.Exists(realBuildFilePath) ? File.ReadAllText(realBuildFilePath) : string.Empty;
                    return fileContent;
                };

            if (FormEditXml.DialogShow(string.Format("Editing team build project file '{0}'", serverProjectFileName),
                ref fileContent, initialLoadFromServerFunc, reloadFromServerFunc))
            {
                int checkedoutFiles = workspace.PendEdit(realBuildFilePath);

                File.WriteAllText(realBuildFilePath, fileContent);

                PendingChange[] pendingChanges = workspace.GetPendingChanges();
                int changesetNumber = workspace.CheckIn(pendingChanges, Context.ControlServer.AuthenticatedUser, "Changed by TFS Manager", null, null,
                    new PolicyOverrideInfo("Overrided by TFS Manager", null));

                workspace.PendDelete(tempDir);
                //string[] files = Directory.GetFiles(tempDir, "*.*");
                workspace.Undo(new[] { tempDir }, RecursionType.Full, false);

                MessageBox.Show(string.Format("Changes was saved to file '{0}' under changeset number '{1}'.",
                    serverProjectFileName, changesetNumber), "Edit Project File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mniQueueMultiBuildTemplate_Click(object sender, EventArgs e)
        {
            Dictionary<string, BuildTemplate> buildTemplates = new Dictionary<string, BuildTemplate>();
            List<string> buildTemplateNames = new List<string>();
            foreach (ListViewItem item in this.lvBuildTemplates.SelectedItems)
            {
                BuildTemplate buildTemplate = item.Tag as BuildTemplate;
                string name = string.Format("{0} ({1})", buildTemplate.TemplateName, buildTemplate.TeamProject);
                buildTemplates.Add(name, buildTemplate);
                buildTemplateNames.Add(name);
            }

            if (FormCheckedList.DialogShow("Queue Multiple Team Build Templates",
                "Select which team build templates will be queued at once:", buildTemplateNames, true))
            {
                foreach (string itemName in buildTemplateNames)
                {
                    BuildTemplate buildTemplate = buildTemplates[itemName];
                    QueueBuildTemplate(buildTemplate, true);
                }
            }
        }

        private void mniNewDefinition_Click(object sender, EventArgs e)
        {
            var buildDefinition = FormDefinitionEdit.DialogShow(null, FormActionMode.New);
        }

        private void mniChangeDefaultDropLocation_Click(object sender, EventArgs e)
        {
            if (lvBuildTemplates.SelectedIndices.Count == 0)
            {
                return;
            }

            BuildTemplate buildTemplate = lvBuildTemplates.SelectedItems[0].Tag as BuildTemplate;

            string newValue = buildTemplate.DefaultDropLocation;
            if (FormEditBox.DialogShow("Change Default Drop Location", "Enter new default drop location", "Ok", null,
                true, true, ref newValue) == DialogResult.OK)
            {
                var buildTemplates = this.lvBuildTemplates.SelectedItems.ToCollection(o => (o as ListViewItem).Tag as BuildTemplate);

                MakeMultipleChangesOnBuildTemplates(buildTemplates, true,
                    delegate(BuildTemplate template)
                        {
                            template.DefaultDropLocation = newValue;
                        });
            }
        }

        private void lvDefinitions_KeyDown(object sender, KeyEventArgs e)
        {
            EnsureSelectAllPressed(sender as ListView, e);
        }

        private void lvBuildTemplates_KeyDown(object sender, KeyEventArgs e)
        {
            EnsureSelectAllPressed(sender as ListView, e);
        }

        private void EnsureSelectAllPressed(ListView listView, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                listView.SelectedIndices.Clear();
                foreach (ListViewItem viewItem in listView.Items)
                {
                    viewItem.Selected = true;
                }
            }
        }
    }

    internal class NavigateToTeamBuildDefinitionHandler: IBalloonClickHander
    {
        private readonly BuildTemplate buildTemplate;

        public NavigateToTeamBuildDefinitionHandler(BuildTemplate buildTemplate)
        {
            this.buildTemplate = buildTemplate;
        }

        public void OnClick()
        {
            UIContext.Instance.ControlTeamBuilds.FocusAndSelectBuildTemplate(buildTemplate);
        }
    }
}