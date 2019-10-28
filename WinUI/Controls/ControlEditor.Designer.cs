namespace TFSManager.Controls
{
    partial class ControlEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlEditor));
            this.textEditor = new TFSManager.Components.XmlTextEditor();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mniClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mniSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // xmlTextEditor1
            // 
            this.textEditor.ContextMenuStrip = this.ctxMenu;
            this.textEditor.ConvertTabsToSpaces = true;
            this.textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditor.IndentStyle = ICSharpCode.TextEditor.Document.IndentStyle.Auto;
            this.textEditor.IsIconBarVisible = false;
            this.textEditor.Location = new System.Drawing.Point(0, 0);
            this.textEditor.Name = "textEditor";
            this.textEditor.Padding = new System.Windows.Forms.Padding(3);
            this.textEditor.ShowInvalidLines = false;
            this.textEditor.Size = new System.Drawing.Size(486, 432);
            this.textEditor.TabIndent = 3;
            this.textEditor.TabIndex = 1;
            this.textEditor.UseAntiAliasFont = true;
            this.textEditor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.xmlTextEditor1_KeyUp);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUndo,
            this.mniRedo,
            this.toolStripSeparator1,
            this.mniCut,
            this.mniCopy,
            this.mniPaste,
            this.mniClear,
            this.toolStripSeparator2,
            this.mniFind,
            this.mniReplace,
            this.toolStripSeparator3,
            this.mniSelectAll});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(168, 242);
            this.ctxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu_Opening);
            // 
            // mniUndo
            // 
            this.mniUndo.Image = ((System.Drawing.Image)(resources.GetObject("mniUndo.Image")));
            this.mniUndo.Name = "mniUndo";
            this.mniUndo.Size = new System.Drawing.Size(167, 22);
            this.mniUndo.Tag = "0";
            this.mniUndo.Text = "&Undo";
            this.mniUndo.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // mniRedo
            // 
            this.mniRedo.Image = ((System.Drawing.Image)(resources.GetObject("mniRedo.Image")));
            this.mniRedo.Name = "mniRedo";
            this.mniRedo.Size = new System.Drawing.Size(167, 22);
            this.mniRedo.Tag = "1";
            this.mniRedo.Text = "&Redo";
            this.mniRedo.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // mniCut
            // 
            this.mniCut.Image = ((System.Drawing.Image)(resources.GetObject("mniCut.Image")));
            this.mniCut.Name = "mniCut";
            this.mniCut.Size = new System.Drawing.Size(167, 22);
            this.mniCut.Tag = "2";
            this.mniCut.Text = "Cu&t";
            this.mniCut.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // mniCopy
            // 
            this.mniCopy.Image = ((System.Drawing.Image)(resources.GetObject("mniCopy.Image")));
            this.mniCopy.Name = "mniCopy";
            this.mniCopy.Size = new System.Drawing.Size(167, 22);
            this.mniCopy.Tag = "3";
            this.mniCopy.Text = "&Copy";
            this.mniCopy.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // mniPaste
            // 
            this.mniPaste.Image = ((System.Drawing.Image)(resources.GetObject("mniPaste.Image")));
            this.mniPaste.Name = "mniPaste";
            this.mniPaste.Size = new System.Drawing.Size(167, 22);
            this.mniPaste.Tag = "4";
            this.mniPaste.Text = "&Paste";
            this.mniPaste.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // mniClear
            // 
            this.mniClear.Name = "mniClear";
            this.mniClear.Size = new System.Drawing.Size(167, 22);
            this.mniClear.Tag = "5";
            this.mniClear.Text = "Cl&ear";
            this.mniClear.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // mniFind
            // 
            this.mniFind.Name = "mniFind";
            this.mniFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mniFind.Size = new System.Drawing.Size(167, 22);
            this.mniFind.Tag = "6";
            this.mniFind.Text = "Find...";
            this.mniFind.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // mniReplace
            // 
            this.mniReplace.Name = "mniReplace";
            this.mniReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mniReplace.Size = new System.Drawing.Size(167, 22);
            this.mniReplace.Tag = "7";
            this.mniReplace.Text = "Replace...";
            this.mniReplace.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // mniSelectAll
            // 
            this.mniSelectAll.Name = "mniSelectAll";
            this.mniSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mniSelectAll.Size = new System.Drawing.Size(167, 22);
            this.mniSelectAll.Tag = "8";
            this.mniSelectAll.Text = "&Select All";
            this.mniSelectAll.Click += new System.EventHandler(this.TextEditorContextMenu_Click);
            // 
            // ControlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditor);
            this.Name = "ControlEditor";
            this.Size = new System.Drawing.Size(486, 432);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TFSManager.Components.XmlTextEditor textEditor;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem mniUndo;
        private System.Windows.Forms.ToolStripMenuItem mniRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniCut;
        private System.Windows.Forms.ToolStripMenuItem mniCopy;
        private System.Windows.Forms.ToolStripMenuItem mniPaste;
        private System.Windows.Forms.ToolStripMenuItem mniClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mniFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mniSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mniReplace;
    }
}
