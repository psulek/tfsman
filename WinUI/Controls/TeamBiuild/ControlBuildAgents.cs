using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Core;
using TFSManager.Core.WinForms;
using TFSManager.Forms;

namespace TFSManager.Controls
{
    public partial class ControlBuildAgents: UserControl
    {
        private readonly List<IBuildAgent> backup_Selected = new List<IBuildAgent>();
        private readonly ListViewSortInfo sortInfo = new ListViewSortInfo(1, SortOrder.Ascending);
        private List<IBuildAgent> cachedAgents;
        private string lastAppliedFilterHashCode = string.Empty;
        //internal ControlTeamBuilds parentControl;

        public ControlBuildAgents()
        {
            InitializeComponent();
        }

        public void Initialize(/*ControlTeamBuilds parentControl*/)
        {
            //this.parentControl = parentControl;
        }

        private void lvAgents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView.ColumnHeaderCollection columns = this.lvAgents.Columns;
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

            if (this.sortInfo.Index > -1)
            {
                columns[this.sortInfo.Index].ImageIndex = -1;
            }

            column.Tag = sortOrder;
            column.ImageIndex = sortOrder == SortOrder.Ascending ? 0 : 1;
            this.sortInfo.Index = e.Column;
            this.sortInfo.Order = sortOrder;

            SortListData();
            PopulateBuildAgents(false, false);
        }

        internal void PopulateBuildAgents(bool refresh, bool resort)
        {
            this.lvAgents.BeginUpdate();

            try
            {
                BackupSelectedItems();

                //if (refresh || this.lastAppliedFilterHashCode != this.parentControl.selectedTeamProjectIndex)
                if (refresh || this.lastAppliedFilterHashCode != UIContext.Instance.ControlTeamBuildFilter.LastAppliedFilterHashCode)
                {
                    this.cachedAgents = null;
                }

                if (this.cachedAgents == null)
                {
                    string[] checkedProjects = UIContext.Instance.ControlTeamBuildFilter.CheckedProjects;

                    UIContext.Instance.ProgressBegin(checkedProjects.Length, 1);

                    try
                    {
                        this.cachedAgents = new List<IBuildAgent>();
                        this.lvAgents.Groups.Clear();
                        foreach (string teamProject in checkedProjects)
                        {
                            //this.cachedAgents.AddRange(Context.BuildServer.QueryBuildAgents(teamProject));
                            this.lvAgents.Groups.Add(teamProject, teamProject);

                            UIContext.Instance.ProgressDoStep();
                        }

                        this.lastAppliedFilterHashCode = UIContext.Instance.ControlTeamBuildFilter.LastAppliedFilterHashCode;
                    }
                    finally
                    {
                        UIContext.Instance.ProgressEnd();
                    }
                }

                if (resort)
                {
                    SortListData();
                }

                this.lvAgents.Visible = true;
                this.lvAgents.Items.Clear();
                UIContext.Instance.ProgressBegin(this.cachedAgents.Count, 1);
                this.cachedAgents.ForEach(agent =>
                {
                    ListViewItem viewItem = this.lvAgents.Items.Add(agent.Name);
                    viewItem.Tag = agent;
                    viewItem.SubItems.Add(agent.MachineName);
                    viewItem.SubItems.Add(agent.Status.ToString());
                    viewItem.SubItems.Add(agent.QueueCount.ToString());
                    viewItem.SubItems.Add(agent.Uri.ToString());
                    viewItem.Group = this.lvAgents.Groups[agent.TeamProject];

                    UIContext.Instance.ProgressDoStep();
                });
            }
            finally
            {
                this.lvAgents.EndUpdate();
                UIContext.Instance.ProgressEnd();
                RestoreSelectedItems();
            }
        }

        private void RestoreSelectedItems()
        {
            this.lvAgents.SelectedItems.Clear();
            SelectBuildAgents(this.backup_Selected);
        }

        private void BackupSelectedItems()
        {
            this.backup_Selected.Clear();

            foreach (ListViewItem viewItem in this.lvAgents.SelectedItems)
            {
                this.backup_Selected.Add(viewItem.Tag as IBuildAgent);
            }
        }

        private void SortListData()
        {
            this.cachedAgents.Sort((x, y) =>
            {
                int compared;

                if (this.sortInfo.Index == 0) // Name
                {
                    compared = string.CompareOrdinal(x.Name, y.Name);
                }
                else if (this.sortInfo.Index == 1) // Machine
                {
                    compared = string.CompareOrdinal(x.MachineName, y.MachineName);
                }
                else if (this.sortInfo.Index == 2) // Status
                {
                    compared = string.CompareOrdinal(x.Status.ToString(), y.Status.ToString());
                }
                else if (this.sortInfo.Index == 3) // Queue count
                {
                    compared = x.QueueCount - y.QueueCount;
                }
                else // uri
                {
                    compared = string.CompareOrdinal(x.Uri.ToString(), y.Uri.ToString());
                }

                if (this.sortInfo.Order == SortOrder.Descending)
                {
                    compared = compared * -1;
                }

                return compared;
            });
        }


        private void menuAgents_Opening(object sender, CancelEventArgs e)
        {
            this.mniAgent_CopyTo.Enabled = this.lvAgents.SelectedItems.Count == 1;
            this.mniAgent_Edit.Enabled = this.mniAgent_CopyTo.Enabled;
            this.mniAgent_Delete.Enabled = this.mniAgent_CopyTo.Enabled;
        }

