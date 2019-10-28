using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Core;
using TFSManager.Core.WinForms;
using TFSManager.Forms;

using THE.Components;

namespace TFSManager.Controls
{
    public partial class ControlBuilds: UserControl, IControlTeamBuildList
    {
        private const string str_RemoveQuality = "-- Remove quality --";

        private readonly ListViewSortInfo sortInfo = new ListViewSortInfo(1, SortOrder.Descending);
        private readonly Dictionary<string, List<string>> teamBuildQualities = new Dictionary<string, List<string>>();
        private Dictionary<bool, List<BuildInfo>> backup_Selected = new Dictionary<bool, List<BuildInfo>>();
        private Dictionary<bool, List<BuildInfo>> cachedBuilds = null;
        private string lastAppliedFilterHashCode = string.Empty;
        private bool? lastIsQueuedSelected = null;
        //internal ControlTeamBuilds parentControl;

        #region class BuildInfo

        internal class BuildInfo
        {
            internal BuildInfo(IQueuedBuild queuedBuild)
            {
                this.queuedBuild = queuedBuild;
            }

            internal BuildInfo(IBuildDetail buildDetail)
            {
                this.buildDetail = buildDetail;
            }

            internal IQueuedBuild queuedBuild;
            internal IBuildDetail buildDetail;
        }

        #endregion

        public ControlBuilds()
        {
            InitializeComponent();
        }

        public void Initialize(/*ControlTeamBuilds parentControl*/)
        {
            //this.parentControl = parentControl;
        }

        private void lvTeamBuilds_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            HeaderCollectionCCH columns = this.lvTeamBuilds.Columns;
            ColumnCCH column = columns[e.Column];

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
            PopulateTeamBuilds(false, false, null);
        }

