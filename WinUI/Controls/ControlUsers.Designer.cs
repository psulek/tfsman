namespace TFSManager.Controls
{
    partial class ControlUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlUsers));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.cmbDomains = new System.Windows.Forms.ToolStripComboBox();
            this.btnFind = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFindByUserName = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFindByUserSID = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbLocateWorkItems = new System.Windows.Forms.ToolStripDropDownButton();
            this.inProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.colAccName = new System.Windows.Forms.ColumnHeader();
            this.colDisplayName = new System.Windows.Forms.ColumnHeader();
            this.colEMail = new System.Windows.Forms.ColumnHeader();
            this.colSID = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.menuUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnicmbLocateWorkItems = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.workerReadIdentities = new System.ComponentModel.BackgroundWorker();
            this.panelWorkingArea = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.menuUsers.SuspendLayout();
            this.panelWorkingArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.cmbDomains,
            this.btnFind,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.cmbLocateWorkItems});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(608, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.Image = global::TFSManager.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnRefresh.Tag = "";
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbDomains
            // 
            this.cmbDomains.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbDomains.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDomains.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDomains.AutoToolTip = true;
            this.cmbDomains.Items.AddRange(new object[] {
            ""});
            this.cmbDomains.MaxDropDownItems = 20;
            this.cmbDomains.Name = "cmbDomains";
            this.cmbDomains.Size = new System.Drawing.Size(121, 25);
            this.cmbDomains.SelectedIndexChanged += new System.EventHandler(this.cmbDomains_SelectedIndexChanged);
            this.cmbDomains.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDomains_KeyDown);
            this.cmbDomains.Leave += new System.EventHandler(this.SynchroDomainText);
            // 
            // btnFind
            // 
            this.btnFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFindByUserName,
            this.btnFindByUserSID});
            this.btnFind.Image = global::TFSManager.Properties.Resources.file_find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(68, 22);
            this.btnFind.Text = "Find...";
            // 
            // btnFindByUserName
            // 
            this.btnFindByUserName.Name = "btnFindByUserName";
            this.btnFindByUserName.Size = new System.Drawing.Size(148, 22);
            this.btnFindByUserName.Tag = "0";
            this.btnFindByUserName.Text = "by User Name";
            this.btnFindByUserName.Click += new System.EventHandler(this.FindUserBy);
            // 
            // btnFindByUserSID
            // 
            this.btnFindByUserSID.Name = "btnFindByUserSID";
            this.btnFindByUserSID.Size = new System.Drawing.Size(148, 22);
            this.btnFindByUserSID.Tag = "1";
            this.btnFindByUserSID.Text = "by User SID";
            this.btnFindByUserSID.Click += new System.EventHandler(this.FindUserBy);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "Domain:";
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
            // cmbLocateWorkItems
            // 
            this.cmbLocateWorkItems.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inProjectToolStripMenuItem,
            this.toolStripSeparator3});
            this.cmbLocateWorkItems.Image = global::TFSManager.Properties.Resources.fast_forward;
            this.cmbLocateWorkItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmbLocateWorkItems.Name = "cmbLocateWorkItems";
            this.cmbLocateWorkItems.Size = new System.Drawing.Size(132, 22);
            this.cmbLocateWorkItems.Text = "Locate work items";
            // 
            // inProjectToolStripMenuItem
            // 
            this.inProjectToolStripMenuItem.Enabled = false;
            this.inProjectToolStripMenuItem.Name = "inProjectToolStripMenuItem";
            this.inProjectToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.inProjectToolStripMenuItem.Text = "In Project";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // lvUsers
            // 
            this.lvUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAccName,
            this.colDisplayName,
            this.colEMail,
            this.colSID,
            this.colDescription});
            this.lvUsers.ContextMenuStrip = this.menuUsers;
            this.lvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(0, 0);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.ShowItemToolTips = true;
            this.lvUsers.Size = new System.Drawing.Size(608, 315);
            this.lvUsers.SmallImageList = this.imageList1;
            this.lvUsers.TabIndex = 4;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvUsers_ColumnClick);
            this.lvUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvUsers_ItemSelectionChanged);
            // 
            // colAccName
            // 
            this.colAccName.Text = "Account Name";
            this.colAccName.Width = 123;
            // 
            // colDisplayName
            // 
            this.colDisplayName.Text = "Display Name";
            this.colDisplayName.Width = 150;
            // 
            // colEMail
            // 
            this.colEMail.Text = "Email";
            this.colEMail.Width = 148;
            // 
            // colSID
            // 
            this.colSID.Text = "SID";
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 120;
            // 
            // menuUsers
            // 
            this.menuUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnicmbLocateWorkItems});
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.Size = new System.Drawing.Size(173, 26);
            // 
            // mnicmbLocateWorkItems
            // 
            this.mnicmbLocateWorkItems.Image = global::TFSManager.Properties.Resources.fast_forward;
            this.mnicmbLocateWorkItems.Name = "mnicmbLocateWorkItems";
            this.mnicmbLocateWorkItems.Size = new System.Drawing.Size(172, 22);
            this.mnicmbLocateWorkItems.Text = "Locate Work Items";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "user.png");
            // 
            // workerReadIdentities
            // 
            this.workerReadIdentities.WorkerReportsProgress = true;
            this.workerReadIdentities.WorkerSupportsCancellation = true;
            this.workerReadIdentities.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerReadIdentities_DoWork);
            this.workerReadIdentities.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerReadIdentities_RunWorkerCompleted);
            this.workerReadIdentities.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerReadIdentities_ProgressChanged);
            // 
            // panelWorkingArea
            // 
            this.panelWorkingArea.Controls.Add(this.lvUsers);
            this.panelWorkingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkingArea.Location = new System.Drawing.Point(0, 25);
            this.panelWorkingArea.Name = "panelWorkingArea";
            this.panelWorkingArea.Size = new System.Drawing.Size(608, 315);
            this.panelWorkingArea.TabIndex = 5;
            // 
            // ControlUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWorkingArea);
            this.Controls.Add(this.toolStrip);
            this.Name = "ControlUsers";
            this.Size = new System.Drawing.Size(608, 340);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuUsers.ResumeLayout(false);
            this.panelWorkingArea.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader colAccName;
        private System.Windows.Forms.ColumnHeader colDisplayName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbDomains;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripDropDownButton btnFind;
        private System.Windows.Forms.ToolStripMenuItem btnFindByUserName;
        private System.Windows.Forms.ToolStripMenuItem btnFindByUserSID;
        private System.Windows.Forms.ColumnHeader colSID;
        private System.Windows.Forms.ColumnHeader colEMail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton cmbLocateWorkItems;
        private System.Windows.Forms.ToolStripMenuItem inProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip menuUsers;
        private System.Windows.Forms.ToolStripMenuItem mnicmbLocateWorkItems;
        private System.ComponentModel.BackgroundWorker workerReadIdentities;
        private System.Windows.Forms.Panel panelWorkingArea;
    }
}
