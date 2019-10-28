namespace TFSManager.Controls
{
    partial class ControlWorkItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlWorkItems));
            this.menuWorkItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniRemoveBuildAssigment = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSetBuildAssigment = new System.Windows.Forms.ToolStripMenuItem();
            this.locateInGlobalListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGL_FoundIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mniGL_IntegrationBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.locateInTeamBuildsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTB_FoundIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTB_IntegrationBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mniRefreshQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesHeader = new System.Windows.Forms.ImageList(this.components);
            this.toolstrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnSaveQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbQueries = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbTeamProjects = new System.Windows.Forms.ToolStripComboBox();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWIGo = new System.Windows.Forms.ToolStripButton();
            this.lvWI = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colChangedDate = new System.Windows.Forms.ColumnHeader();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.sqlEditor = new UrielGuy.SyntaxHighlightingTextBox.SyntaxHighlightingTextBox();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.menuWorkItems.SuspendLayout();
            this.toolstrip1.SuspendLayout();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuWorkItems
            // 
            this.menuWorkItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniRemoveBuildAssigment,
            this.mniSetBuildAssigment,
            this.locateInGlobalListToolStripMenuItem,
            this.locateInTeamBuildsToolStripMenuItem,
            this.toolStripSeparator4,
            this.mniRefreshQuery});
            this.menuWorkItems.Name = "contextMenuStrip2";
            this.menuWorkItems.Size = new System.Drawing.Size(201, 120);
            this.menuWorkItems.Opening += new System.ComponentModel.CancelEventHandler(this.menuWorkItems_Opening);
            // 
            // mniRemoveBuildAssigment
            // 
            this.mniRemoveBuildAssigment.Image = global::TFSManager.Properties.Resources.page_white_delete;
            this.mniRemoveBuildAssigment.Name = "mniRemoveBuildAssigment";
            this.mniRemoveBuildAssigment.Size = new System.Drawing.Size(200, 22);
            this.mniRemoveBuildAssigment.Text = "Remove build assigment";
            this.mniRemoveBuildAssigment.Click += new System.EventHandler(this.removeBuildAssignedToolStripMenuItem_Click);
            // 
            // mniSetBuildAssigment
            // 
            this.mniSetBuildAssigment.Image = global::TFSManager.Properties.Resources.page_white_edit;
            this.mniSetBuildAssigment.Name = "mniSetBuildAssigment";
            this.mniSetBuildAssigment.Size = new System.Drawing.Size(200, 22);
            this.mniSetBuildAssigment.Text = "Set build assigment...";
            this.mniSetBuildAssigment.Click += new System.EventHandler(this.mniBuildAssign_Click);
            // 
            // locateInGlobalListToolStripMenuItem
            // 
            this.locateInGlobalListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniGL_FoundIn,
            this.mniGL_IntegrationBuild});
            this.locateInGlobalListToolStripMenuItem.Name = "locateInGlobalListToolStripMenuItem";
            this.locateInGlobalListToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.locateInGlobalListToolStripMenuItem.Tag = "0";
            this.locateInGlobalListToolStripMenuItem.Text = "Locate in Global List";
            // 
            // mniGL_FoundIn
            // 
            this.mniGL_FoundIn.Name = "mniGL_FoundIn";
            this.mniGL_FoundIn.Size = new System.Drawing.Size(200, 22);
            this.mniGL_FoundIn.Tag = "0";
            this.mniGL_FoundIn.Text = "Locate \'FoundIn\'";
            this.mniGL_FoundIn.Click += new System.EventHandler(this.LocateIn_Click);
            // 
            // mniGL_IntegrationBuild
            // 
            this.mniGL_IntegrationBuild.Name = "mniGL_IntegrationBuild";
            this.mniGL_IntegrationBuild.Size = new System.Drawing.Size(200, 22);
            this.mniGL_IntegrationBuild.Tag = "1";
            this.mniGL_IntegrationBuild.Text = "Locate \'IntegrationBuild\'";
            this.mniGL_IntegrationBuild.Click += new System.EventHandler(this.LocateIn_Click);
            // 
            // locateInTeamBuildsToolStripMenuItem
            // 
            this.locateInTeamBuildsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniTB_FoundIn,
            this.mniTB_IntegrationBuild});
            this.locateInTeamBuildsToolStripMenuItem.Name = "locateInTeamBuildsToolStripMenuItem";
            this.locateInTeamBuildsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.locateInTeamBuildsToolStripMenuItem.Tag = "1";
            this.locateInTeamBuildsToolStripMenuItem.Text = "Locate in Team Builds";
            // 
            // mniTB_FoundIn
            // 
            this.mniTB_FoundIn.Name = "mniTB_FoundIn";
            this.mniTB_FoundIn.Size = new System.Drawing.Size(200, 22);
            this.mniTB_FoundIn.Tag = "0";
            this.mniTB_FoundIn.Text = "Locate \'FoundIn\'";
            this.mniTB_FoundIn.Click += new System.EventHandler(this.LocateIn_Click);
            // 
            // mniTB_IntegrationBuild
            // 
            this.mniTB_IntegrationBuild.Name = "mniTB_IntegrationBuild";
            this.mniTB_IntegrationBuild.Size = new System.Drawing.Size(200, 22);
            this.mniTB_IntegrationBuild.Tag = "1";
            this.mniTB_IntegrationBuild.Text = "Locate \'IntegrationBuild\'";
            this.mniTB_IntegrationBuild.Click += new System.EventHandler(this.LocateIn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(197, 6);
            // 
            // mniRefreshQuery
            // 
            this.mniRefreshQuery.Image = global::TFSManager.Properties.Resources.refresh;
            this.mniRefreshQuery.Name = "mniRefreshQuery";
            this.mniRefreshQuery.Size = new System.Drawing.Size(200, 22);
            this.mniRefreshQuery.Text = "Refresh query";
            this.mniRefreshQuery.Click += new System.EventHandler(this.mniRefreshQuery_Click);
            // 
            // imagesHeader
            // 
            this.imagesHeader.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesHeader.ImageStream")));
            this.imagesHeader.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesHeader.Images.SetKeyName(0, "sort_asc.gif");
            this.imagesHeader.Images.SetKeyName(1, "sort_desc.gif");
            // 
            // toolstrip1
            // 
            this.toolstrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolstrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnSaveQuery,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.cmbQueries,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.cmbTeamProjects,
            this.btnRefresh,
            this.toolStripSeparator3,
            this.btnWIGo});
            this.toolstrip1.Location = new System.Drawing.Point(0, 0);
            this.toolstrip1.Name = "toolstrip1";
            this.toolstrip1.Size = new System.Drawing.Size(601, 25);
            this.toolstrip1.TabIndex = 2;
            this.toolstrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(53, 22);
            this.toolStripButton1.Text = "Open";
            this.toolStripButton1.ToolTipText = "Open query from file...";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnSaveQuery
            // 
            this.btnSaveQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveQuery.Image = global::TFSManager.Properties.Resources.save;
            this.btnSaveQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveQuery.Name = "btnSaveQuery";
            this.btnSaveQuery.Size = new System.Drawing.Size(23, 22);
            this.btnSaveQuery.Text = "Save query";
            this.btnSaveQuery.ToolTipText = "Save query to file";
            this.btnSaveQuery.Click += new System.EventHandler(this.btnSaveQuery_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel2.Text = "Stored queries:";
            // 
            // cmbQueries
            // 
            this.cmbQueries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbQueries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbQueries.AutoToolTip = true;
            this.cmbQueries.MaxDropDownItems = 20;
            this.cmbQueries.Name = "cmbQueries";
            this.cmbQueries.Size = new System.Drawing.Size(121, 25);
            this.cmbQueries.SelectedIndexChanged += new System.EventHandler(this.cmbQueries_SelectedIndexChanged);
            this.cmbQueries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbQueries_KeyDown);
            this.cmbQueries.Leave += new System.EventHandler(this.SynchroQueryText);
            this.cmbQueries.Click += new System.EventHandler(this.cmbQueries_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Team Project:";
            // 
            // cmbTeamProjects
            // 
            this.cmbTeamProjects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTeamProjects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTeamProjects.AutoToolTip = true;
            this.cmbTeamProjects.MaxDropDownItems = 20;
            this.cmbTeamProjects.Name = "cmbTeamProjects";
            this.cmbTeamProjects.Size = new System.Drawing.Size(121, 25);
            this.cmbTeamProjects.SelectedIndexChanged += new System.EventHandler(this.cmbTeamProjects_SelectedIndexChanged);
            this.cmbTeamProjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTeamProjects_KeyDown);
            this.cmbTeamProjects.Leave += new System.EventHandler(this.SynchroTeamProjectText);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TFSManager.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnWIGo
            // 
            this.btnWIGo.Image = ((System.Drawing.Image)(resources.GetObject("btnWIGo.Image")));
            this.btnWIGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWIGo.Name = "btnWIGo";
            this.btnWIGo.Size = new System.Drawing.Size(62, 20);
            this.btnWIGo.Text = "Goto...";
            this.btnWIGo.ToolTipText = "Go to work item by specifing its id";
            this.btnWIGo.Click += new System.EventHandler(this.btnWIGo_Click);
            // 
            // lvWI
            // 
            this.lvWI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvWI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colType,
            this.colTitle,
            this.colChangedDate});
            this.lvWI.ContextMenuStrip = this.menuWorkItems;
            this.lvWI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWI.FullRowSelect = true;
            this.lvWI.HideSelection = false;
            this.lvWI.Location = new System.Drawing.Point(0, 0);
            this.lvWI.Name = "lvWI";
            this.lvWI.ShowItemToolTips = true;
            this.lvWI.Size = new System.Drawing.Size(601, 354);
            this.lvWI.SmallImageList = this.imagesHeader;
            this.lvWI.TabIndex = 3;
            this.lvWI.UseCompatibleStateImageBehavior = false;
            this.lvWI.View = System.Windows.Forms.View.Details;
            this.lvWI.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvWI_MouseDoubleClick);
            this.lvWI.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvWI_ColumnClick);
            // 
            // colID
            // 
            this.colID.Tag = "0";
            this.colID.Text = "ID";
            // 
            // colType
            // 
            this.colType.Tag = "0";
            this.colType.Text = "Type";
            // 
            // colTitle
            // 
            this.colTitle.Tag = "0";
            this.colTitle.Text = "Title";
            this.colTitle.Width = 185;
            // 
            // colChangedDate
            // 
            this.colChangedDate.Tag = "0";
            this.colChangedDate.Text = "Changed date";
            this.colChangedDate.Width = 90;
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "wiq";
            this.ofd.Filter = "Team queries (*.wiq)|*.wiq|All files (*.*)|*.*";
            this.ofd.SupportMultiDottedExtensions = true;
            this.ofd.Title = "Open team query file...";
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitter.Location = new System.Drawing.Point(0, 25);
            this.splitter.Name = "splitter";
            this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.sqlEditor);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.lvWI);
            this.splitter.Size = new System.Drawing.Size(601, 452);
            this.splitter.SplitterDistance = 94;
            this.splitter.TabIndex = 4;
            // 
            // sqlEditor
            // 
            this.sqlEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sqlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlEditor.EnableAutoCompleteForm = false;
            this.sqlEditor.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sqlEditor.Location = new System.Drawing.Point(0, 0);
            this.sqlEditor.Name = "sqlEditor";
            this.sqlEditor.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.sqlEditor.Size = new System.Drawing.Size(601, 94);
            this.sqlEditor.TabIndex = 0;
            this.sqlEditor.Text = "";
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "wiq";
            this.sfd.Filter = "Team queries (*.wiq)|*.wiq|All files (*.*)|*.*";
            this.sfd.SupportMultiDottedExtensions = true;
            this.sfd.Title = "Save team query to file...";
            // 
            // ControlWorkItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.toolstrip1);
            this.Name = "ControlWorkItems";
            this.Size = new System.Drawing.Size(601, 477);
            this.menuWorkItems.ResumeLayout(false);
            this.toolstrip1.ResumeLayout(false);
            this.toolstrip1.PerformLayout();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menuWorkItems;
        private System.Windows.Forms.ToolStripMenuItem mniRemoveBuildAssigment;
        private System.Windows.Forms.ToolStripMenuItem mniSetBuildAssigment;
        private System.Windows.Forms.ToolStripMenuItem locateInGlobalListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniGL_FoundIn;
        private System.Windows.Forms.ToolStripMenuItem mniGL_IntegrationBuild;
        private System.Windows.Forms.ToolStripMenuItem locateInTeamBuildsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniTB_FoundIn;
        private System.Windows.Forms.ToolStripMenuItem mniTB_IntegrationBuild;
        private System.Windows.Forms.ImageList imagesHeader;
        private System.Windows.Forms.ToolStrip toolstrip1;
        private System.Windows.Forms.ListView lvWI;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cmbQueries;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbTeamProjects;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnWIGo;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ColumnHeader colChangedDate;
        private System.Windows.Forms.SplitContainer splitter;
        private UrielGuy.SyntaxHighlightingTextBox.SyntaxHighlightingTextBox sqlEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mniRefreshQuery;
        private System.Windows.Forms.ToolStripButton btnSaveQuery;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}
