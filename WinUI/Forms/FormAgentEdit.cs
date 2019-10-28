using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Server;

using TFSManager.Core;
using TFSManager.Core.WinForms;

namespace TFSManager.Forms
{
    public partial class FormAgentEdit: Form
    {
        private IBuildAgent agent;
        private FormActionMode mode;

        public FormAgentEdit()
        {
            InitializeComponent();

            Array names = Enum.GetValues(typeof(AgentStatus));
            foreach (AgentStatus name in names)
            {
                if (name == AgentStatus.Unavailable)
                {
                    continue;
                }

                this.cmbStatus.Items.Add(name.ToString());
            }

            Dictionary<string, ProjectInfo> projects = Context.GetSortedProjects();
            foreach (var project in projects)
            {
                this.cmbTeamProject.Items.Add(project.Key);
            }
        }

        private void Initialize()
        {
            int teamProjectIndex = -1;
            if (this.agent != null && this.mode != FormActionMode.Copy)
            {
                teamProjectIndex = this.cmbTeamProject.FindStringExact(this.agent.TeamProject);
            }
            this.cmbTeamProject.SelectedIndex = teamProjectIndex;
            this.cmbTeamProject.Enabled = (this.mode == FormActionMode.New || this.mode == FormActionMode.Copy);

            bool canEdit = (this.mode != FormActionMode.View);

            if (this.mode == FormActionMode.New)
            {
                this.agent = null;
            }

            this.edName.Text = this.agent != null ? this.agent.Name : string.Empty;
            this.edName.ReadOnly = !canEdit;

            this.edDescription.Text = this.agent != null ? this.agent.Description : string.Empty;
            this.edDescription.ReadOnly = !canEdit;

            this.edMachineName.Text = this.agent != null ? this.agent.MachineName : string.Empty;
            this.edMachineName.ReadOnly = !canEdit;

//            this.edPort.Text = this.agent != null ? this.agent.Port.ToString() : "9191";
//            this.edPort.ReadOnly = !canEdit;

            this.chRequireSecureChannel.Checked = this.agent != null ? this.agent.RequireSecureChannel : false;
            this.chRequireSecureChannel.Enabled = canEdit;

            this.edBuildDirectory.Text = this.agent != null
                ? this.agent.BuildDirectory : @"$(Temp)\$(BuildDefinitionPath)";
            this.edBuildDirectory.ReadOnly = !canEdit;

            this.cmbStatus.SelectedIndex = this.agent != null
                ? GetStatusIdx(this.agent.Status) : GetStatusIdx(AgentStatus.Available);
            this.cmbStatus.Enabled = canEdit;

            this.lbQueueCount.Text = string.Format("{0} builds in queue", this.agent != null ? this.agent.QueueCount : 0);

            /*this.edMaxProcesses.Value = this.agent != null ? this.agent.MaxProcesses : 1;
            this.edMaxProcesses.ReadOnly = !canEdit;
            this.edMaxProcesses.Enabled = canEdit;*/
        }

        private int GetStatusIdx(AgentStatus status)
        {
            return this.cmbStatus.FindStringExact(status.ToString());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var messages = new List<string>();

            if (this.cmbTeamProject.SelectedIndex == -1)
            {
                messages.Add("Team project must be selected!");
            }

            if (this.edName.Text == string.Empty)
            {
                messages.Add("Display name cannot be empty!");
            }

            if (this.edMachineName.Text == string.Empty)
            {
                messages.Add("Computer name cannot be empty!");
            }

            if (this.edPort.Text == string.Empty)
            {
                messages.Add("Communication port cannot be empty!");
            }
            else
            {
                int port;
                if (!int.TryParse(this.edPort.Text, out port))
                {
                    messages.Add("Communication port must be a number");
                }
            }

            if (this.edBuildDirectory.Text == string.Empty)
            {
                messages.Add("Working directory cannot be empty!");
            }

            if (messages.Count > 0)
            {
                var message = new StringBuilder();
                messages.ForEach(s => message.AppendFormat("? {0}\n\r", s));

                MessageBox.Show(message.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }

        private void FormAgentEdit_Shown(object sender, EventArgs e)
        {
            switch (this.mode)
            {
                case FormActionMode.New:
                case FormActionMode.Copy:
                case FormActionMode.View:
                {
                    this.cmbTeamProject.Select();
                    this.cmbTeamProject.Focus();
                    break;
                }
                case FormActionMode.Edit:
                {
                    this.edName.Select();
                    this.edName.Focus();
                    break;
                }
            }
        }

        #region DialogShow

        private static FormAgentEdit form;

        public static IBuildAgent DialogShow(IBuildAgent agent, FormActionMode mode)
        {
            IBuildAgent result = null;

            if (form == null)
            {
                form = new FormAgentEdit();
            }

            form.agent = agent;
            form.mode = mode;
            form.Initialize();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.mode != FormActionMode.View)
                {
                    result = new TempBuildAgent();
                    (result as TempBuildAgent).TeamProject = form.cmbTeamProject.SelectedItem as string;
                    result.Name = form.edName.Text;
                    result.Description = form.edDescription.Text;
                    result.MachineName = form.edMachineName.Text;
                    //result.Port = Convert.ToInt32(form.edPort.Text);
                    result.RequireSecureChannel = form.chRequireSecureChannel.Checked;
                    result.BuildDirectory = form.edBuildDirectory.Text;
                    result.Status = (AgentStatus) Enum.Parse(typeof(AgentStatus), form.cmbStatus.SelectedItem as string);
                    //result.MaxProcesses = (int) form.edMaxProcesses.Value;
                }
            }

            return result;
        }

        #endregion
    }
}