namespace TFSManager.Controls
{
    partial class ControlTeamBuilds
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTeamBuilds));
            this.menuDefinitions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imagesToolbar = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBuildAgents = new System.Windows.Forms.ToolStripButton();
            this.btnBuildDefinitions = new System.Windows.Forms.ToolStripButton();
            this.btnTeamBuilds = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.controlBuilds = new TFSManager.Controls.ControlBuilds();
            this.controlDefinitions = new TFSManager.Controls.ControlBuildDefinitions();
            this.controlAgents = new TFSManager.Controls.ControlBuildAgents();
            this.controlTeamBuildFilterPanel = new TFSManager.Controls.TeamBiuild.ControlTeamBuildFilterPanel();
            this.toolStrip1.SuspendLayout();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuDefinitions
            // 
            this.menuDefinitions.Name = "menuDefinitions";
            this.menuDefinitions.Size = new System.Drawing.Size(61, 4);
            // 
            // imagesToolbar
            // 
            this.imagesToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imagesToolbar.ImageSize = new System.Drawing.Size(16, 16);
            this.imagesToolbar.TransparentColor = System.Drawing.Color.Magenta;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBuildAgents,
            this.btnBuildDefinitions,
            this.btnTeamBuilds,
            this.toolStripSeparator1,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(826, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBuildAgents
            // 
            this.btnBuildAgents.Image = ((System.Drawing.Image)(resources.GetObject("btnBuildAgents.Image")));
            this.btnBuildAgents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuildAgents.Name = "btnBuildAgents";
            this.btnBuildAgents.Size = new System.Drawing.Size(94, 22);
            this.btnBuildAgents.Tag = "0";
            this.btnBuildAgents.Text = "Build Agents";
            this.btnBuildAgents.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnBuildDefinitions
            // 
            this.btnBuildDefinitions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuildDefinitions.Image")));
            this.btnBuildDefinitions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuildDefinitions.Name = "btnBuildDefinitions";
            this.btnBuildDefinitions.Size = new System.Drawing.Size(114, 22);
            this.btnBuildDefinitions.Tag = "1";
            this.btnBuildDefinitions.Text = "Build Definitions";
            this.btnBuildDefinitions.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnTeamBuilds
            // 
            this.btnTeamBuilds.Image = ((System.Drawing.Image)(resources.GetObject("btnTeamBuilds.Image")));
            this.btnTeamBuilds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTeamBuilds.Name = "btnTeamBuilds";
            this.btnTeamBuilds.Size = new System.Drawing.Size(92, 22);
            this.btnTeamBuilds.Tag = "2";
            this.btnTeamBuilds.Text = "Team Builds";
            this.btnTeamBuilds.Click += new System.EventHandler(this.ButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TFSManager.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitter.Location = new System.Drawing.Point(0, 25);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.controlBuilds);
            this.splitter.Panel1.Controls.Add(this.controlDefinitions);
            this.splitter.Panel1.Controls.Add(this.controlAgents);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.controlTeamBuildFilterPanel);
            this.splitter.Size = new System.Drawing.Size(826, 479);
            this.splitter.SplitterDistance = 590;
            this.splitter.TabIndex = 11;
            // 
            // controlBuilds
            // 
            this.controlBuilds.Location = new System.Drawing.Point(53, 78);
            this.controlBuilds.Name = "controlBuilds";
            this.controlBuilds.Size = new System.Drawing.Size(487, 382);
            this.controlBuilds.TabIndex = 8;
            // 
            // controlDefinitions
            // 
            this.controlDefinitions.Location = new System.Drawing.Point(31, 45);
            this.controlDefinitions.Name = "controlDefinitions";
            this.controlDefinitions.Size = new System.Drawing.Size(478, 414);
            this.controlDefinitions.TabIndex = 7;
            // 
            // controlAgents
            // 
            this.controlAgents.Location = new System.Drawing.Point(13, 12);
            this.controlAgents.Name = "controlAgents";
            this.controlAgents.Size = new System.Drawing.Size(471, 344);
            this.controlAgents.TabIndex = 6;
            // 
            // controlTeamBuildFilterPanel
            // 
            this.controlTeamBuildFilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlTeamBuildFilterPanel.Location = new System.Drawing.Point(0, 0);
            this.controlTeamBuildFilterPanel.Name = "controlTeamBuildFilterPanel";
            this.controlTeamBuildFilterPanel.Size = new System.Drawing.Size(232, 479);
            this.controlTeamBuildFilterPanel.TabIndex = 10;
            // 
            // ControlTeamBuilds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ControlTeamBuilds";
            this.Size = new System.Drawing.Size(826, 504);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip menuDefinitions;
        private System.Windows.Forms.ImageList imagesToolbar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton btnBuildAgents;
        public System.Windows.Forms.ToolStripButton btnBuildDefinitions;
        public System.Windows.Forms.ToolStripButton btnTeamBuilds;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton btnRefresh;
        private TFSManager.Controls.TeamBiuild.ControlTeamBuildFilterPanel controlTeamBuildFilterPanel;
        private System.Windows.Forms.SplitContainer splitter;
        private ControlBuilds controlBuilds;
        private ControlBuildDefinitions controlDefinitions;
        private ControlBuildAgents controlAgents;
    }
}
