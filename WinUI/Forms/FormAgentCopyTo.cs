using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Server;

using TFSManager.Core;
using TFSManager.Core.WinForms;

namespace TFSManager.Forms
{
    public partial class FormAgentCopyTo: Form
    {
        private static FormAgentCopyTo form = null;
        private IBuildAgent newBuildAgent;
        private IBuildAgent sourceBuildAgent;

        public FormAgentCopyTo()
        {
            InitializeComponent();
        }

        private string SelectedTargetTeamProject
        {
            get
            {
                return this.cmbTargetTeamProject.SelectedItem as string;
            }
        }

        private void Initialize()
        {
            this.btnCopy.Enabled = false;
            this.cmbTargetTeamProject.Items.Clear();
            Dictionary<string, ProjectInfo> teamProjects = Context.GetSortedProjects();
            string sourceTeamBuild = this.sourceBuildAgent.TeamProject.ToLower();
            foreach (var teamProject in teamProjects)
            {
                if (teamProject.Key.ToLower() != sourceTeamBuild)
                {
                    this.cmbTargetTeamProject.Items.Add(teamProject.Key);
                }
            }

            this.lbSourceTeamProject.Text = string.Format("Team project: {0}", this.sourceBuildAgent.TeamProject);
            this.lbSourceBuildAgent.Text = string.Format("Build agent: {0}", this.sourceBuildAgent.Name);

            this.newBuildAgent = new TempBuildAgent(this.sourceBuildAgent);
        }

        public static bool DialogShow(IBuildAgent sourceBuildAgent, out IBuildAgent copiedBuildAgent)
        {
            if (form == null)
            {
                form = new FormAgentCopyTo();
            }

            form.sourceBuildAgent = sourceBuildAgent;
            form.Initialize();

            copiedBuildAgent = null;
            bool result = form.ShowDialog() == DialogResult.OK;

            if (result)
            {
                copiedBuildAgent = form.newBuildAgent;
            }

            return result;
        }

        private void UpdateButtons()
        {
            this.btnCopy.Enabled = (this.cmbTargetTeamProject.SelectedIndex > -1);
        }

        private void cmbTargetTeamProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
/*
            string caption = "Copy build agent";
            if (MessageBox.Show(string.Format("Do you really want to copy agent to target team project '{0}' ?",
                SelectedTargetTeamProject), caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }


            var targetAgents = new List<IBuildAgent>(Context.BuildServer.QueryBuildAgents(SelectedTargetTeamProject));
            IBuildAgent foundAgent = targetAgents.Find(delegate(IBuildAgent agent)
            {
                return ((string.Compare(agent.Name, this.sourceBuildAgent.Name, true) == 0) ||
                    ((string.Compare(agent.MachineName, this.sourceBuildAgent.MachineName, true) == 0) &&
                        (agent.Port == this.sourceBuildAgent.Port)));
            });

            if (foundAgent != null)
            {
                MessageBox.Show(
                    string.Format(
                        "Cannot copy build agent to specified target team project '{0}', similar agent already exists on target team project!",
                        SelectedTargetTeamProject), caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                IBuildAgent targetBuildAgent = Context.BuildServer.CreateBuildAgent(SelectedTargetTeamProject);
                TempBuildAgent.AssingTo(this.newBuildAgent, targetBuildAgent);
                try
                {
                    Context.BuildServer.SaveBuildAgents(new[] {targetBuildAgent});
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Copy build agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    try
                    {
                        Context.BuildServer.DeleteBuildAgents(new[] {targetBuildAgent});
                    }
                    catch {}
                    finally
                    {
                        targetBuildAgent = null;
                    }
                }

                if (targetBuildAgent != null)
                {
                    this.newBuildAgent = targetBuildAgent;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
*/
        }

        private void linkAgentDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IBuildAgent editedAgent = FormAgentEdit.DialogShow(this.newBuildAgent, FormActionMode.Edit);
            if (editedAgent != null)
            {
                TempBuildAgent.AssingTo(editedAgent, this.newBuildAgent);
            }
        }

        private void linkSourceAgentDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAgentEdit.DialogShow(this.sourceBuildAgent, FormActionMode.View);
        }
    }
}