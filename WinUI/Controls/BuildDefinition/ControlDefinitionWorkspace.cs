using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Forms;

namespace TFSManager.Controls
{
    public partial class ControlDefinitionWorkspace: BaseChildControl
    {
        private const int COLUMN_LOCALFOLDER = 2;
        private const int COLUMN_SERVERFOLDER = 1;
        private const int COLUMN_STATUS = 0;
        private const string HINT_ITEM_TEXT = "Click here to enter a new working folder";
        private const string LOCAL_FOLDER_SOURCEDIR = "$(SourceDir)";
        private IBuildDefinition definition;

        public ControlDefinitionWorkspace()
        {
            InitializeComponent();
        }

        public void Initialize(IBuildDefinition definition)
        {
            this.definition = definition;
            this.lvWorkspaces.Items.Clear();

            if (definition != null)
            {
                this.lvWorkspaces.BeginUpdate();
                try
                {
                    List<IWorkspaceMapping> mappings = definition.Workspace.Mappings;
                    mappings.Sort((mapping1, mapping2) =>
                        {
                            return string.Compare(mapping1.ServerItem, mapping2.ServerItem);
                        });
                    foreach (IWorkspaceMapping mapping in mappings)
                    {
                        AddItemToList(mapping, false);
                    }

                    AddItemToList(null, true);
                }
                finally
                {
                    this.lvWorkspaces.EndUpdate();
                }
            }

            UpdateWarning();
        }

        private void UpdateWarning()
        {
            bool warning = this.lvWorkspaces.Items.Count == 0;
            if (!warning && this.lvWorkspaces.Items.Count == 1)
            {
                // first item is 'hint' item
                warning = this.lvWorkspaces.Items[0].Tag == null;
            }
            OwnerForm.Notify(this, warning);
            this.lbWarningMsg.Visible = warning;
        }

        private ListViewItem AddNewItemHint()
        {
            ListViewItem viewItem = this.lvWorkspaces.Items.Add("");
            viewItem.UseItemStyleForSubItems = false;
            ListViewItem.ListViewSubItem subItem = viewItem.SubItems.Add(HINT_ITEM_TEXT);
            subItem.ForeColor = Color.FromKnownColor(KnownColor.ControlDark);
            viewItem.SubItems.Add("");

            return viewItem;
        }

