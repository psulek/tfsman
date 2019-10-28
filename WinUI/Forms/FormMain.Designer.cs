using TFSManager.Core.WinForms.Controls;

namespace TFSManager.Forms
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabPages = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.controlGlobalList = new TFSManager.Controls.ControlGlobalList();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.controlWorkItems = new TFSManager.Controls.ControlWorkItems();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.controlUsers = new TFSManager.Controls.ControlUsers();
            this.tabTeamBuilds = new System.Windows.Forms.TabPage();
            this.controlTeamBuilds = new TFSManager.Controls.ControlTeamBuilds();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbTeamServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbConnectedStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbLoggedUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressMain = new System.Windows.Forms.ToolStripProgressBar();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniShowMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.timerForTrayIcon = new System.Windows.Forms.Timer(this.components);
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.logBox = new TFSManager.Core.WinForms.Controls.IconListBox();
            this.tabPages.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.tabTeamBuilds.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.trayIconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPages
            // 
            this.tabPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabPages.Controls.Add(this.tabPage1);
            this.tabPages.Controls.Add(this.tabPage2);
            this.tabPages.Controls.Add(this.tabUsers);
            this.tabPages.Controls.Add(this.tabTeamBuilds);
            this.tabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPages.HotTrack = true;
            this.tabPages.ImageList = this.imageList1;
            this.tabPages.Location = new System.Drawing.Point(0, 0);
            this.tabPages.Name = "tabPages";
            this.tabPages.Padding = new System.Drawing.Point(0, 0);
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(951, 484);
            this.tabPages.TabIndex = 10;
            this.tabPages.SelectedIndexChanged += new System.EventHandler(this.tabPages_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.controlGlobalList);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(943, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Global List Tree";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // controlGlobalList
            // 
            this.controlGlobalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlGlobalList.Location = new System.Drawing.Point(3, 3);
            this.controlGlobalList.Name = "controlGlobalList";
            this.controlGlobalList.Size = new System.Drawing.Size(937, 448);
            this.controlGlobalList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.controlWorkItems);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(943, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Work Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // controlWorkItems
            // 
            this.controlWorkItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlWorkItems.Location = new System.Drawing.Point(3, 3);
            this.controlWorkItems.Name = "controlWorkItems";
            this.controlWorkItems.Size = new System.Drawing.Size(937, 448);
            this.controlWorkItems.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.controlUsers);
            this.tabUsers.ImageIndex = 2;
            this.tabUsers.Location = new System.Drawing.Point(4, 26);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(943, 454);
            this.tabUsers.TabIndex = 2;
            this.tabUsers.Text = "Users";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // controlUsers
            // 
            this.controlUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlUsers.Location = new System.Drawing.Point(3, 3);
            this.controlUsers.Name = "controlUsers";
            this.controlUsers.Size = new System.Drawing.Size(937, 448);
            this.controlUsers.TabIndex = 0;
            // 
            // tabTeamBuilds
            // 
            this.tabTeamBuilds.Controls.Add(this.controlTeamBuilds);
            this.tabTeamBuilds.ImageIndex = 3;
            this.tabTeamBuilds.Location = new System.Drawing.Point(4, 26);
            this.tabTeamBuilds.Name = "tabTeamBuilds";
            this.tabTeamBuilds.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeamBuilds.Size = new System.Drawing.Size(943, 454);
            this.tabTeamBuilds.TabIndex = 3;
            this.tabTeamBuilds.Text = "Team Builds";
            this.tabTeamBuilds.UseVisualStyleBackColor = true;
            // 
            // controlTeamBuilds
            // 
            this.controlTeamBuilds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlTeamBuilds.Enabled = false;
            this.controlTeamBuilds.Location = new System.Drawing.Point(3, 3);
            this.controlTeamBuilds.Name = "controlTeamBuilds";
            this.controlTeamBuilds.Size = new System.Drawing.Size(937, 448);
            this.controlTeamBuilds.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "text_tree.png");
            this.imageList1.Images.SetKeyName(1, "WITEIcons.bmp");
            this.imageList1.Images.SetKeyName(2, "users.png");
            this.imageList1.Images.SetKeyName(3, "AdminUI_3.bmp");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTeamServer,
            this.lbConnectedStatus,
            this.lbLoggedUser,
            this.progressMain});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(951, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbTeamServer
            // 
            this.lbTeamServer.IsLink = true;
            this.lbTeamServer.Name = "lbTeamServer";
            this.lbTeamServer.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.lbTeamServer.Size = new System.Drawing.Size(312, 17);
            this.lbTeamServer.Spring = true;
            this.lbTeamServer.Text = "-";
            this.lbTeamServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTeamServer.Click += new System.EventHandler(this.lbTeamServer_Click);
            // 
            // lbConnectedStatus
            // 
            this.lbConnectedStatus.Name = "lbConnectedStatus";
            this.lbConnectedStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.lbConnectedStatus.Size = new System.Drawing.Size(312, 17);
            this.lbConnectedStatus.Spring = true;
            this.lbConnectedStatus.Text = "-";
            this.lbConnectedStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLoggedUser
            // 
            this.lbLoggedUser.Name = "lbLoggedUser";
            this.lbLoggedUser.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.lbLoggedUser.Size = new System.Drawing.Size(312, 17);
            this.lbLoggedUser.Spring = true;
            this.lbLoggedUser.Text = "-";
            this.lbLoggedUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressMain
            // 
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(70, 16);
            this.progressMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressMain.Visible = false;
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "TFS Manager";
            this.trayIcon.Visible = true;
            this.trayIcon.BalloonTipClicked += new System.EventHandler(this.trayIcon_BalloonTipClicked);
            this.trayIcon.BalloonTipClosed += new System.EventHandler(this.trayIcon_BalloonTipClosed);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniShowMainForm});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(190, 26);
            // 
            // mniShowMainForm
            // 
            this.mniShowMainForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mniShowMainForm.Name = "mniShowMainForm";
            this.mniShowMainForm.Size = new System.Drawing.Size(189, 22);
            this.mniShowMainForm.Text = "Show TFS Manager...";
            this.mniShowMainForm.Click += new System.EventHandler(this.mniShowMainForm_Click);
            // 
            // timerForTrayIcon
            // 
            this.timerForTrayIcon.Enabled = true;
            this.timerForTrayIcon.Interval = 500;
            this.timerForTrayIcon.Tick += new System.EventHandler(this.timerForTrayIcon_Tick);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabPages);
            this.splitContainer.Panel1MinSize = 300;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.logBox);
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(951, 588);
            this.splitContainer.SplitterDistance = 484;
            this.splitContainer.TabIndex = 5;
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.DefaultImage = null;
            this.logBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.logBox.FormattingEnabled = true;
            this.logBox.Location = new System.Drawing.Point(5, 4);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(940, 93);
            this.logBox.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 610);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TFS Manager (TFS 2010 Compatible)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.tabPages.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabTeamBuilds.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.trayIconMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbTeamServer;
        private System.Windows.Forms.ToolStripStatusLabel lbLoggedUser;
        private System.Windows.Forms.ToolStripStatusLabel lbConnectedStatus;
        private System.Windows.Forms.TabPage tabUsers;
        private TFSManager.Controls.ControlTeamBuilds controlTeamBuilds;
        internal System.Windows.Forms.TabControl tabPages;
        internal System.Windows.Forms.TabPage tabTeamBuilds;
        internal TFSManager.Controls.ControlWorkItems controlWorkItems;
        private TFSManager.Controls.ControlGlobalList controlGlobalList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripProgressBar progressMain;
        private TFSManager.Controls.ControlUsers controlUsers;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem mniShowMainForm;
        private System.Windows.Forms.Timer timerForTrayIcon;
        private System.Windows.Forms.SplitContainer splitContainer;
        private IconListBox logBox;
    }
}

