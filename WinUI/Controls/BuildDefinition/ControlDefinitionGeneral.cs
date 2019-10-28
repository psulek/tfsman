using System;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Core;

namespace TFSManager.Controls
{
    public partial class ControlDefinitionGeneral: BaseChildControl
    {
        public ControlDefinitionGeneral()
        {
            InitializeComponent();
        }

        internal string DefinitionName
        {
            get
            {
                return this.edName.Text;
            }
            set
            {
                this.edName.Text = value;
            }
        }

        internal string Description
        {
            get
            {
                return this.edDescription.Text;
            }
            set
            {
                this.edDescription.Text = value;
            }
        }

        internal bool DisableBuildDefinition
        {
            get
            {
                return this.chDisable.Checked;
            }
            set
            {
                this.chDisable.Checked = value;
            }
        }

        public void Initialize(IBuildDefinition definition)
        {
            if (definition != null)
            {
                DefinitionName = definition.Name;
                Description = definition.Description;
                DisableBuildDefinition = !definition.Enabled;
            }
            else
            {
                DefinitionName = string.Empty;
                Description = string.Empty;
                DisableBuildDefinition = false;
            }

            UpdateWarning();
        }

        private void UpdateWarning()
        {
            bool warning = this.edName.Text == string.Empty;
            OwnerForm.Notify(this, warning);
            this.lbName.ForeColor = Util.GetStatusColor(!warning);
        }

        private void edName_Leave(object sender, EventArgs e)
        {
            UpdateWarning();
        }
    }
}