        internal void PopulateTeamBuilds(bool refresh, bool resort, Action<IBuildDetailSpec> modifyAction)
        {
            ListViewCCH listView = GetTreeView();
            listView.BeginUpdate();

            BackupSelectedItems();

            //if (refresh || this.lastSelectedTeamProjectIndex != this.parentControl.selectedTeamProjectIndex || !lastIsQueuedSelected.Equals(IsQueuedSelected))

            if (refresh || this.lastAppliedFilterHashCode != UIContext.Instance.ControlTeamBuildFilter.LastAppliedFilterHashCode || 
                !lastIsQueuedSelected.Equals(IsQueuedSelected))
            {
                this.cachedBuilds = null;
            }

            if (this.cachedBuilds == null)
            {
                string[] checkedProjects = UIContext.Instance.ControlTeamBuildFilter.CheckedProjects;

                UIContext.Instance.ProgressBegin(checkedProjects.Length, 1);

                try
                {
                    this.cachedBuilds = new Dictionary<bool, List<BuildInfo>>
                        {
                            {false, new List<BuildInfo>()},
                            {true, new List<BuildInfo>()}
                        };
                    listView.Groups.Clear();
                    this.teamBuildQualities.Clear();
                    foreach (string teamProject in checkedProjects)
                    {
                        List<BuildInfo> buildDetails = new List<BuildInfo>();

                        if (IsQueuedSelected)
                        {
                            IQueuedBuildsView buildsView = Context.BuildServer.CreateQueuedBuildsView(teamProject);
                            buildsView.QueryOptions = QueryOptions.All;
                            buildsView.StatusFilter = QueueStatus.All;
                            buildsView.Refresh(true);
                            IQueuedBuild[] queuedBuilds = buildsView.QueuedBuilds;

                            foreach (var queuedBuild in queuedBuilds)
                            {
                                buildDetails.Add(new BuildInfo(queuedBuild));
                            }
                        }
                        else
                        {
                            IBuildDetailSpec buildDetailSpec = Context.BuildServer.CreateBuildDetailSpec(teamProject);
                            buildDetailSpec.MaxBuildsPerDefinition = btnLatestBuilds.Checked ? 1 : int.MaxValue;
                            buildDetailSpec.QueryOrder = BuildQueryOrder.StartTimeDescending;
                            buildDetailSpec.Status = BuildStatus.Failed | BuildStatus.NotStarted
                                | BuildStatus.PartiallySucceeded | BuildStatus.Stopped | BuildStatus.Succeeded;
                            
                            if (modifyAction != null)
                            {
                                modifyAction(buildDetailSpec);
                            }

                            IBuildQueryResult builds = Context.BuildServer.QueryBuilds(buildDetailSpec);

                            foreach (var buildDetail in builds.Builds)
                            {
                                buildDetails.Add(new BuildInfo(buildDetail));
                            }
                        }

                        if (this.cachedBuilds.ContainsKey(this.IsQueuedSelected))
                        {
                            List<BuildInfo> cachedBuildItems = this.cachedBuilds[this.IsQueuedSelected];
                            foreach (var item in buildDetails)
                            {
                                cachedBuildItems.Add(item);
                            }
                        }
                        else
                        {
                            this.cachedBuilds.Add(this.IsQueuedSelected, buildDetails);
                        }

                        //this.cachedBuilds.Add(IsQueuedSelected, cachedBuildItems);
                        listView.Groups.Add(teamProject, teamProject);

                        string[] buildQualities = Context.BuildServer.GetBuildQualities(teamProject);
                        this.teamBuildQualities.Add(teamProject, new List<string>(buildQualities));

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

            listView.Visible = true;
            try
            {
                UIContext.Instance.ProgressBegin(this.cachedBuilds.Count, 1);

                listView.Items.Clear();

                foreach (var cachedBuild in this.cachedBuilds[IsQueuedSelected])
                {
                    PopulateListItem(listView, cachedBuild);
                    UIContext.Instance.ProgressDoStep();
                }

//                this.cachedBuilds.ForEach(teamBuild =>
//                {
//                    ListViewItem viewItem = listView.Items.Add(teamBuild.Status.ToString());
//                    viewItem.UseItemStyleForSubItems = false;
//                    viewItem.StateImageIndex = GetBuildStatusImage(teamBuild.Status);
//                    viewItem.Tag = teamBuild;
//                    viewItem.SubItems.Add(teamBuild.StartTime.ToString());
//                    viewItem.SubItems.Add(teamBuild.BuildNumber);
//                    viewItem.SubItems.Add(teamBuild.BuildDefinition.Name);
//                    viewItem.SubItems.Add(teamBuild.BuildAgent.Name);
//                    viewItem.SubItems.Add(teamBuild.RequestedBy);
//                    viewItem.SubItems.Add(teamBuild.Quality);
//                    viewItem.SubItems.Add(teamBuild.FinishTime.ToString());
//
//                    bool logFileExists = !string.IsNullOrEmpty(teamBuild.LogLocation)
//                        && File.Exists(teamBuild.LogLocation);
//
//                    ListViewItem.ListViewSubItem subItem = viewItem.SubItems.Add(logFileExists ? "Has log" : "No log");
//                    subItem.ForeColor = logFileExists
//                        ? Color.FromKnownColor(KnownColor.WindowText) : Color.FromKnownColor(KnownColor.ControlLight);
//
//                    viewItem.Group = listView.Groups[teamBuild.BuildDefinition.TeamProject];
//
//                    UIContext.ProgressDoStep();
//                });
            }
            finally
            {
                listView.EndUpdate();
                UIContext.Instance.ProgressEnd();
                RestoreSelectedItems();
            }
        }

        private void PopulateListItem(ListViewCCH listView, BuildInfo buildInfo)
        {
            ListViewItem viewItem;
            if (IsQueuedSelected)
            {
                IQueuedBuild queuedBuild = buildInfo.queuedBuild;
                //IBuildDetail detail = queuedBuild.Build;

                viewItem = listView.Items.Add(queuedBuild.BuildDefinition.Name);
                viewItem.UseItemStyleForSubItems = false;
                viewItem.StateImageIndex = GetBuildStatusImage(queuedBuild.Status, queuedBuild.Build);
                viewItem.SubItems.Add(queuedBuild.Priority.ToString());
                viewItem.SubItems.Add(queuedBuild.QueueTime.ToString());
                viewItem.SubItems.Add(queuedBuild.RequestedBy);
                //viewItem.SubItems.Add(queuedBuild.BuildAgent.Name);
                viewItem.SubItems.Add(string.Empty);

                viewItem.Group = listView.Groups[queuedBuild.BuildDefinition.TeamProject];
            }
            else
            {
                IBuildDetail buildDetail = buildInfo.buildDetail;

                viewItem = listView.Items.Add(buildDetail.Status.ToString());
                viewItem.UseItemStyleForSubItems = false;
                viewItem.StateImageIndex = GetBuildStatusImage(buildDetail.Status);
                viewItem.SubItems.Add(buildDetail.StartTime.ToString());
                viewItem.SubItems.Add(buildDetail.BuildNumber);
                viewItem.SubItems.Add(buildDetail.BuildDefinition.Name);
                //viewItem.SubItems.Add(buildDetail.BuildAgent.Name);
                viewItem.SubItems.Add(string.Empty);
                viewItem.SubItems.Add(buildDetail.RequestedBy);
                viewItem.SubItems.Add(buildDetail.Quality);
                viewItem.SubItems.Add(buildDetail.FinishTime.ToString());

                bool logFileExists = !string.IsNullOrEmpty(buildDetail.LogLocation)
                    && File.Exists(buildDetail.LogLocation);

                ListViewItem.ListViewSubItem subItem = viewItem.SubItems.Add(logFileExists ? "Has log" : "No log");
                subItem.ForeColor = logFileExists
                    ? Color.FromKnownColor(KnownColor.WindowText) : Color.FromKnownColor(KnownColor.ControlLight);

                viewItem.Group = listView.Groups[buildDetail.BuildDefinition.TeamProject];
            }

            viewItem.Tag = buildInfo;
        }

        private ListViewCCH GetTreeView()
        {
            return this.btnQueued.Checked ? this.lvTeamBuildsQueued : this.lvTeamBuilds;
        }

        private void RestoreSelectedItems()
        {
            GetTreeView().SelectedItems.Clear();
            SelectBuildsByCompare(this.backup_Selected[IsQueuedSelected]);
        }

        private void BackupSelectedItems()
        {
            this.backup_Selected.Clear();

            List<BuildInfo> list = new List<BuildInfo>();
            foreach (ListViewItem viewItem in this.GetTreeView().SelectedItems)
            {
                list.Add(viewItem.Tag as BuildInfo);
            }

            this.backup_Selected.Add(IsQueuedSelected, list);
        }

        private int GetBuildStatusImage(BuildStatus status)
        {
            int image = 5;

            switch (status)
            {
                case BuildStatus.InProgress:
                    image = 0;
                    break;
                case BuildStatus.Succeeded:
                    image = 1;
                    break;
                case BuildStatus.PartiallySucceeded:
                    image = 2;
                    break;
                case BuildStatus.Failed:
                    image = 3;
                    break;
                case BuildStatus.Stopped:
                    image = 4;
                    break;
                case BuildStatus.NotStarted:
                    image = 5;
                    break;
            }

            return image;
        }
        
        private int GetBuildStatusImage(QueueStatus status, IBuildDetail detail)
        {
            int image = 5;

            switch (status)
            {
                case QueueStatus.InProgress:
                    image = 0;
                    break;
                case QueueStatus.Completed:
                    image = GetBuildStatusImage(detail.Status);
                    break;
//                case QueueStatus.PartiallySucceeded:
//                    image = 2;
//                    break;
//                case QueueStatus.Failed:
//                    image = 3;
//                    break;
                case QueueStatus.Canceled:
                    image = 4;
                    break;
                case QueueStatus.Postponed:
                case QueueStatus.Queued:
                    image = 5;
                    break;
            }

            return image;
        }


        private void SortListData()
        {
            List<BuildInfo> listToSort = this.cachedBuilds[this.IsQueuedSelected];

            listToSort.Sort((x, y) =>
            {
                int compared;

                if (this.IsQueuedSelected)
                {
                    IQueuedBuild xx = x.queuedBuild;
                    IQueuedBuild yy = y.queuedBuild;

                    if (this.sortInfo.Index == COLUNN2_DEFINITION) // Build Definition
                    {
                        compared = string.CompareOrdinal(xx.BuildDefinition.Name, yy.BuildDefinition.Name);
                    }
                    else if (this.sortInfo.Index == COLUNN2_PRIORITY) // Priority
                    {
                        compared = string.CompareOrdinal(xx.Priority.ToString(), yy.Priority.ToString());
                    }
                    else if (this.sortInfo.Index == COLUNN2_DATEQUEUED) // Date queued
                    {
                        compared = DateTime.Compare(xx.QueueTime, yy.QueueTime);
                    }
                    else if (this.sortInfo.Index == COLUNN2_REQUESTEDBY) // Requested by
                    {
                        compared = string.CompareOrdinal(xx.RequestedBy, yy.RequestedBy);
                    }
                    else // Agent
                    {
                        compared = 0; // string.CompareOrdinal(xx.BuildAgent.Name, yy.BuildAgent.Name);
                    }
                }
                else
                {
                    IBuildDetail xx = x.buildDetail;
                    IBuildDetail yy = y.buildDetail;

                    if (this.sortInfo.Index == COLUNN_STATUS) // Status
                    {
                        compared = string.CompareOrdinal(xx.Status.ToString(), yy.Status.ToString());
                    }
                    else if (this.sortInfo.Index == COLUNN_STARTED) // Started
                    {
                        compared = DateTime.Compare(xx.StartTime, yy.StartTime);
                    }
                    else if (this.sortInfo.Index == COLUNN_BUILDNUMBER) // Build number
                    {
                        compared = string.CompareOrdinal(xx.BuildNumber, yy.BuildNumber);
                    }
                    else if (this.sortInfo.Index == COLUNN_DEFINITION) // Definition
                    {
                        compared = string.CompareOrdinal(xx.BuildDefinition.Name, yy.BuildDefinition.Name);
                    }
                    else if (this.sortInfo.Index == COLUNN_AGENT) // Agent
                    {
                        compared = 0; // string.CompareOrdinal(xx.BuildAgent.Name, yy.BuildAgent.Name);
                    }
                    else if (this.sortInfo.Index == COLUNN_REQUESTEDBY) // Requested by
                    {
                        compared = string.CompareOrdinal(xx.RequestedBy, yy.RequestedBy);
                    }
                    else if (this.sortInfo.Index == COLUNN_QUALITY) // Quality
                    {
                        compared = string.CompareOrdinal(xx.Quality, yy.Quality);
                    }
                    else if (this.sortInfo.Index == COLUNN_FINISHTIME) // Finish Time
                    {
                        compared = DateTime.Compare(xx.FinishTime, yy.FinishTime);
                    }
                    else
                    {
                        int xHasLog = Convert.ToInt32(!string.IsNullOrEmpty(xx.LogLocation) && File.Exists(xx.LogLocation));
                        int yHasLog = Convert.ToInt32(!string.IsNullOrEmpty(yy.LogLocation) && File.Exists(yy.LogLocation));

                        compared = xHasLog - yHasLog;
                    }
                }

                if (this.sortInfo.Order == SortOrder.Descending)
                {
                    compared = compared * -1;
                }

                return compared;
            });
        }

        private void menuBuilds_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (this.lvTeamBuilds.SelectedItems.Count == 0);

            this.mniViewLogFile.Enabled = (this.lvTeamBuilds.SelectedItems.Count == 1);
            IBuildDetail buildDetail = null;
            BuildInfo buildInfo = this.lvTeamBuilds.SelectedItems[0].Tag as BuildInfo;
            if (this.mniViewLogFile.Enabled)
            {
                buildDetail = buildInfo.buildDetail;
                bool fileExists = !string.IsNullOrEmpty(buildDetail.LogLocation) && File.Exists(buildDetail.LogLocation);
                this.mniViewLogFile.Enabled = fileExists;
            }

            this.mniGotoDefinition.Enabled = (this.lvTeamBuilds.SelectedItems.Count == 1);
            if (this.mniGotoDefinition.Enabled && buildDetail != null)
            {
                this.mniGotoDefinition.Text = string.Format("Go To Build Definition '{0}'",
                    buildDetail.BuildDefinition.Name);
            }
            else
            {
                this.mniGotoDefinition.Text = "Go To Build Definition";
            }

            this.mniBuildDetail.Enabled = (this.lvTeamBuilds.SelectedItems.Count == 1);

            this.mniSetQuality.Enabled = (this.lvTeamBuilds.SelectedItems.Count == 1);
            if (this.mniSetQuality.Enabled)
            {
                string teamProject = this.lvTeamBuilds.SelectedItems[0].Group.Name;
                buildDetail = buildInfo.buildDetail;

                if (this.mniSetQuality.Tag as string != teamProject)
                {
                    this.mniSetQuality.DropDownItems.Clear();
                    this.mniSetQuality.Tag = teamProject;
                    EventHandler qualityItem_Click = (o, args) =>
                    {
                        try
                        {
                            buildDetail = buildInfo.buildDetail;
                            string quality = (o as ToolStripMenuItem).Text;
                            buildDetail.Quality = quality == str_RemoveQuality ? string.Empty : quality;
                            Context.BuildServer.SaveBuilds(new[] {buildDetail});

                            PopulateTeamBuilds(false, true, null);
                            SelectBuild(buildInfo);
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show("Error updating quality of build, " + e1.Message, "Set build quality",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    var noneItem = this.mniSetQuality.DropDownItems.Add(str_RemoveQuality) as ToolStripMenuItem;
                    noneItem.Click += qualityItem_Click;

                    foreach (string buildQuality in this.teamBuildQualities[teamProject])
                    {
                        var item = this.mniSetQuality.DropDownItems.Add(buildQuality) as ToolStripMenuItem;
                        item.Click += qualityItem_Click;
                    }
                }

                foreach (ToolStripMenuItem menuItem in this.mniSetQuality.DropDownItems)
                {
                    menuItem.Checked = (string.Compare(menuItem.Text, buildDetail.Quality, true) == 0);
                }
            }
        }

        private void SelectBuild(BuildInfo buildToSelect)
        {
            foreach (ListViewItem viewItem in GetTreeView().Items)
            {
                var itemBuild = viewItem.Tag as BuildInfo;
                if (itemBuild == buildToSelect)
                {
                    viewItem.Selected = true;
                    viewItem.Focused = true;
                    viewItem.EnsureVisible();
                }
            }
        }

        private void SelectBuildByCompare(BuildInfo buildToSelect)
        {
            SelectBuildsByCompare(new List<BuildInfo> { buildToSelect });
        }

        private void SelectBuildsByCompare(List<BuildInfo> builds)
        {
/*
            ListViewItem topItem = null;
            GetTreeView().SelectedItems.Clear();

            foreach (ListViewItem viewItem in GetTreeView().Items)
            {
                var itemBuildInfo = viewItem.Tag as BuildInfo;

                ListViewItem item = viewItem;
                builds.ForEach(buildsToSelect =>
                {
                    bool isEqual;
                    if (IsQueuedSelected)
                    {
                        IQueuedBuild itemBuild = itemBuildInfo.queuedBuild;
                        IQueuedBuild queuedBuild = buildsToSelect.queuedBuild;
                        //IBuildDetail buildDetail = queuedBuild.Build;

                        isEqual = itemBuild.BuildAgentUri.ToString() == queuedBuild.BuildAgentUri.ToString() &&
                            itemBuild.BuildDefinitionUri.ToString() == queuedBuild.BuildDefinitionUri.ToString() &&
                                itemBuild.BuildServer.TeamFoundationServer.InstanceId
                                    == queuedBuild.BuildServer.TeamFoundationServer.InstanceId &&
                                        itemBuild.CommandLineArguments == queuedBuild.CommandLineArguments &&
                                            itemBuild.RequestedBy == queuedBuild.RequestedBy &&
                                                itemBuild.RequestedFor == queuedBuild.RequestedFor;
                    }
                    else
                    {
                        IBuildDetail itemBuild = itemBuildInfo.buildDetail;
                        IBuildDetail buildDetail = buildsToSelect.buildDetail;

                        isEqual = false;

                        if (buildDetail != null)
                        {
                            isEqual = itemBuild.BuildAgentUri.ToString() == buildDetail.BuildAgentUri.ToString() &&
                                itemBuild.BuildDefinitionUri.ToString() == buildDetail.BuildDefinitionUri.ToString() &&
                                    itemBuild.BuildServer.TeamFoundationServer.InstanceId
                                        == buildDetail.BuildServer.TeamFoundationServer.InstanceId &&
                                            itemBuild.CommandLineArguments == buildDetail.CommandLineArguments &&
                                                itemBuild.Quality == buildDetail.Quality &&
                                                    itemBuild.Reason == buildDetail.Reason &&
                                                        itemBuild.RequestedBy == buildDetail.RequestedBy &&
                                                            itemBuild.RequestedFor == buildDetail.RequestedFor &&
                                                                itemBuild.StartTime == buildDetail.StartTime &&
                                                                    itemBuild.TestStatus == buildDetail.TestStatus &&
                                                                        itemBuild.Uri.ToString()
                                                                            == buildDetail.Uri.ToString();
                        }
                    }

                    if (isEqual)
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
*/
        }

        private void SelectBuildsByBuildNumber(string buildNumber, bool canCreateNewSearch)
        {
            GetTreeView().SelectedItems.Clear();

            Func<ListViewItem> findFunc = () =>
                {
                    ListViewItem result = null;

                    foreach (ListViewItem viewItem in GetTreeView().Items)
                    {
                        var itemBuild = viewItem.Tag as BuildInfo;
                        IBuildDetail buildDetail = IsQueuedSelected ? itemBuild.queuedBuild.Build : itemBuild.buildDetail;

                        if (buildDetail.BuildNumber == buildNumber)
                        {
                            if (result == null || viewItem.Position.Y < result.Position.Y)
                            {
                                result = viewItem;
                            }
                            viewItem.Selected = true;
                        }
                    }

                    return result;
                };


            ListViewItem topItem = findFunc();
            if (topItem == null && canCreateNewSearch)
            {
                PopulateTeamBuilds(true, true, spec => spec.BuildNumber = buildNumber);
                topItem = findFunc();
            }

            if (topItem != null)
            {
                topItem.Focused = true;
                topItem.EnsureVisible();
            }
        }

        private void mniViewLogFile_Click(object sender, EventArgs e)
        {
            var buildDetail = this.lvTeamBuilds.SelectedItems[0].Tag as BuildInfo;
            bool fileExists = !string.IsNullOrEmpty(buildDetail.buildDetail.LogLocation) && File.Exists(buildDetail.buildDetail.LogLocation);

            if (fileExists)
            {
                Process.Start("notepad", buildDetail.buildDetail.LogLocation);
            }
            else
            {
                MessageBox.Show("Specified team build does not have log file!", "Show log file", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        public void FocusAndSelectTeamBuild(IQueuedBuild queuedBuild)
        {
            ChangeFilterBuilds(true);
            SelectBuildByCompare(new BuildInfo(queuedBuild));
        }

        public void FocusAndSelectTeamBuild(string buildNumber)
        {
            ChangeFilterBuilds(false);
            SelectBuildsByBuildNumber(buildNumber, true);
        }

        private void mniGotoDefinition_Click(object sender, EventArgs e)
        {
            var itemBuild = GetTreeView().SelectedItems[0].Tag as BuildInfo;
            IBuildDetail buildDetail = IsQueuedSelected ? itemBuild.queuedBuild.Build : itemBuild.buildDetail;
            IBuildDefinition definition = Context.BuildServer.GetBuildDefinition(buildDetail.BuildDefinition.Uri);

            //this.parentControl.FocusAndSelectBuildTemplate(definition);
            UIContext.Instance.ControlTeamBuilds.FocusAndSelectBuildTemplate(definition);
        }

        private void mniBuildDetail_Click(object sender, EventArgs e)
        {
            var itemBuild = GetTreeView().SelectedItems[0].Tag as BuildInfo;
            IBuildDetail buildDetail = IsQueuedSelected ? itemBuild.queuedBuild.Build : itemBuild.buildDetail;
            FormBuildDetail.DialogShow(buildDetail);
        }

        private void lvTeamBuilds_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (GetTreeView().SelectedItems.Count != 1)
            {
                return;
            }

            mniBuildDetail_Click(sender, e);
        }

        private bool IsQueuedSelected 
        {
            get
            {
                return btnQueued.Checked;
            }
        }

        private bool stopfilterChanges = false;
        private int COLUNN_STATUS = 0;
        private int COLUNN_STARTED = 1;
        private int COLUNN_BUILDNUMBER = 2;
        private int COLUNN_DEFINITION = 3;
        private int COLUNN_AGENT = 4;
        private int COLUNN_REQUESTEDBY = 5;
        private int COLUNN_QUALITY = 6;
        private int COLUNN_FINISHTIME = 7;

        private int COLUNN2_DEFINITION = 0;
        private int COLUNN2_PRIORITY = 1;
        private int COLUNN2_DATEQUEUED = 2;
        private int COLUNN2_REQUESTEDBY = 3;

        private void FilterBuilds_Click(object sender, EventArgs e)
        {
            if (stopfilterChanges) return;

            string action = (sender as ToolStripButton).Tag as string;

            stopfilterChanges = true;
            try
            {
                if (action == "0")
                {
                    btnQueued.Checked = !btnQueued.Checked;
                    btnCompleted.Checked = !btnQueued.Checked;
                }
                else
                {
                    btnCompleted.Checked = !btnCompleted.Checked;
                    btnQueued.Checked = !btnCompleted.Checked;
                }

                btnLatestBuilds.Visible = btnCompleted.Checked;

                lvTeamBuilds.Visible = btnCompleted.Checked;
                lvTeamBuilds.Dock = btnCompleted.Checked ? DockStyle.Fill : DockStyle.None;
                lvTeamBuildsQueued.Visible = btnQueued.Checked;
                lvTeamBuildsQueued.Dock = btnQueued.Checked ? DockStyle.Fill : DockStyle.None;

                PopulateTeamBuilds(false, true, null);
            }
            finally
            {
                lastIsQueuedSelected = btnQueued.Checked;
                stopfilterChanges = false;
            }
        }

        public void ChangeFilterBuilds(bool queued)
        {
            FilterBuilds_Click(queued ? btnQueued : btnCompleted, EventArgs.Empty);
        }

        private void btnLatestBuilds_Click(object sender, EventArgs e)
        {
            PopulateTeamBuilds(true, true, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string teamProject = UIContext.Instance.ControlTeamBuildFilter.CheckedProjects[0];
            IBuildDetailSpec buildDetailSpec = Context.BuildServer.CreateBuildDetailSpec(teamProject);
            buildDetailSpec.BuildNumber = toolStripTextBox1.Text;
            var buildQueryResult = Context.BuildServer.QueryBuilds(buildDetailSpec);
        }
    }
}