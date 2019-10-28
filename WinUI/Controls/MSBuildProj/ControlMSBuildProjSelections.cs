using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.TeamFoundation.VersionControl.Client;

using TFSManager.Core;
using TFSManager.Core.WinForms;
using TFSManager.Forms;

namespace TFSManager.Controls
{
    public partial class ControlMSBuildProjSelections: BaseChildControl
    {
        private bool disableItemCheck = false;
        private bool disableSelectAll = false;

        public ControlMSBuildProjSelections()
        {
            InitializeComponent();
        }

        public new FormProjectFileCreateWizard OwnerForm
        {
            get
            {
                return base.OwnerForm as FormProjectFileCreateWizard;
            }
        }

        public override void InitializeControl(IMasterForm ownerForm)
        {
            base.InitializeControl(ownerForm);
            PopulateSolutions();
            UpdateParentForm();
        }

        private void PopulateSolutions()
        {
            this.lbSolutions.Items.Clear();

            try
            {
                this.lbSolutions.BeginUpdate();

                var solutionItems = new List<string>();
                OwnerForm.serverFolderMappings.ForEach(item =>
                {
                    bool exist = solutionItems.FindIndex(it => it.Contains(item)) > -1;
                    if (!exist)
                    {
                        string query = item + "/*.sln";
                        ItemSet items = Context.ControlServer.GetItems(query.ToString(), VersionSpec.Latest,
                            RecursionType.Full, DeletedState.NonDeleted, ItemType.File);

                        foreach (Item srvItem in items.Items)
                        {
                            if (!solutionItems.Contains(srvItem.ServerItem))
                            {
                                solutionItems.Add(srvItem.ServerItem);
                            }
                        }
                    }
                });

                solutionItems.Sort((s, s1) => string.Compare(s, s1, true));

                foreach (string item in solutionItems)
                {
                    this.lbSolutions.Items.Add(item);
                }
            }
            finally
            {
                this.lbSolutions.EndUpdate();
            }
        }

        private void UpdateParentForm()
        {
            UpdateParentForm(0);
        }

        private void UpdateParentForm(int deltaValue)
        {
            int count = this.lbSolutions.CheckedItems.Count + deltaValue;

            bool? enableLinkButtons = (count > 0);
            OwnerForm.Notify(this, enableLinkButtons);
        }

        private void lbSolutions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.disableItemCheck)
            {
                return;
            }

            int checkedCount = this.lbSolutions.CheckedItems.Count;
            if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                checkedCount--;
            }
            else if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
            {
                checkedCount++;
            }

            bool checkedAll = this.lbSolutions.Items.Count == checkedCount;

            this.disableSelectAll = true;
            try
            {
                this.chSelectAll.CheckState = (checkedAll
                    ? CheckState.Checked : (checkedCount > 0 ? CheckState.Indeterminate : CheckState.Unchecked));
            }
            finally
            {
                this.disableSelectAll = false;
            }

            UpdateParentForm(e.NewValue == CheckState.Checked ? 1 : -1);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (this.chSelectAll.CheckState == CheckState.Unchecked)
            {
                this.chSelectAll.CheckState = CheckState.Checked;
            }
            else
            {
                this.chSelectAll.CheckState = CheckState.Unchecked;
            }
        }

        private void chSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.disableSelectAll)
            {
                return;
            }

            this.disableItemCheck = true;
            try
            {
                for (int i = 0; i < this.lbSolutions.Items.Count; i++)
                {
                    this.lbSolutions.SetItemChecked(i, this.chSelectAll.Checked);
                }
            }
            finally
            {
                this.disableItemCheck = false;
            }

            UpdateParentForm();
        }

        private void MoveItem_Click(object sender, EventArgs e)
        {
            var idx = (sender as Button).Tag as string;
            int index = this.lbSolutions.SelectedIndex;

            this.lbSolutions.BeginUpdate();
            try
            {
                if (idx == "0")
                {
                    bool sourceChecked = this.lbSolutions.GetItemChecked(index);
                    bool targetChecked = this.lbSolutions.GetItemChecked(index - 1);
                    var sourceItem = this.lbSolutions.Items[index] as string;
                    var targetItem = this.lbSolutions.Items[index - 1] as string;

                    this.lbSolutions.Items[index - 1] = sourceItem;
                    this.lbSolutions.Items[index] = targetItem;

                    this.lbSolutions.SetItemChecked(index - 1, sourceChecked);
                    this.lbSolutions.SetItemChecked(index, targetChecked);

                    this.lbSolutions.SelectedIndex = index - 1;
                }
                else
                {
                    bool sourceChecked = this.lbSolutions.GetItemChecked(index);
                    bool targetChecked = this.lbSolutions.GetItemChecked(index + 1);
                    var sourceItem = this.lbSolutions.Items[index] as string;
                    var targetItem = this.lbSolutions.Items[index + 1] as string;

                    this.lbSolutions.Items[index + 1] = sourceItem;
                    this.lbSolutions.Items[index] = targetItem;

                    this.lbSolutions.SetItemChecked(index + 1, sourceChecked);
                    this.lbSolutions.SetItemChecked(index, targetChecked);

                    this.lbSolutions.SelectedIndex = index + 1;
                }
            }
            finally
            {
                this.lbSolutions.EndUpdate();
            }
        }

        private void lbSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbSolutions.SelectedIndex > -1)
            {
                this.btnMoveUp.Enabled = (this.lbSolutions.SelectedIndex > 0);
                this.btnMoveDown.Enabled = (this.lbSolutions.SelectedIndex < this.lbSolutions.Items.Count - 1);
            }
            else
            {
                this.btnMoveUp.Enabled = false;
                this.btnMoveDown.Enabled = false;
            }
        }
    }
}