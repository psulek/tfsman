using System;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Core;
using TFSManager.Core.WinForms;

namespace TFSManager.Controls
{
    public partial class ControlTeamBuilds : UserControl, IControlTeamBuilds
    {
        //internal readonly List<string> selectedProjects = new List<string>();
        private bool blockSelectedChange = false;
        private int lastSelectedTeamProject = -1;
        //internal int selectedTeamProjectIndex;

        public ControlTeamBuilds()
        {
            InitializeComponent();

            Initialize();
        }

        #region class ListViewSortInfo

        #endregion

        internal void Initialize()
        {
            //this.cmbTeamProjects.Items.Clear();
            Enabled = Context.IsConnected;
            if (!Context.IsConnected)
            {
                return;
            }

//            this.cmbTeamProjects.Items.Add("All projects");
//            Dictionary<string, ProjectInfo> allProjects = Context.GetSortedProjects();
//            foreach (var project in allProjects)
//            {
//                this.cmbTeamProjects.Items.Add(project.Key);
//            }

            this.controlAgents.Dock = DockStyle.Fill;
            this.controlAgents.Visible = false;
            this.controlAgents.Initialize();

            this.controlDefinitions.Dock = DockStyle.Fill;
            this.controlDefinitions.Visible = false;
            this.controlDefinitions.Initialize();

            this.controlBuilds.Dock = DockStyle.Fill;
            this.controlBuilds.Visible = false;
            this.controlBuilds.Initialize();

//            this.blockSelectedChange = true;
//            try
//            {
//                this.cmbTeamProjects.SelectedIndex = 0;
//            }
//            finally
//            {
//                this.blockSelectedChange = false;
//            }

            this.controlTeamBuildFilterPanel.Initialize(this, OnTeamProjectFilterApply);
        }

        private void OnTeamProjectFilterApply(string[] strings)
        {
            PopulateSelectedList(true, true);
        }

        private void SynchroTeamProjectText(object sender, EventArgs e)
        {
//            if (!string.IsNullOrEmpty(this.cmbTeamProjects.Text))
//            {
//                int idx = this.cmbTeamProjects.FindStringExact(this.cmbTeamProjects.Text);
//                if (idx > -1)
//                {
//                    this.cmbTeamProjects.Text = this.cmbTeamProjects.Items[idx] as string;
//                }
//                else
//                {
//                    this.cmbTeamProjects.SelectedIndex = this.lastSelectedTeamProject;
//                }
//            }
        }

        private void cmbTeamProjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SynchroTeamProjectText(sender, e);
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var selectedButton = sender as ToolStripButton;
            if (selectedButton.Checked)
            {
                return;
            }

            var selectedButtonId = selectedButton.Tag as string;
            ToolStripButton[] otherButtons;

            if (selectedButtonId == "0")
            {
                otherButtons = new[] {this.btnBuildDefinitions, this.btnTeamBuilds};
            }
            else if (selectedButtonId == "1")
            {
                otherButtons = new[] {this.btnBuildAgents, this.btnTeamBuilds};
            }
            else
            {
                otherButtons = new[] {this.btnBuildAgents, this.btnBuildDefinitions};
            }

            selectedButton.Checked = true;
            otherButtons[0].Checked = false;
            otherButtons[1].Checked = false;

