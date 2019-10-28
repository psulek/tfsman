using System.Windows.Forms;

using TFSManager.Core.WinForms;

using THE.Components;

namespace TFSManager.Controls
{
    partial class ControlBuilds: IControlTeamBuildList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBuilds));
            THE.Components.ColumnCCH columnCCH1 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH2 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH3 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH4 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH5 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH6 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH7 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH8 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH9 = new THE.Components.ColumnCCH();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            THE.Components.ColumnCCH columnCCH10 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH11 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH12 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH13 = new THE.Components.ColumnCCH();
            THE.Components.ColumnCCH columnCCH14 = new THE.Components.ColumnCCH();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("", 1);
            this.menuBuilds = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniBuildDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSetQuality = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGotoDefinition = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvTeamBuilds = new THE.Components.ListViewCCH();
            this.imagesHeader = new System.Windows.Forms.ImageList(this.components);
            this.topPanel = new System.Windows.Forms.Panel();
            this.topToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnQueued = new System.Windows.Forms.ToolStripButton();
            this.btnCompleted = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLatestBuilds = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lvTeamBuildsQueued = new THE.Components.ListViewCCH();
            this.menuBuilds.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.topToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBuilds
            // 
            this.menuBuilds.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniBuildDetail,
            this.mniSetQuality,
            this.mniViewLogFile,
            this.mniGotoDefinition});
            this.menuBuilds.Name = "menuBuilds";
            this.menuBuilds.Size = new System.Drawing.Size(163, 92);
            this.menuBuilds.Opening += new System.ComponentModel.CancelEventHandler(this.menuBuilds_Opening);
            // 
            // mniBuildDetail
            // 
            this.mniBuildDetail.Name = "mniBuildDetail";
            this.mniBuildDetail.Size = new System.Drawing.Size(162, 22);
            this.mniBuildDetail.Text = "View Build Detail";
            this.mniBuildDetail.Click += new System.EventHandler(this.mniBuildDetail_Click);
            // 
            // mniSetQuality
            // 
            this.mniSetQuality.Name = "mniSetQuality";
            this.mniSetQuality.Size = new System.Drawing.Size(162, 22);
            this.mniSetQuality.Text = "Set Quality";
            // 
            // mniViewLogFile
            // 
            this.mniViewLogFile.Name = "mniViewLogFile";
            this.mniViewLogFile.Size = new System.Drawing.Size(162, 22);
            this.mniViewLogFile.Text = "View Log File...";
            this.mniViewLogFile.Click += new System.EventHandler(this.mniViewLogFile_Click);
            // 
            // mniGotoDefinition
            // 
            this.mniGotoDefinition.Name = "mniGotoDefinition";
            this.mniGotoDefinition.Size = new System.Drawing.Size(162, 22);
            this.mniGotoDefinition.Text = "Go To Definition";
            this.mniGotoDefinition.Click += new System.EventHandler(this.mniGotoDefinition_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "BuildStatusIcons_2.bmp");
            this.imageList1.Images.SetKeyName(1, "BuildStatusIcons_3.bmp");
            this.imageList1.Images.SetKeyName(2, "BuildStatusIcons_6.bmp");
            this.imageList1.Images.SetKeyName(3, "BuildStatusIcons_4.bmp");
            this.imageList1.Images.SetKeyName(4, "BuildStatusIcons_5.bmp");
            this.imageList1.Images.SetKeyName(5, "BuildStatusIcons_1.bmp");
            // 
            // lvTeamBuilds
            // 
            this.lvTeamBuilds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvTeamBuilds.CheckBoxes = true;
            columnCCH1.ImageIndex = 0;
            columnCCH1.ImageOnRight = false;
            columnCCH1.OwnerDraw = false;
            columnCCH1.Tag = null;
            columnCCH1.Text = "Status";
            columnCCH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH1.Width = 80;
            columnCCH2.ImageIndex = -1;
            columnCCH2.ImageOnRight = false;
            columnCCH2.OwnerDraw = false;
            columnCCH2.Tag = null;
            columnCCH2.Text = "Started";
            columnCCH2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH2.Width = 100;
            columnCCH3.ImageIndex = -1;
            columnCCH3.ImageOnRight = false;
            columnCCH3.OwnerDraw = false;
            columnCCH3.Tag = null;
            columnCCH3.Text = "Build number";
            columnCCH3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH3.Width = 100;
            columnCCH4.ImageIndex = -1;
            columnCCH4.ImageOnRight = false;
            columnCCH4.OwnerDraw = false;
            columnCCH4.Tag = null;
            columnCCH4.Text = "Definition";
            columnCCH4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH4.Width = 60;
            columnCCH5.ImageIndex = -1;
            columnCCH5.ImageOnRight = false;
            columnCCH5.OwnerDraw = false;
            columnCCH5.Tag = null;
            columnCCH5.Text = "Agent";
            columnCCH5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            columnCCH5.Width = 60;
            columnCCH6.ImageIndex = -1;
            columnCCH6.ImageOnRight = false;
            columnCCH6.OwnerDraw = false;
            columnCCH6.Tag = null;
            columnCCH6.Text = "Requested by";
            columnCCH6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH6.Width = 80;
            columnCCH7.ImageIndex = -1;
            columnCCH7.ImageOnRight = false;
            columnCCH7.OwnerDraw = false;
            columnCCH7.Tag = null;
            columnCCH7.Text = "Quality";
            columnCCH7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH7.Width = 60;
            columnCCH8.ImageIndex = -1;
            columnCCH8.ImageOnRight = false;
            columnCCH8.OwnerDraw = false;
            columnCCH8.Tag = null;
            columnCCH8.Text = "Finish Time";
            columnCCH8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH8.Width = 100;
            columnCCH9.ImageIndex = -1;
            columnCCH9.ImageOnRight = false;
            columnCCH9.OwnerDraw = false;
            columnCCH9.Tag = null;
            columnCCH9.Text = "Log";
            columnCCH9.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH9.Width = 60;
            this.lvTeamBuilds.Columns.AddRange(new THE.Components.ColumnCCH[] {
            columnCCH1,
            columnCCH2,
            columnCCH3,
            columnCCH4,
            columnCCH5,
            columnCCH6,
            columnCCH7,
            columnCCH8,
            columnCCH9});
            this.lvTeamBuilds.ContextMenuStrip = this.menuBuilds;
            this.lvTeamBuilds.DefaultCustomDraw = false;
            this.lvTeamBuilds.FullRowSelect = true;
            this.lvTeamBuilds.FullyCustomHeader = false;
            this.lvTeamBuilds.HeaderImageList = this.imagesHeader;
            this.lvTeamBuilds.HideSelection = false;
            this.lvTeamBuilds.IncreaseHeaderHeight = 0;
            listViewItem1.StateImageIndex = 0;
            this.lvTeamBuilds.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvTeamBuilds.Location = new System.Drawing.Point(89, 90);
            this.lvTeamBuilds.Name = "lvTeamBuilds";
            this.lvTeamBuilds.Size = new System.Drawing.Size(477, 292);
            this.lvTeamBuilds.StateImageList = this.imageList1;
            this.lvTeamBuilds.TabIndex = 5;
            this.lvTeamBuilds.Tag = "2";
            this.lvTeamBuilds.UseCompatibleStateImageBehavior = false;
            this.lvTeamBuilds.View = System.Windows.Forms.View.Details;
            this.lvTeamBuilds.Visible = false;
            this.lvTeamBuilds.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvTeamBuilds_ColumnClick);
            this.lvTeamBuilds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTeamBuilds_MouseDoubleClick);
            // 
            // imagesHeader
            // 
            this.imagesHeader.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesHeader.ImageStream")));
            this.imagesHeader.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesHeader.Images.SetKeyName(0, "sort_asc.gif");
            this.imagesHeader.Images.SetKeyName(1, "sort_desc.gif");
            // 
            // topPanel
            // 
            this.topPanel.AutoSize = true;
            this.topPanel.Controls.Add(this.topToolStrip);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(566, 25);
            this.topPanel.TabIndex = 6;
            // 
            // topToolStrip
            // 
            this.topToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.topToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnQueued,
            this.btnCompleted,
            this.toolStripSeparator1,
            this.btnLatestBuilds,
            this.toolStripTextBox1,
            this.toolStripButton1});
            this.topToolStrip.Location = new System.Drawing.Point(0, 0);
            this.topToolStrip.Name = "topToolStrip";
            this.topToolStrip.Size = new System.Drawing.Size(566, 25);
            this.topToolStrip.TabIndex = 0;
            this.topToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Show builds:";
            // 
            // btnQueued
            // 
            this.btnQueued.Checked = true;
            this.btnQueued.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnQueued.Image = global::TFSManager.Properties.Resources.queue;
            this.btnQueued.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQueued.Name = "btnQueued";
            this.btnQueued.Size = new System.Drawing.Size(69, 22);
            this.btnQueued.Tag = "0";
            this.btnQueued.Text = "Queued";
            this.btnQueued.ToolTipText = "Show Queued Builds";
            this.btnQueued.Click += new System.EventHandler(this.FilterBuilds_Click);
            // 
            // btnCompleted
            // 
            this.btnCompleted.Image = global::TFSManager.Properties.Resources.completedBuilds;
            this.btnCompleted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(86, 22);
            this.btnCompleted.Tag = "1";
            this.btnCompleted.Text = "Completed";
            this.btnCompleted.ToolTipText = "Show Completed Builds";
            this.btnCompleted.Click += new System.EventHandler(this.FilterBuilds_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLatestBuilds
            // 
            this.btnLatestBuilds.Checked = true;
            this.btnLatestBuilds.CheckOnClick = true;
            this.btnLatestBuilds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnLatestBuilds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLatestBuilds.Image = ((System.Drawing.Image)(resources.GetObject("btnLatestBuilds.Image")));
            this.btnLatestBuilds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLatestBuilds.Name = "btnLatestBuilds";
            this.btnLatestBuilds.Size = new System.Drawing.Size(105, 22);
            this.btnLatestBuilds.Text = "Only Latest Builds";
            this.btnLatestBuilds.Visible = false;
            this.btnLatestBuilds.Click += new System.EventHandler(this.btnLatestBuilds_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // lvTeamBuildsQueued
            // 
            this.lvTeamBuildsQueued.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvTeamBuildsQueued.CheckBoxes = true;
            columnCCH10.ImageIndex = 0;
            columnCCH10.ImageOnRight = false;
            columnCCH10.OwnerDraw = false;
            columnCCH10.Tag = null;
            columnCCH10.Text = "Build Definition";
            columnCCH10.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH10.Width = 129;
            columnCCH11.ImageIndex = -1;
            columnCCH11.ImageOnRight = false;
            columnCCH11.OwnerDraw = false;
            columnCCH11.Tag = null;
            columnCCH11.Text = "Priority";
            columnCCH11.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH11.Width = 64;
            columnCCH12.ImageIndex = -1;
            columnCCH12.ImageOnRight = false;
            columnCCH12.OwnerDraw = false;
            columnCCH12.Tag = null;
            columnCCH12.Text = "Date Queued";
            columnCCH12.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH12.Width = 103;
            columnCCH13.ImageIndex = -1;
            columnCCH13.ImageOnRight = false;
            columnCCH13.OwnerDraw = false;
            columnCCH13.Tag = null;
            columnCCH13.Text = "Requested By";
            columnCCH13.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH13.Width = 100;
            columnCCH14.ImageIndex = -1;
            columnCCH14.ImageOnRight = false;
            columnCCH14.OwnerDraw = false;
            columnCCH14.Tag = null;
            columnCCH14.Text = "Build Agent";
            columnCCH14.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            columnCCH14.Width = 80;
            this.lvTeamBuildsQueued.Columns.AddRange(new THE.Components.ColumnCCH[] {
            columnCCH10,
            columnCCH11,
            columnCCH12,
            columnCCH13,
            columnCCH14});
            this.lvTeamBuildsQueued.DefaultCustomDraw = false;
            this.lvTeamBuildsQueued.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTeamBuildsQueued.FullRowSelect = true;
            this.lvTeamBuildsQueued.FullyCustomHeader = false;
            this.lvTeamBuildsQueued.HeaderImageList = this.imagesHeader;
            this.lvTeamBuildsQueued.IncreaseHeaderHeight = 0;
            listViewItem2.Checked = true;
            listViewItem2.StateImageIndex = 1;
            this.lvTeamBuildsQueued.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvTeamBuildsQueued.Location = new System.Drawing.Point(0, 25);
            this.lvTeamBuildsQueued.Name = "lvTeamBuildsQueued";
            this.lvTeamBuildsQueued.Size = new System.Drawing.Size(566, 357);
            this.lvTeamBuildsQueued.StateImageList = this.imageList1;
            this.lvTeamBuildsQueued.TabIndex = 7;
            this.lvTeamBuildsQueued.UseCompatibleStateImageBehavior = false;
            this.lvTeamBuildsQueued.View = System.Windows.Forms.View.Details;
            // 
            // ControlBuilds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvTeamBuilds);
            this.Controls.Add(this.lvTeamBuildsQueued);
            this.Controls.Add(this.topPanel);
            this.Name = "ControlBuilds";
            this.Size = new System.Drawing.Size(566, 382);
            this.menuBuilds.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.topToolStrip.ResumeLayout(false);
            this.topToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menuBuilds;
        private System.Windows.Forms.ToolStripMenuItem mniSetQuality;
        private System.Windows.Forms.ImageList imageList1;
        private ColumnCCH colBuilds_Status;
        private ColumnCCH colBuilds_Started;
        private ColumnCCH colBuilds_BuildNumber;
        private ColumnCCH colBuilds_Definition;
        private ColumnCCH colBuilds_Agent;
        private ColumnCCH colBuilds_RequestedBy;
        private ColumnCCH colBuilds_Quality;
        private ColumnCCH colBuilds_FinishTime;
        private ColumnCCH colBuilds_Log;
        private ListViewCCH lvTeamBuilds;
        private ToolStripMenuItem mniViewLogFile;
        private ToolStripMenuItem mniGotoDefinition;
        private ToolStripMenuItem mniBuildDetail;
        private ImageList imagesHeader;
        private Panel topPanel;
        private ToolStrip topToolStrip;
        private ToolStripButton btnQueued;
        private ToolStripButton btnCompleted;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnLatestBuilds;
        private ListViewCCH lvTeamBuildsQueued;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripButton toolStripButton1;
    }
}
