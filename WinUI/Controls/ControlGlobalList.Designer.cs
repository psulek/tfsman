using TFSManager.Properties;

namespace TFSManager.Controls
{
    partial class ControlGlobalList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlGlobalList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewItem = new System.Windows.Forms.ToolStripButton();
            this.btnEditItem = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateChanges = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.tree = new System.Windows.Forms.TreeView();
            this.menuGlobalList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniGL_EditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGL_NewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGL_DeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniFindItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGL_FindRelatedWI = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.menuGlobalList.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewItem,
            this.btnEditItem,
            this.btnDeleteItem,
            this.btnUpdateChanges,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(657, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewItem
            // 
            this.btnNewItem.Image = ((System.Drawing.Image)(resources.GetObject("btnNewItem.Image")));
            this.btnNewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(71, 22);
            this.btnNewItem.Text = "New item";
            this.btnNewItem.ToolTipText = "New item (Ins)";
            this.btnNewItem.Click += new System.EventHandler(this.mniGL_NewItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Image = ((System.Drawing.Image)(resources.GetObject("btnEditItem.Image")));
            this.btnEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(68, 22);
            this.btnEditItem.Text = "Edit item";
            this.btnEditItem.ToolTipText = "Edit item (F2)";
            this.btnEditItem.Click += new System.EventHandler(this.mniGL_EditItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(81, 22);
            this.btnDeleteItem.Text = "Delete item";
            this.btnDeleteItem.ToolTipText = "Delete item (Del)";
            this.btnDeleteItem.Click += new System.EventHandler(this.mniGL_DeleteItem_Click);
            // 
            // btnUpdateChanges
            // 
            this.btnUpdateChanges.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnUpdateChanges.Image = global::TFSManager.Properties.Resources.save;
            this.btnUpdateChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateChanges.Name = "btnUpdateChanges";
            this.btnUpdateChanges.Size = new System.Drawing.Size(152, 22);
            this.btnUpdateChanges.Text = "Update changes to server";
            this.btnUpdateChanges.Click += new System.EventHandler(this.btnUpdateChanges_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.Image = global::TFSManager.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 22);
            this.btnRefresh.Text = "Refresh global list";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::TFSManager.Properties.Resources.file_find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(59, 22);
            this.btnFind.Text = "Find...";
            this.btnFind.ToolTipText = "Find item (Ctrl+F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // tree
            // 
            this.tree.AllowDrop = true;
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tree.ContextMenuStrip = this.menuGlobalList;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.FullRowSelect = true;
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.imageList1;
            this.tree.LabelEdit = true;
            this.tree.Location = new System.Drawing.Point(0, 25);
            this.tree.Margin = new System.Windows.Forms.Padding(0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(657, 458);
            this.tree.TabIndex = 9;
            this.tree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tree_AfterLabelEdit);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            this.tree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_KeyDown);
            // 
            // menuGlobalList
            // 
            this.menuGlobalList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniGL_EditItem,
            this.mniGL_NewItem,
            this.mniGL_DeleteItem,
            this.toolStripMenuItem2,
            this.mniFindItem,
            this.mniGL_FindRelatedWI});
            this.menuGlobalList.Name = "contextMenuStrip1";
            this.menuGlobalList.Size = new System.Drawing.Size(251, 142);
            this.menuGlobalList.Opening += new System.ComponentModel.CancelEventHandler(this.menuGlobalList_Opening);
            // 
            // mniGL_EditItem
            // 
            this.mniGL_EditItem.Image = global::TFSManager.Properties.Resources.page_white_edit;
            this.mniGL_EditItem.Name = "mniGL_EditItem";
            this.mniGL_EditItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mniGL_EditItem.Size = new System.Drawing.Size(250, 22);
            this.mniGL_EditItem.Text = "Edit item";
            this.mniGL_EditItem.Click += new System.EventHandler(this.mniGL_EditItem_Click);
            // 
            // mniGL_NewItem
            // 
            this.mniGL_NewItem.Image = global::TFSManager.Properties.Resources.page_white_add;
            this.mniGL_NewItem.Name = "mniGL_NewItem";
            this.mniGL_NewItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mniGL_NewItem.Size = new System.Drawing.Size(250, 22);
            this.mniGL_NewItem.Text = "New item";
            this.mniGL_NewItem.Click += new System.EventHandler(this.mniGL_NewItem_Click);
            // 
            // mniGL_DeleteItem
            // 
            this.mniGL_DeleteItem.Image = global::TFSManager.Properties.Resources.page_white_delete;
            this.mniGL_DeleteItem.Name = "mniGL_DeleteItem";
            this.mniGL_DeleteItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mniGL_DeleteItem.Size = new System.Drawing.Size(250, 22);
            this.mniGL_DeleteItem.Text = "Delete item";
            this.mniGL_DeleteItem.Click += new System.EventHandler(this.mniGL_DeleteItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(247, 6);
            // 
            // mniFindItem
            // 
            this.mniFindItem.Image = global::TFSManager.Properties.Resources.file_find;
            this.mniFindItem.Name = "mniFindItem";
            this.mniFindItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mniFindItem.Size = new System.Drawing.Size(250, 22);
            this.mniFindItem.Text = "Find item...";
            this.mniFindItem.ToolTipText = "Find item in global list";
            this.mniFindItem.Click += new System.EventHandler(this.mniFindItem_Click);
            // 
            // mniGL_FindRelatedWI
            // 
            this.mniGL_FindRelatedWI.Image = global::TFSManager.Properties.Resources.fast_forward;
            this.mniGL_FindRelatedWI.Name = "mniGL_FindRelatedWI";
            this.mniGL_FindRelatedWI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mniGL_FindRelatedWI.Size = new System.Drawing.Size(250, 22);
            this.mniGL_FindRelatedWI.Text = "Locate related work items";
            this.mniGL_FindRelatedWI.Click += new System.EventHandler(this.mniGL_FindRelatedWI_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "text_tree.png");
            this.imageList1.Images.SetKeyName(1, "window.png");
            this.imageList1.Images.SetKeyName(2, "note.png");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "GlobalList.xml";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // ControlGlobalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tree);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControlGlobalList";
            this.Size = new System.Drawing.Size(657, 483);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuGlobalList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnUpdateChanges;
        internal System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ContextMenuStrip menuGlobalList;
        private System.Windows.Forms.ToolStripMenuItem mniGL_EditItem;
        private System.Windows.Forms.ToolStripMenuItem mniGL_NewItem;
        private System.Windows.Forms.ToolStripMenuItem mniGL_DeleteItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mniGL_FindRelatedWI;
        private System.Windows.Forms.ToolStripButton btnNewItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditItem;
        private System.Windows.Forms.ToolStripButton btnDeleteItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripMenuItem mniFindItem;
    }
}
