namespace TFSManager.Controls
{
    partial class ControlBuildAgents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBuildAgents));
            this.lvAgents = new System.Windows.Forms.ListView();
            this.colAgents_Name = new System.Windows.Forms.ColumnHeader();
            this.colAgents_Machine = new System.Windows.Forms.ColumnHeader();
            this.colAgents_Status = new System.Windows.Forms.ColumnHeader();
            this.colAgents_QueueCount = new System.Windows.Forms.ColumnHeader();
            this.colAgents_Uri = new System.Windows.Forms.ColumnHeader();
            this.menuAgents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAgent_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAgent_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAgent_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniAgent_CopyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesHeader = new System.Windows.Forms.ImageList(this.components);
            this.menuAgents.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAgents
            // 
            this.lvAgents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvAgents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAgents_Name,
            this.colAgents_Machine,
            this.colAgents_Status,
            this.colAgents_QueueCount,
            this.colAgents_Uri});
            this.lvAgents.ContextMenuStrip = this.menuAgents;
            this.lvAgents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAgents.FullRowSelect = true;
            this.lvAgents.HideSelection = false;
            this.lvAgents.Location = new System.Drawing.Point(0, 0);
            this.lvAgents.Name = "lvAgents";
            this.lvAgents.ShowItemToolTips = true;
            this.lvAgents.Size = new System.Drawing.Size(471, 344);
            this.lvAgents.SmallImageList = this.imagesHeader;
            this.lvAgents.TabIndex = 3;
            this.lvAgents.Tag = "0";
            this.lvAgents.UseCompatibleStateImageBehavior = false;
            this.lvAgents.View = System.Windows.Forms.View.Details;
            this.lvAgents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAgents_MouseDoubleClick);
            this.lvAgents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAgents_ColumnClick);
            // 
            // colAgents_Name
            // 
            this.colAgents_Name.Text = "Name";
            this.colAgents_Name.Width = 70;
            // 
            // colAgents_Machine
            // 
            this.colAgents_Machine.Text = "Machine";
            this.colAgents_Machine.Width = 80;
            // 
            // colAgents_Status
            // 
            this.colAgents_Status.Text = "Status";
            this.colAgents_Status.Width = 70;
            // 
            // colAgents_QueueCount
            // 
            this.colAgents_QueueCount.Text = "Queue count";
            this.colAgents_QueueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAgents_QueueCount.Width = 100;
            // 
            // colAgents_Uri
            // 
            this.colAgents_Uri.Text = "Uri";
            this.colAgents_Uri.Width = 100;
            // 
            // menuAgents
            // 
            this.menuAgents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAgent_New,
            this.mniAgent_Edit,
            this.mniAgent_Delete,
            this.toolStripSeparator2,
            this.mniAgent_CopyTo});
            this.menuAgents.Name = "menuAgents";
            this.menuAgents.Size = new System.Drawing.Size(132, 98);
            this.menuAgents.Opening += new System.ComponentModel.CancelEventHandler(this.menuAgents_Opening);
            // 
            // mniAgent_New
            // 
            this.mniAgent_New.Name = "mniAgent_New";
            this.mniAgent_New.Size = new System.Drawing.Size(131, 22);
            this.mniAgent_New.Text = "New";
            this.mniAgent_New.Click += new System.EventHandler(this.mniAgent_New_Click);
            // 
            // mniAgent_Edit
            // 
            this.mniAgent_Edit.Name = "mniAgent_Edit";
            this.mniAgent_Edit.Size = new System.Drawing.Size(131, 22);
            this.mniAgent_Edit.Text = "Edit";
            this.mniAgent_Edit.Click += new System.EventHandler(this.mniAgent_Edit_Click);
            // 
            // mniAgent_Delete
            // 
            this.mniAgent_Delete.Name = "mniAgent_Delete";
            this.mniAgent_Delete.Size = new System.Drawing.Size(131, 22);
            this.mniAgent_Delete.Text = "Delete";
            this.mniAgent_Delete.Click += new System.EventHandler(this.mniAgent_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(128, 6);
            // 
            // mniAgent_CopyTo
            // 
            this.mniAgent_CopyTo.Name = "mniAgent_CopyTo";
            this.mniAgent_CopyTo.Size = new System.Drawing.Size(131, 22);
            this.mniAgent_CopyTo.Text = "Copy To ...";
            this.mniAgent_CopyTo.Click += new System.EventHandler(this.mniAgent_CopyTo_Click);
            // 
            // imagesHeader
            // 
            this.imagesHeader.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesHeader.ImageStream")));
            this.imagesHeader.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesHeader.Images.SetKeyName(0, "sort_asc.gif");
            this.imagesHeader.Images.SetKeyName(1, "sort_desc.gif");
            // 
            // ControlBuildAgents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvAgents);
            this.Name = "ControlBuildAgents";
            this.Size = new System.Drawing.Size(471, 344);
            this.menuAgents.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAgents;
        private System.Windows.Forms.ColumnHeader colAgents_Name;
        private System.Windows.Forms.ColumnHeader colAgents_Machine;
        private System.Windows.Forms.ColumnHeader colAgents_Status;
        private System.Windows.Forms.ColumnHeader colAgents_QueueCount;
        private System.Windows.Forms.ColumnHeader colAgents_Uri;
        private System.Windows.Forms.ContextMenuStrip menuAgents;
        private System.Windows.Forms.ToolStripMenuItem mniAgent_New;
        private System.Windows.Forms.ToolStripMenuItem mniAgent_Edit;
        private System.Windows.Forms.ToolStripMenuItem mniAgent_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mniAgent_CopyTo;
        private System.Windows.Forms.ImageList imagesHeader;
    }
}
