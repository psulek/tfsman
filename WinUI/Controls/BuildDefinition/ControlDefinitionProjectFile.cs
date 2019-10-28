using System;
using System.IO;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

using TFSManager.Core;
using TFSManager.Forms;

namespace TFSManager.Controls
{
    public partial class ControlDefinitionProjectFile: BaseChildControl
    {
        private readonly string[] messages = new[]
                                             {
                                                 "Found MSBuild project file: TFSBuild.proj",
                                                 "Warning: No TFSBuild.proj file was found in the version control folder specified above. To create a new project file, click Create to run the MSBuild Project File Creation Wizard."
                                             };

        public ControlDefinitionProjectFile()
        {
            InitializeComponent();
        }

        internal string ConfigurationFolderPath
        {
            get
            {
                return this.edFolder.Text;
            }
            set
            {
                this.edFolder.Text = value;
            }
        }

        public new FormDefinitionEdit OwnerForm
        {
            get
            {
                return base.OwnerForm as FormDefinitionEdit;
            }
        }

        public void Initialize(IBuildDefinition definition)
        {
//            if (definition != null)
//            {
//                this.ConfigurationFolderPath = definition.ConfigurationFolderPath;
//            }
//            else
//            {
//                this.ConfigurationFolderPath = string.Empty;
//            }
            
            UpdateWarning();
        }

        private void UpdateWarning()
        {
            string fullServerPath = Path.Combine(ConfigurationFolderPath, Context.BUILD_FILE);
            bool warning = true;
            try
            {
                Item serverBuildFile = Context.ControlServer.GetItem(fullServerPath);
                warning = serverBuildFile == null;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Getting build project file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.lbIcon.ImageIndex = warning ? 1 : 0;
            this.lbMessage.Text = this.messages[this.lbIcon.ImageIndex];
            this.btnCreate.Visible = warning;

            OwnerForm.Notify(this, warning);
        }

        private void edFolder_Leave(object sender, EventArgs e)
        {
            UpdateWarning();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string selectedPath = FormBrowseTFSFolder.DialogShow(this.edFolder.Text);
            if (selectedPath != null)
            {
                this.edFolder.Text = selectedPath;
                UpdateWarning();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormProjectFileCreateWizard.DialogShow(OwnerForm.GetServerFolders());
        }
    }
}