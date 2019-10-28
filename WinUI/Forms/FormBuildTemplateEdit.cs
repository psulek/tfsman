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
    public partial class FormBuildTemplateEdit: Form
    {
        private static FormBuildTemplateEdit form;
        private IBuildDefinition buildDefinition;
        private List<IBuildController> cached_buildControllers;
        private List<IBuildDefinition> cached_buildDefinitions;
        private BuildTemplate editTemplate;
        private FormActionMode mode;
        private bool stopTeamProjectChanges = false;

        public FormBuildTemplateEdit()
        {
            InitializeComponent();

            Dictionary<string, ProjectInfo> projects = Context.GetSortedProjects();
            foreach (var project in projects)
            {
                this.cmbTeamProject.Items.Add(project.Key);
            }

            Array names = Enum.GetValues(typeof(QueuePriority));
            foreach (QueuePriority name in names)
            {
                this.cmbPriority.Items.Add(name.ToString());
            }
        }

        private string SelectedBuildController
        {
            get
            {
                IBuildController find = this.cached_buildControllers.Find(controller =>
                {
                    return controller.Name == this.cmbBuildController.SelectedItem as string;
                });

                return find != null ? find.Name : null;
            }
        }

        private string SelectedBuildControllerUri
        {
            get
            {
                IBuildController find = this.cached_buildControllers.Find(controller =>
                {
                    return controller.Name == this.cmbBuildController.SelectedItem as string;
                });

                return find != null ? find.Uri.ToString() : null;
            }
        }

        private string SelectedDefinitionName
        {
            get
            {
                IBuildDefinition find = this.cached_buildDefinitions.Find(definition =>
                {
                    return definition.Name == this.cmbBuildDefinition.SelectedItem as string;
                });

                return find != null ? find.Name : string.Empty;
            }
        }

        public static BuildTemplate DialogShow(BuildTemplate editTemplate, IBuildDefinition buildDefinition,
            FormActionMode mode)
        {
            bool saveChanges;
            return DialogShow(editTemplate, buildDefinition, mode, out saveChanges);
        }

        public static BuildTemplate DialogShow(BuildTemplate editTemplate, IBuildDefinition buildDefinition,
            FormActionMode mode, out bool saveChanges)
        {
            if (form == null)
            {
                form = new FormBuildTemplateEdit();
            }

            if (mode == FormActionMode.New)
            {
                editTemplate = new BuildTemplate(buildDefinition);
            }
            else
            {
                editTemplate = editTemplate.Clone();
            }

            form.editTemplate = editTemplate;
            form.buildDefinition = buildDefinition;
            form.mode = mode;
            form.Initialize();

            BuildTemplate result = null;

            saveChanges = false;

            if (form.ShowDialog() == DialogResult.OK)
            {
                editTemplate.TemplateName = form.edName.Text;
                editTemplate.Description = form.edDescription.Text;
                editTemplate.TeamProject = form.cmbTeamProject.SelectedItem as string;
                editTemplate.DefinitionName = form.SelectedDefinitionName;
                editTemplate.BuildControllerName = form.SelectedBuildController;
                editTemplate.BuildControllerUri = form.SelectedBuildControllerUri;
                editTemplate.DefaultDropLocation = form.edDropFolder.Text;
                editTemplate.RunPriority =
                    (QueuePriority) Enum.Parse(typeof(QueuePriority), form.cmbPriority.SelectedItem as string, true);
                editTemplate.CommandLineArguments = form.edCmdArgs.Text;
                editTemplate.Postponed = form.chPostponed.Checked;

                result = editTemplate;
                saveChanges = form.chSaveChanges.Checked;
            }

            return result;
        }

        private void Initialize()
        {
            this.edName.Text = this.mode == FormActionMode.New ? buildDefinition.Name : this.editTemplate.TemplateName;
            this.edName.ReadOnly = this.mode == FormActionMode.View;
            this.edDescription.Text = this.mode == FormActionMode.New ? string.Empty : this.editTemplate.Description;
            this.edDescription.ReadOnly = this.mode == FormActionMode.View;

            int teamProjectIndex = this.cmbTeamProject.FindStringExact(this.editTemplate.TeamProject);
            this.stopTeamProjectChanges = true;
            try
            {
                this.cmbTeamProject.SelectedIndex = teamProjectIndex;
            }
            finally
            {
                this.stopTeamProjectChanges = false;
            }

            this.edDropFolder.Text = this.editTemplate.DefaultDropLocation;
            int priorityIndex = this.cmbPriority.FindStringExact(this.editTemplate.RunPriority.ToString());
            this.cmbPriority.SelectedIndex = priorityIndex;

            this.edCmdArgs.Text = this.editTemplate.CommandLineArguments;
            this.chPostponed.Checked = this.editTemplate.Postponed;

            PopulateBuilDefinitions();
            PopulateBuildControllers();

            this.btnOk.Text = this.mode == FormActionMode.View ? "Queue" : "OK";
            this.chSaveChanges.Visible = this.mode == FormActionMode.View;

            this.chSaveChanges.Checked = false;
        }

        private void cmbTeamProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.stopTeamProjectChanges)
            {
                return;
            }

            PopulateBuilDefinitions();
            PopulateBuildControllers();
        }

        private void PopulateBuilDefinitions()
        {
            this.cmbBuildDefinition.Items.Clear();

            if (this.cmbTeamProject.SelectedIndex > -1)
            {
                this.cached_buildDefinitions =
                    new List<IBuildDefinition>(
                        Context.BuildServer.QueryBuildDefinitions(this.cmbTeamProject.SelectedItem as string));
                foreach (IBuildDefinition definition in this.cached_buildDefinitions)
                {
                    this.cmbBuildDefinition.Items.Add(definition.Name);
                }
            }

            int definitionIndex = this.cmbBuildDefinition.FindStringExact(this.editTemplate.DefinitionName);
            this.cmbBuildDefinition.SelectedIndex = definitionIndex;
        }

        private void PopulateBuildControllers()
        {
            this.cmbBuildController.Items.Clear();

            this.cached_buildControllers = new List<IBuildController>(Context.BuildServer.QueryBuildControllers());
            foreach (var buildController in this.cached_buildControllers)
            {
                this.cmbBuildController.Items.Add(buildController.Name);
            }

            int idx = this.cmbBuildController.FindStringExact(this.editTemplate.BuildControllerName);
            this.cmbBuildController.SelectedIndex = idx;

/*
            IBuildController[] queryBuildControllers = Context.BuildServer.QueryBuildControllers();

            if (this.cmbTeamProject.SelectedIndex > -1)
            {
                this.cached_buildController =
                    new List<IBuildAgent>(Context.BuildServer.QueryBuildAgents(this.cmbTeamProject.SelectedItem as string));
                foreach (IBuildAgent agent in this.cached_buildController)
                {
                    this.cmbBuildAgent.Items.Add(agent.Name);
                }
            }

            int agentIndex = this.cmbBuildAgent.FindStringExact(this.editTemplate.BuildAgentName);
            this.cmbBuildAgent.SelectedIndex = agentIndex;
*/
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
                messages.Add("Template name cannot be empty!");
            }

            if (this.edDropFolder.Text == string.Empty)
            {
                messages.Add("Default drop folder cannot be empty!");
            }

            if (messages.Count > 0)
            {
                var message = new StringBuilder();
                messages.ForEach(s => message.AppendFormat("? {0}\n\r", s));

                MessageBox.Show(message.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }

        private void FormBuildTemplateEdit_Shown(object sender, EventArgs e)
        {
            this.edName.Select();
            this.edName.Focus();
        }

        private void linkBuildDefinition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.cmbBuildDefinition.SelectedIndex == -1)
            {
                return;
            }
            IBuildDefinition find = this.cached_buildDefinitions.Find(definition =>
            {
                return definition.Name == this.cmbBuildDefinition.SelectedItem as string;
            });
            if (find == null)
            {
                return;
            }

            FormDefinitionEdit.DialogShow(find, FormActionMode.View);
        }

        private void linkBuildController_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
/*
            if (this.cmbBuildController.SelectedIndex == -1)
            {
                return;
            }
            IBuildController find = this.cached_buildControllers.Find(agent =>
            {
                return agent.Name == this.cmbBuildController.SelectedItem as string;
            });
            if (find == null)
            {
                return;
            }

            FormAgentEdit.DialogShow(find, FormActionMode.View);
*/
        }
    }
}