            PopulateSelectedList();
        }

/*
        private void cmbTeamProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.selectedProjects.Clear();

            if (this.cmbTeamProjects.SelectedIndex == 0)
            {
                UIContext.Instance.ControlTeamBuildFilter.CheckAllProjects();
                //UIContext.Instance.ControlTeamBuildFilter.ApplyFilter();
            }
            else
            {
                string selectItem = this.cmbTeamProjects.SelectedItem as string;
                UIContext.Instance.ControlTeamBuildFilter.ClearFilter();
                UIContext.Instance.ControlTeamBuildFilter.CheckProject(selectItem, true);
                //UIContext.Instance.ControlTeamBuildFilter.ApplyFilter();
            }

            this.lastSelectedTeamProject = this.cmbTeamProjects.SelectedIndex;

            if (this.blockSelectedChange)
            {
                return;
            }

            UIContext.Instance.ControlTeamBuildFilter.ApplyFilter();
        }
*/

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateSelectedList(true, true);
        }

        internal void EnsureSelectedTeamProject(string teamProject)
        {
            EnsureSelectedTeamProject(teamProject, true);
        }

        internal void EnsureSelectedTeamProject(string teamProject, bool blockApplyFilter)
        {
            EnsureSelectedTeamProject(teamProject, true, blockApplyFilter);
        }

        internal void EnsureSelectedTeamProject(string teamProject, bool changeIfNonAllSelect, bool blockApplyFilter)
        {
            bool isCheckedProject = UIContext.Instance.ControlTeamBuildFilter.IsCheckedProject(teamProject);
            if (!isCheckedProject)
            {
                UIContext.Instance.ControlTeamBuildFilter.CheckProject(teamProject, true);
                if (!blockApplyFilter)
                {
                    UIContext.Instance.ControlTeamBuildFilter.ApplyFilter();
                }
            }

/*
            // if selected team project other than 'All projects' then we must check if newBuildAgent
            // has assigned equal team project as is selected in combobox)
            if ((this.cmbTeamProjects.SelectedIndex > 0 && changeIfNonAllSelect) || (!changeIfNonAllSelect))
            {
                var selectedTeamProject = this.cmbTeamProjects.SelectedItem as string;
                if (string.Compare(teamProject, selectedTeamProject, true) != 0)
                {
                    int itemIndex = this.cmbTeamProjects.FindStringExact(teamProject);

                    if (blockApplyFilter)
                    {
                        this.blockSelectedChange = true;
                    }

                    try
                    {
                        this.cmbTeamProjects.SelectedIndex = itemIndex;
                    }
                    finally
                    {
                        if (blockApplyFilter)
                        {
                            this.blockSelectedChange = false;
                        }
                    }
                }
            }
*/
        }

        public IControlTeamBuildFilter ControlTeamBuildFilter
        {
            get { return controlTeamBuildFilterPanel; }
        }

        public IControlTeamBuildList ControlTeamBuildList
        {
            get { return controlBuilds; }
        }

        public void FocusAndSelectTeamBuild(IQueuedBuild queuedBuild)
        {
            EnsureSelectedTeamProject(queuedBuild.BuildDefinition.TeamProject, false);
            ButtonClick(this.btnTeamBuilds, EventArgs.Empty);

            ControlTeamBuildList.FocusAndSelectTeamBuild(queuedBuild);
        }

        public void FocusAndSelectTeamBuild(string teamProject, string buildNumber)
        {
            EnsureSelectedTeamProject(teamProject, false, false);
            ButtonClick(this.btnTeamBuilds, EventArgs.Empty);

            ControlTeamBuildList.FocusAndSelectTeamBuild(buildNumber);
        }

        public void FocusAndSelectBuildTemplate(IBuildDefinition definition)
        {
            EnsureSelectedTeamProject(definition.TeamProject, false);
            ButtonClick(this.btnBuildDefinitions, EventArgs.Empty);

            this.controlDefinitions.FocusAndSelectDefinition(definition);
        }

        public void FocusAndSelectBuildTemplate(BuildTemplate buildTemplate)
        {
            EnsureSelectedTeamProject(buildTemplate.TeamProject, false);
            ButtonClick(this.btnBuildDefinitions, EventArgs.Empty);

            this.controlDefinitions.FocusAndSelectBuildTemplate(buildTemplate);
        }

        

        #region populate lists

        private void PopulateSelectedList()
        {
            PopulateSelectedList(false, true);
        }

        private void PopulateSelectedList(bool refresh, bool resort)
        {
            this.controlAgents.Visible = false;
            this.controlDefinitions.Visible = false;
            this.controlBuilds.Visible = false;

            Cursor = Cursors.WaitCursor;

            try
            {
                if (this.btnBuildAgents.Checked)
                {
                    this.controlAgents.Visible = true;
                    this.controlAgents.PopulateBuildAgents(refresh, resort);
                }
                else if (this.btnBuildDefinitions.Checked)
                {
                    this.controlDefinitions.Visible = true;
                    this.controlDefinitions.PopulateBuildDefinitions(refresh, resort, true);
                }
                else if (this.btnTeamBuilds.Checked)
                {
                    this.controlBuilds.Visible = true;
                    this.controlBuilds.PopulateTeamBuilds(refresh, resort, null);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion

    }
}