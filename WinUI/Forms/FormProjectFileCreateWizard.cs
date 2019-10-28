using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using TFSManager.Controls;
using TFSManager.Core;
using TFSManager.Core.WinForms;

namespace TFSManager.Forms
{
    public partial class FormProjectFileCreateWizard: Form, IMasterForm
    {
        private static FormProjectFileCreateWizard form;
        private readonly BaseChildControl[] childControls;
        private readonly LinkLabel[] labels;
        private int selectedIndex;
        internal List<string> serverFolderMappings;

        public FormProjectFileCreateWizard()
        {
            InitializeComponent();
            this.labels = new[] {this.linkSelections, this.linkConfigurations, this.linkOptions};
            this.childControls = new BaseChildControl[] {this.controlSelections, this.controlConfigurations};
        }

        #region IMasterForm Members

        public void Notify(IChildControl child, params object[] args)
        {
            var enableLinkButtons = (bool?) args[0];
            UpdateLinksButtons(enableLinkButtons, false, true, false, false);
        }

        #endregion

        private void UpdateLabel(int index, bool selected)
        {
            Color color = selected
                ? Color.FromKnownColor(KnownColor.ControlDark) : Color.FromKnownColor(KnownColor.Control);

            this.labels[index].BackColor = color;
        }

        private void UpdateControl(int index, bool visible)
        {
            BaseChildControl childControl = this.childControls[index];
            childControl.Visible = visible;
            if (childControl.Dock != DockStyle.Fill)
            {
                childControl.Dock = DockStyle.Fill;
            }
        }

        private void UpdateLinksButtons(bool? enabled, bool previous, bool next, bool finish, bool cancel)
        {
            if (enabled.HasValue)
            {
                this.linkConfigurations.Enabled = enabled.Value;
                this.linkOptions.Enabled = enabled.Value;
            }

            this.btnPrevious.Enabled = previous;
            this.btnNext.Enabled = next;
            this.btnFinish.Enabled = finish;
            this.btnCancel.Enabled = cancel;
        }

        private void Initialize()
        {
            this.selectedIndex = 0;
            for (int i = 0; i < 3; i++)
            {
                UpdateLabel(i, i == this.selectedIndex);
            }

            UpdateLinksButtons(false, false, false, false, false);

            for (int i = 0; i < this.childControls.Length; i++)
            {
                BaseChildControl childControl = this.childControls[i];
                childControl.InitializeControl(this);
            }
            UpdateControl(this.selectedIndex, true);
        }

        public static void DialogShow(List<string> serverFolderMappings)
        {
            if (form == null)
            {
                form = new FormProjectFileCreateWizard();
            }

            form.serverFolderMappings = serverFolderMappings;
            form.Initialize();

            DialogResult result = form.ShowDialog();
        }

        private void Link_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as LinkLabel).Tag as string);

            if (index != this.selectedIndex)
            {
                UpdateLabel(this.selectedIndex, false);
                UpdateControl(this.selectedIndex, false);

                this.selectedIndex = index;

                UpdateLabel(this.selectedIndex, true);
                UpdateControl(this.selectedIndex, true);
            }
        }
    }
}