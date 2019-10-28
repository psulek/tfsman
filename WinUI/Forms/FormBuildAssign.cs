using System;
using System.Windows.Forms;
using System.Xml;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Core;

namespace TFSManager.Forms
{
    public partial class FormBuildAssign: Form
    {
        private const string BUILD_DETAIL_MASK =
            @"
Team foundation server:         {0}
Team project:                   {1}
Build number:                   {13}
Build agent:                    {2}
Build agent uri:                {3}
Build definition:               {4}
Build definition uri:           {5}
Build server:                   {6}
Drop location:                  {7}
Finish time:                    {8}
Label name:                     {9}
Quality:                        {10}
Status:                         {11}
Requested By:                   {12}";

        private static FormBuildAssign _form;

        private bool multiSelect;
        private string teamProject;

        public FormBuildAssign()
        {
            InitializeComponent();
        }

        internal string SelectedBuild1
        {
            get
            {
                return this.llAssign1.Text;
            }
        }

        internal string SelectedBuild2
        {
            get
            {
                return this.llAssign2.Text;
            }
        }

        public static bool DialogShow(string teamProject, bool contains_BuildIn, string foundIn,
            bool contains_IntegrationBuild,
            string integrationBuild, bool multiSelect, out string selectedBuild1, out string selectedBuild2)
        {
            if (_form == null)
            {
                _form = new FormBuildAssign();
            }

            _form.UpdateProject(teamProject, contains_BuildIn, foundIn, contains_IntegrationBuild,
                integrationBuild, multiSelect);

            bool result = _form.ShowDialog() == DialogResult.OK;

            if (result)
            {
                selectedBuild1 = _form.SelectedBuild1;
                selectedBuild2 = _form.SelectedBuild2;
            }
            else
            {
                selectedBuild1 = null;
                selectedBuild2 = null;
            }

            return result;
        }

        internal void UpdateProject(string teamProject, bool contains_BuildIn, string foundIn,
            bool contains_IntegrationBuild, string integrationBuild, bool multiSelect)
        {
            this.multiSelect = multiSelect;
            this.teamProject = teamProject;
            //            this.llAssign1.Text = contains_BuildIn
            //                ? foundIn != FormMain.BUILD_NONE ? foundIn : string.Empty : string.Empty;
            this.llAssign1.Text = contains_BuildIn ? foundIn : string.Empty;
            this.llSet1.Enabled = contains_BuildIn || multiSelect;
            this.llClear1.Enabled = contains_BuildIn || multiSelect;

            //            this.llAssign2.Text = contains_IntegrationBuild
            //                ? integrationBuild != FormMain.BUILD_NONE ? integrationBuild : string.Empty : string.Empty;
            this.llAssign2.Text = contains_IntegrationBuild ? integrationBuild : string.Empty;
            this.llSet2.Enabled = contains_IntegrationBuild || multiSelect;
            this.llClear2.Enabled = contains_IntegrationBuild || multiSelect;

            this.lbCaption.Text = string.Format("Allowed team '{0}' builds:", teamProject);

            XmlNode ownerNode =
                Context.GlobalLists.DocumentElement.SelectSingleNode(string.Format("//GLOBALLIST[@name='Builds - {0}']",
                    teamProject));
            this.cmbBuilds.Items.Clear();
            this.cmbBuilds.Items.Add(Context.BUILD_NONE);
            if (ownerNode != null)
            {
                foreach (XmlNode node in ownerNode.ChildNodes)
                {
                    string value = node.Attributes["value"].Value;
                    if (value.ToLower() != Context.BUILD_NONE.ToLower())
                    {
                        this.cmbBuilds.Items.Add(value);
                    }
                }
            }

            this.cmbBuilds.SelectedIndex = -1;
            this.lbBuild.Text = string.Empty;
        }

        private IBuildDetail GetBuildDetail(string buildId)
        {
            if (buildId == Context.BUILD_NONE)
            {
                return null;
            }

            IBuildDetailSpec buildDetailSpec = Context.BuildServer.CreateBuildDetailSpec(this.teamProject);
            buildDetailSpec.BuildNumber = buildId;
            IBuildQueryResult buildQueryResult = Context.BuildServer.QueryBuilds(buildDetailSpec);
            IBuildDetail buildDetail = buildQueryResult.Builds[0];
            bool queueBuild = false;
//            if (queueBuild)
//            {
//                IBuildRequest request = buildDetail.BuildDefinition.CreateBuildRequest();
//                request.Priority = QueuePriority.AboveNormal;
//                request.CommandLineArguments = "/p:ExtParamA=\"Toto je test\"";
//                Context.BuildServer.QueueBuild(request);
//            }
            return buildDetail;
        }

        private void cmbBuilds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbBuilds.SelectedIndex == -1)
            {
                return;
            }

            IBuildDetail buildInfo = GetBuildDetail(this.cmbBuilds.SelectedItem as string);
            this.lbBuild.Text = buildInfo == null ? string.Empty :
                                                                     string.Format(BUILD_DETAIL_MASK,
                                                                         buildInfo.BuildServer.TeamFoundationServer,
                                                                         this.teamProject,
                                                                         string.Empty, //buildInfo.BuildAgent.Name,
                                                                         string.Empty, //buildInfo.BuildAgentUri,
                                                                         buildInfo.BuildDefinition,
                                                                         buildInfo.BuildDefinitionUri,
                                                                         buildInfo.BuildServer,
                                                                         buildInfo.DropLocation,
                                                                         buildInfo.FinishTime,
                                                                         buildInfo.LabelName,
                                                                         buildInfo.Quality,
                                                                         buildInfo.Status,
                                                                         buildInfo.RequestedBy,
                                                                         buildInfo.BuildNumber
                                                                         );
        }

        private void Set_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.cmbBuilds.SelectedIndex == -1)
            {
                return;
            }

            var btn = sender as LinkLabel;
            var action = btn.Tag as string;

            if (action == "0")
            {
                this.llAssign1.Text = this.cmbBuilds.SelectedItem as string;
            }
            else
            {
                this.llAssign2.Text = this.cmbBuilds.SelectedItem as string;
            }
        }

        private void Clear_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var btn = sender as LinkLabel;
            var action = btn.Tag as string;

            this.cmbBuilds.SelectedIndex = 0;

            if (action == "0")
            {
                this.llAssign1.Text = this.cmbBuilds.SelectedItem as string;
            }
            else
            {
                this.llAssign2.Text = this.cmbBuilds.SelectedItem as string;
            }
        }

        private void NavigateTo_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var btn = sender as LinkLabel;

            int idx = this.cmbBuilds.FindStringExact(btn.Text);
            if (idx > -1)
            {
                this.cmbBuilds.SelectedIndex = idx;
            }
        }
    }
}