        private void AddItemToList(IWorkspaceMapping mapping, bool specialNewItem)
        {
            try
            {
                ListViewItem viewItem;
                WorkspaceMappingType mappingType;
                string status;
                string serverFolder;
                string localFolder;

                ListViewItem.ListViewSubItem subItemServerFolder;
                ListViewItem.ListViewSubItem subItemLocalFolder;

                if (specialNewItem)
                {
                    viewItem = AddNewItemHint();
                    mapping = null;
                    status = "Active";
                    serverFolder = string.Empty;
                    localFolder = string.Empty;
                    mappingType = WorkspaceMappingType.Map;
                }
                else
                {
                    mappingType = mapping.MappingType;
                    status = mappingType == WorkspaceMappingType.Map ? "Active" : "Cloaked";
                    serverFolder = mapping.ServerItem;
                    localFolder = mapping.LocalItem;
                    viewItem = this.lvWorkspaces.Items.Add(status);
                    viewItem.SubItems.Add(mapping.ServerItem);
                    viewItem.SubItems.Add(mapping.LocalItem);
                }

                subItemServerFolder = viewItem.SubItems[COLUMN_SERVERFOLDER];
                subItemLocalFolder = viewItem.SubItems[COLUMN_LOCALFOLDER];

                viewItem.Tag = mapping;
                int rowIndex = this.lvWorkspaces.Items.Count - 1;

                var cmbStatus = new ComboBox();
                cmbStatus.DrawMode = DrawMode.OwnerDrawFixed;
                cmbStatus.ItemHeight = 11;
                cmbStatus.IntegralHeight = true;
                cmbStatus.DrawItem += ((sender, e) =>
                {
                    e.DrawBackground();
                    if (e.Index > -1)
                    {
                        var text = cmbStatus.Items[e.Index] as string;
                        e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                    }
                });

                cmbStatus.FlatStyle = FlatStyle.Flat;
                cmbStatus.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
                cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbStatus.Items.Add("Active");
                cmbStatus.Items.Add("Cloaked");
                cmbStatus.Text = status;
                cmbStatus.SelectedIndex = mappingType == WorkspaceMappingType.Map ? 0 : 1;
                this.lvWorkspaces.AddEmbeddedControl(cmbStatus, COLUMN_STATUS, rowIndex, DockStyle.Fill, false);

                var serverFolderPanel = new Panel();
                serverFolderPanel.Tag = viewItem;
                int buttonSize = 19;
                serverFolderPanel.BackColor = Color.Transparent;
                var serverFolderEdit = new TextBox();
                serverFolderEdit.Text = serverFolder;
                serverFolderEdit.Name = "edit";
                serverFolderEdit.BorderStyle = BorderStyle.FixedSingle;
                serverFolderPanel.Controls.Add(serverFolderEdit);
                serverFolderEdit.Location = new Point(0, 0);
                serverFolderEdit.Size = new Size(serverFolderPanel.ClientRectangle.Width - buttonSize,
                    serverFolderPanel.ClientRectangle.Height);
                serverFolderEdit.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                //serverFolderEdit.Dock = DockStyle.Left;
                var serverFolderButton = new Button();
                serverFolderPanel.Controls.Add(serverFolderButton);
                serverFolderButton.Text = "???";
                serverFolderButton.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point,
                    238);
                serverFolderButton.BackColor = Color.FromKnownColor(KnownColor.Control);
                serverFolderButton.Location = new Point(serverFolderPanel.ClientRectangle.Right - buttonSize, 0);
                serverFolderButton.Size = new Size(buttonSize, buttonSize);
                serverFolderButton.Dock = DockStyle.Right;
                serverFolderButton.Click += BrowseForServerFolder_Click;
                subItemServerFolder.Tag = serverFolderEdit;
                this.lvWorkspaces.AddEmbeddedControl(serverFolderPanel, COLUMN_SERVERFOLDER, rowIndex, DockStyle.Fill,
                    false);


                var localFolderPanel = new Panel();
                localFolderPanel.Tag = viewItem;
                localFolderPanel.BackColor = Color.Transparent;
                var localFolderEdit = new TextBox();
                localFolderEdit.Text = localFolder;
                localFolderEdit.Name = "edit";
                localFolderEdit.BorderStyle = BorderStyle.FixedSingle;
                localFolderPanel.Controls.Add(localFolderEdit);
                localFolderEdit.Location = new Point(0, 0);
                localFolderEdit.Size = new Size(localFolderPanel.ClientRectangle.Width - buttonSize,
                    localFolderPanel.ClientRectangle.Height);
                localFolderEdit.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                //localFolderEdit.Dock = DockStyle.Left;
                var localFolderButton = new Button();
                localFolderPanel.Controls.Add(localFolderButton);
                localFolderButton.Text = "???";
                localFolderButton.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point,
                    238);
                localFolderButton.BackColor = Color.FromKnownColor(KnownColor.Control);
                localFolderButton.Location = new Point(localFolderPanel.ClientRectangle.Right - buttonSize, 0);
                localFolderButton.Size = new Size(buttonSize, buttonSize);
                localFolderButton.Dock = DockStyle.Right;
                localFolderButton.Click += BrowseForLocalFolder_Click;
                subItemLocalFolder.Tag = localFolderEdit;
                this.lvWorkspaces.AddEmbeddedControl(localFolderPanel, COLUMN_LOCALFOLDER, rowIndex, DockStyle.Fill,
                    false);
            }
            finally
            {
                UpdateWarning();
            }
        }

        private void BrowseForLocalFolder_Click(object sender, EventArgs e)
        {
            var btn = (sender as Button);
            var pnl = btn.Parent as Panel;

            Control[] controls = pnl.Controls.Find("edit", false);
            var edit = controls[0] as TextBox;

            this.folderBrowseDlg.SelectedPath = edit.Text;
            if (this.folderBrowseDlg.ShowDialog() == DialogResult.OK)
            {
                edit.Text = this.folderBrowseDlg.SelectedPath;
            }
        }

        private void BrowseForServerFolder_Click(object sender, EventArgs args)
        {
            var btn = (sender as Button);
            var pnl = btn.Parent as Panel;

            Control[] controls = pnl.Controls.Find("edit", false);
            var edit = controls[0] as TextBox;

            string selectedPath = FormBrowseTFSFolder.DialogShow(edit.Text);
            if (selectedPath != null)
            {
                edit.Text = selectedPath;
            }
        }

        private void lvWorkspaces_EmbeddControlEndEditing(EmbeddControlEndEditingArgs args)
        {
            bool isHintItem = args.ControlItem.Tag == null;
            bool convertToRealItem = false;
            string serverFolder;
            string localFolder;

            if (!args.Editing)
            {
                switch (args.Column)
                {
                    case COLUMN_STATUS:
                    {
                        serverFolder = (args.ControlItem.SubItems[COLUMN_SERVERFOLDER].Tag as TextBox).Text;
                        localFolder = (args.ControlItem.SubItems[COLUMN_LOCALFOLDER].Tag as TextBox).Text;

                        convertToRealItem = (isHintItem
                            && (!string.IsNullOrEmpty(serverFolder) || !string.IsNullOrEmpty(localFolder)));

                        var cmb = args.EmbeddControl as ComboBox;
                        if (convertToRealItem)
                        {
                            args.ControlItem.SubItems[args.Column].Text = cmb.SelectedItem as string;
                        }

                        break;
                    }

                    case COLUMN_SERVERFOLDER:
                    case COLUMN_LOCALFOLDER:
                    {
                        var pnl = args.EmbeddControl as Panel;
                        Control[] controls = pnl.Controls.Find("edit", false);
                        var edit = controls[0] as TextBox;
                        bool textEmpty = string.IsNullOrEmpty(edit.Text);

                        if (!isHintItem || !textEmpty)
                        {
                            args.ControlItem.SubItems[args.Column].Text = edit.Text;
                        }

                        convertToRealItem = (isHintItem && !textEmpty);
                        break;
                    }
                }

                string status = args.ControlItem.SubItems[COLUMN_STATUS].Text;
                serverFolder = args.ControlItem.SubItems[COLUMN_SERVERFOLDER].Text;
                localFolder = args.ControlItem.SubItems[COLUMN_LOCALFOLDER].Text;

                // item with tag null is 'hint' item
                if (convertToRealItem)
                {
                    if (string.IsNullOrEmpty(localFolder))
                    {
                        string[] items = serverFolder.Split('/');
                        // $/FAST/Development/Main/Source
                        //LOCAL_FOLDER_SOURCEDIR
                        var part = new StringBuilder();
                        if (items.Length >= 3)
                        {
                            part.Append("\\");
                            for (int i = 2; i < items.Length; i++)
                            {
                                part.Append(items[i]);
                                if (i + 1 < items.Length)
                                {
                                    part.Append("\\");
                                }
                            }
                        }

                        localFolder = LOCAL_FOLDER_SOURCEDIR + part;
                        (args.ControlItem.SubItems[COLUMN_LOCALFOLDER].Tag as TextBox).Text = localFolder;
                        args.ControlItem.SubItems[COLUMN_LOCALFOLDER].Text = localFolder;
                    }

                    WorkspaceMappingType mappingType = (status.ToLower() == "active"
                        ? WorkspaceMappingType.Map : WorkspaceMappingType.Cloak);
                    IWorkspaceMapping mapping = this.definition.Workspace.AddMapping(serverFolder, localFolder,
                        mappingType);

                    args.ControlItem.UseItemStyleForSubItems = true;
                    args.ControlItem.SubItems[COLUMN_SERVERFOLDER].ForeColor =
                        Color.FromKnownColor(KnownColor.ControlText);

                    args.ControlItem.Tag = mapping;
                    AddItemToList(null, true);
                }

                if ((isHintItem && !convertToRealItem)
                    && args.ControlItem.SubItems[COLUMN_STATUS].Text.ToLower() == "active")
                {
                    args.ControlItem.SubItems[COLUMN_STATUS].Text = string.Empty;
                    args.ControlItem.SubItems[COLUMN_SERVERFOLDER].Text = HINT_ITEM_TEXT;
                }
            }
            else
            {
                if ((args.Column == COLUMN_SERVERFOLDER || args.Column == COLUMN_LOCALFOLDER))
                {
                    ListViewItem.ListViewSubItem subItemServerFolder = args.ControlItem.SubItems[COLUMN_SERVERFOLDER];
                    string editText = (subItemServerFolder.Tag as TextBox).Text;
                    if (subItemServerFolder.Text != string.Empty && editText == string.Empty)
                    {
                        subItemServerFolder.Text = string.Empty;
                    }

                    if (args.ControlItem.SubItems[COLUMN_STATUS].Text == string.Empty)
                    {
                        args.ControlItem.SubItems[COLUMN_STATUS].Text = "Active";
                    }
                }

                if (args.Column == COLUMN_STATUS && isHintItem)
                {
                    if (args.ControlItem.SubItems[COLUMN_STATUS].Text.ToLower() == "active")
                    {
                        args.ControlItem.SubItems[COLUMN_STATUS].Text = string.Empty;
                    }

                    args.ControlItem.SubItems[COLUMN_SERVERFOLDER].Text = HINT_ITEM_TEXT;
                }
            }
        }

        private void menuGrid_Opening(object sender, CancelEventArgs e)
        {
            bool isSelectedItem = this.lvWorkspaces.SelectedItems.Count > 0;
            if (isSelectedItem && this.lvWorkspaces.SelectedItems.Count == 1)
            {
                // first item is 'hint' item
                isSelectedItem = this.lvWorkspaces.SelectedItems[0].Tag != null;
            }

            this.mniDelete.Enabled = isSelectedItem;
        }

        private void mniDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvWorkspaces.SelectedItems)
            {
                this.lvWorkspaces.Items.Remove(item);
            }

            UpdateWarning();
        }

        private void mniSelectAll_Click(object sender, EventArgs e)
        {
            this.lvWorkspaces.EndEditing();
            this.lvWorkspaces.SelectedItems.Clear();
            foreach (ListViewItem item in this.lvWorkspaces.Items)
            {
                // item with tag null is 'hint' item
                if (item.Tag != null)
                {
                    item.Selected = true;
                }
            }
        }
    }
}