        private void mniAgent_New_Click(object sender, EventArgs e)
        {
/*
            IBuildAgent buildAgent = this.lvAgents.SelectedItems.Count == 0
                ? null : this.lvAgents.SelectedItems[0].Tag as IBuildAgent;
            IBuildAgent newAgentTemplate = FormAgentEdit.DialogShow(buildAgent, FormActionMode.New);
            IBuildAgent newAgent = null;
            if (newAgentTemplate != null)
            {
                try
                {
                    newAgent = Context.BuildServer.CreateBuildAgent(newAgentTemplate.TeamProject);
                    TempBuildAgent.AssingTo(newAgentTemplate, newAgent);

                    Context.BuildServer.SaveBuildAgents(new[] {newAgent});
                }
                catch (Exception ex)
                {
                    if (newAgent != null)
                    {
                        try
                        {
                            Context.BuildServer.DeleteBuildAgents(new[] {newAgent.Uri});
                        }
                        catch {}
                    }

                    MessageBox.Show(ex.Message, "New build agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (newAgent != null)
                    {
                        //this.parentControl.EnsureSelectedTeamProject(newAgent.TeamProject);
                        UIContext.Instance.ControlTeamBuildFilter.CheckProject(newAgent.TeamProject, true);
                        PopulateBuildAgents(true, true);
                        SelectBuildAgent(newAgent);
                    }
                }
            }
*/
        }

        private void mniAgent_Edit_Click(object sender, EventArgs e)
        {
            var buildAgent = this.lvAgents.SelectedItems[0].Tag as IBuildAgent;
            var savedbuildAgent = new TempBuildAgent(buildAgent);

            IBuildAgent editedAgent = FormAgentEdit.DialogShow(buildAgent, FormActionMode.Edit);
            if (editedAgent != null)
            {
                TempBuildAgent.AssingTo(editedAgent, buildAgent);
                try
                {
                    Context.BuildServer.SaveBuildAgents(new[] {buildAgent});
                }
                catch (Exception ex)
                {
                    TempBuildAgent.AssingTo(savedbuildAgent, buildAgent);

                    MessageBox.Show(ex.Message, "Edit build agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    PopulateBuildAgents(true, true);
                    SelectBuildAgent(buildAgent);
                }
            }
        }

        private void mniAgent_Delete_Click(object sender, EventArgs e)
        {
            var buildAgent = this.lvAgents.SelectedItems[0].Tag as IBuildAgent;
            if (
                MessageBox.Show(
                    string.Format("Do you want to delete build agent '{0}' from team project '{1}' ?", buildAgent.Name,
                        buildAgent.TeamProject),
                    "Delete build agent", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            try
            {
                Context.BuildServer.DeleteBuildAgents(new[] {buildAgent});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete build agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            PopulateBuildAgents(true, true);
        }

        private void mniAgent_CopyTo_Click(object sender, EventArgs e)
        {
/*
            var buildAgent = this.lvAgents.SelectedItems[0].Tag as IBuildAgent;

            IBuildAgent copiedAgentTemplate = FormAgentEdit.DialogShow(buildAgent, FormActionMode.Copy);
            IBuildAgent copiedAgent = null;
            if (copiedAgentTemplate != null)
            {
                try
                {
                    copiedAgent = Context.BuildServer.CreateBuildAgent(copiedAgentTemplate.TeamProject);
                    TempBuildAgent.AssingTo(copiedAgentTemplate, copiedAgent);

                    Context.BuildServer.SaveBuildAgents(new[] {copiedAgent});
                }
                catch (Exception ex)
                {
                    if (copiedAgent != null)
                    {
                        try
                        {
                            Context.BuildServer.DeleteBuildAgents(new[] {copiedAgent.Uri});
                        }
                        catch {}
                    }

                    MessageBox.Show(ex.Message, "New build agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (copiedAgent != null)
                    {
                        //this.parentControl.EnsureSelectedTeamProject(copiedAgent.TeamProject);
                        UIContext.Instance.ControlTeamBuildFilter.CheckProject(copiedAgent.TeamProject, true);
                        PopulateBuildAgents(true, true);
                        SelectBuildAgent(copiedAgent);
                    }
                }
            }

            #region old

            //            IBuildAgent buildAgent = this.lvAgents.SelectedItems[0].Tag as IBuildAgent;
            //
            //            IBuildAgent newBuildAgent;
            //            bool result = FormAgentCopyTo.DialogShow(buildAgent, out newBuildAgent);
            //            if (result)
            //            {
            //                parentControl.EnsureSelectedTeamProject(newBuildAgent.TeamProject);
            //                PopulateBuildAgents(true, true);
            //                SelectBuildAgent(newBuildAgent);
            //            }

            #endregion
*/
        }

        private void SelectBuildAgent(IBuildAgent agent)
        {
            SelectBuildAgents(new List<IBuildAgent> {agent});
        }

        private void SelectBuildAgents(List<IBuildAgent> agents)
        {
            ListViewItem topItem = null;

            foreach (ListViewItem viewItem in this.lvAgents.Items)
            {
                var itemAgent = viewItem.Tag as IBuildAgent;

                ListViewItem item = viewItem;
                agents.ForEach(agent =>
                {
                    if (TempBuildAgent.IsEqual(agent, itemAgent))
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

        private void lvAgents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mniAgent_Edit_Click(sender, e);
        }
    }
}