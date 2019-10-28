namespace TFSManager.Controls
{
    partial class ControlDefinitionWorkspace
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDefinitionWorkspace));
            this.label1 = new System.Windows.Forms.Label();
            this.lvWorkspaces = new TFSManager.Controls.ListViewEx();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colSourceControlFolder = new System.Windows.Forms.ColumnHeader();
            this.colLocalFolder = new System.Windows.Forms.ColumnHeader();
            this.menuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lbWarningMsg = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowseDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.menuGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Working folders:";
            // 
            // lvWorkspaces
            // 
            this.lvWorkspaces.AllowDrop = true;
            this.lvWorkspaces.AllowRowReorder = false;
            this.lvWorkspaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvWorkspaces.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStatus,
            this.colSourceControlFolder,
            this.colLocalFolder});
            this.lvWorkspaces.ContextMenuStrip = this.menuGrid;
            this.lvWorkspaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvWorkspaces.FullRowSelect = true;
            this.lvWorkspaces.GridLines = true;
            this.lvWorkspaces.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvWorkspaces.HideSelection = false;
            this.lvWorkspaces.LabelWrap = false;
            this.lvWorkspaces.Location = new System.Drawing.Point(6, 18);
            this.lvWorkspaces.Name = "lvWorkspaces";
            this.lvWorkspaces.ShowGroups = false;
            this.lvWorkspaces.SingleClickEditMode = true;
            this.lvWorkspaces.Size = new System.Drawing.Size(452, 254);
            this.lvWorkspaces.TabIndex = 2;
            this.lvWorkspaces.UseCompatibleStateImageBehavior = false;
            this.lvWorkspaces.View = System.Windows.Forms.View.Details;
            this.lvWorkspaces.EmbeddControlEndEditing += new TFSManager.Controls.EmbeddControlEndEditingEvent(this.lvWorkspaces_EmbeddControlEndEditing);
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 70;
            // 
            // colSourceControlFolder
            // 
            this.colSourceControlFolder.Text = "Source Control Folder";
            this.colSourceControlFolder.Width = 201;
            // 
            // colLocalFolder
            // 
            this.colLocalFolder.Text = "Local Folder";
            this.colLocalFolder.Width = 150;
            // 
            // menuGrid
            // 
            this.menuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniDelete,
            this.toolStripMenuItem1,
            this.mniSelectAll});
            this.menuGrid.Name = "menuGrid";
            this.menuGrid.Size = new System.Drawing.Size(123, 54);
            this.menuGrid.Opening += new System.ComponentModel.CancelEventHandler(this.menuGrid_Opening);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(122, 22);
            this.mniDelete.Text = "&Delete";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
            // 
            // mniSelectAll
            // 
            this.mniSelectAll.Name = "mniSelectAll";
            this.mniSelectAll.Size = new System.Drawing.Size(122, 22);
            this.mniSelectAll.Text = "&Select All";
            this.mniSelectAll.Click += new System.EventHandler(this.mniSelectAll_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Location = new System.Drawing.Point(6, 278);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(168, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "&Copy Existing Workspace...";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Visible = false;
            // 
            // lbWarningMsg
            // 
            this.lbWarningMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWarningMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbWarningMsg.ImageIndex = 0;
            this.lbWarningMsg.ImageList = this.imageList1;
            this.lbWarningMsg.Location = new System.Drawing.Point(200, 278);
            this.lbWarningMsg.Name = "lbWarningMsg";
            this.lbWarningMsg.Size = new System.Drawing.Size(258, 13);
            this.lbWarningMsg.TabIndex = 5;
            this.lbWarningMsg.Text = "Please define at least one workspace mapping";
            this.lbWarningMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbWarningMsg.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "StandardIcons_2.bmp");
            // 
            // ControlDefinitionWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbWarningMsg);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lvWorkspaces);
            this.Controls.Add(this.label1);
            this.Name = "ControlDefinitionWorkspace";
            this.Size = new System.Drawing.Size(461, 306);
            this.menuGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ListViewEx lvWorkspaces;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colSourceControlFolder;
        private System.Windows.Forms.ColumnHeader colLocalFolder;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lbWarningMsg;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip menuGrid;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mniSelectAll;
        private System.Windows.Forms.FolderBrowserDialog folderBrowseDlg;
    }
}
