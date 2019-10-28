using System;
using System.ComponentModel;
using System.Windows.Forms;

using TFSManager.Core;
using TFSManager.Core.WinForms;

namespace TFSManager.Controls
{
    public partial class ControlMSBuildProjConfigurations: BaseChildControl
    {
        public ControlMSBuildProjConfigurations()
        {
            InitializeComponent();
        }

        public override void InitializeControl(IMasterForm ownerForm)
        {
            base.InitializeControl(ownerForm);
            PopulateGrid();
            UpdateParentForm();
        }

        private void PopulateGrid()
        {
            this.grid.Rows.Clear();
            this.grid.Rows.Add("Release", "Any CPU");
        }

        private void UpdateParentForm()
        {
            bool? enableLinkButtons = null;
            OwnerForm.Notify(this, enableLinkButtons);
        }

        private void menuGrid_Opening(object sender, CancelEventArgs e)
        {
            bool disable = (this.grid.SelectedRows.Count == 1 && this.grid.SelectedRows[0].Index == 0) ||
                this.grid.CurrentRow.Index == 0;

            this.mniRemove.Enabled = !disable;
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            this.grid.Rows.Add("Release", "Any CPU");
        }

        private void mniRemove_Click(object sender, EventArgs e)
        {
            if (this.grid.SelectedRows.Count == 0)
            {
                return;
            }

            foreach (DataGridViewRow row in this.grid.SelectedRows)
            {
                this.grid.Rows.Remove(row);
            }
        }

        private void grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index == 0)
            {
                MessageBox.Show("You must specify at least one configuration.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}