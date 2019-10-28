namespace TFSManager.Controls
{
    partial class ControlBuildDefinitions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBuildDefinitions));
            this.lvDefinitions = new System.Windows.Forms.ListView();
            this.colDef_Name = new System.Windows.Forms.ColumnHeader();
            this.colDef_Enabled = new System.Windows.Forms.ColumnHeader();
            this.colDef_SchedulesCount = new System.Windows.Forms.ColumnHeader();
            this.colDef_DefAgent = new System.Windows.Forms.ColumnHeader();
            this.colDef_Uri = new System.Windows.Forms.ColumnHeader();
            this.menuDefinitions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniNewDefinition = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEditDefinition = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEditProjectFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniCreateBuildTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.quickChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniChangeDefaultAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesHeader = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvBuildTemplates = new System.Windows.Forms.ListView();
            this.colTemplateName = new System.Windows.Forms.ColumnHeader();
            this.colTemplateDefName = new System.Windows.Forms.ColumnHeader();
            this.colTemplateAgent = new System.Windows.Forms.ColumnHeader();
            this.colTemplateComputer = new System.Windows.Forms.ColumnHeader();
            this.colDefaultDropLocation = new System.Windows.Forms.ColumnHeader();
            this.colTemplateParameters = new System.Windows.Forms.ColumnHeader();
            this.menuTemplates = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniEditBuildTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCopyBuildTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDeleteBuildTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniReloadList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniQueueBuildTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniQueueMultiBuildTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.quickChangesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniChangeDefaultAgentTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniChangeDefaultDropLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportTemplates = new System.Windows.Forms.ToolStripButton();
            this.btnOpenTemplates = new System.Windows.Forms.ToolStripButton();
            this.lbCurrentTemplate = new System.Windows.Forms.ToolStripLabel();
            this.saveTD = new System.Windows.Forms.SaveFileDialog();
            this.openTD = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuDefinitions.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuTemplates.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDefinitions
            // 
            this.lvDefinitions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvDefinitions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDef_Name,
            this.colDef_Enabled,
            this.colDef_SchedulesCount,
            this.colDef_DefAgent,
            this.colDef_Uri});
            this.lvDefinitions.ContextMenuStrip = this.menuDefinitions;
            this.lvDefinitions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDefinitions.FullRowSelect = true;
            this.lvDefinitions.HideSelection = false;
            this.lvDefinitions.Location = new System.Drawing.Point(0, 0);
            this.lvDefinitions.Name = "lvDefinitions";
            this.lvDefinitions.Size = new System.Drawing.Size(670, 272);
            this.lvDefinitions.SmallImageList = this.imagesHeader;
            this.lvDefinitions.TabIndex = 4;
            this.lvDefinitions.Tag = "1";
            this.lvDefinitions.UseCompatibleStateImageBehavior = false;
            this.lvDefinitions.View = System.Windows.Forms.View.Details;
            this.lvDefinitions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvDefinitions_MouseDoubleClick);
            this.lvDefinitions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDefinitions_ColumnClick);
            this.lvDefinitions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvDefinitions_KeyDown);
            // 
            // colDef_Name
            // 
            this.colDef_Name.Text = "Name";
            this.colDef_Name.Width = 176;
            // 
            // colDef_Enabled
            // 
            this.colDef_Enabled.Text = "Enabled";
            // 
            // colDef_SchedulesCount
            // 
            this.colDef_SchedulesCount.Text = "Schedules count";
            this.colDef_SchedulesCount.Width = 100;
            // 
            // colDef_DefAgent
            // 
            this.colDef_DefAgent.Text = "Default agent";
            this.colDef_DefAgent.Width = 80;
            // 
            // colDef_Uri
            // 
            this.colDef_Uri.Text = "Uri";
            this.colDef_Uri.Width = 100;
            // 
            // menuDefinitions
            // 
            this.menuDefinitions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniNewDefinition,
            this.mniEditDefinition,
            this.mniEditProjectFile,
            this.toolStripMenuItem1,
            this.mniCreateBuildTemplate,
            this.quickChangesToolStripMenuItem});
            this.menuDefinitions.Name = "menuList";
            this.menuDefinitions.Size = new System.Drawing.Size(201, 120);
            this.menuDefinitions.Opening += new System.ComponentModel.CancelEventHandler(this.menuList_Opening);
            // 
            // mniNewDefinition
            // 
            this.mniNewDefinition.Name = "mniNewDefinition";
            this.mniNewDefinition.Size = new System.Drawing.Size(200, 22);
            this.mniNewDefinition.Text = "New Definition";
            this.mniNewDefinition.Click += new System.EventHandler(this.mniNewDefinition_Click);
            // 
            // mniEditDefinition
            // 
            this.mniEditDefinition.Name = "mniEditDefinition";
            this.mniEditDefinition.Size = new System.Drawing.Size(200, 22);
            this.mniEditDefinition.Text = "Edit...";
            this.mniEditDefinition.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // mniEditProjectFile
            // 
            this.mniEditProjectFile.Image = ((System.Drawing.Image)(resources.GetObject("mniEditProjectFile.Image")));
            this.mniEditProjectFile.Name = "mniEditProjectFile";
            this.mniEditProjectFile.Size = new System.Drawing.Size(200, 22);
            this.mniEditProjectFile.Text = "Edit Project File...";
            this.mniEditProjectFile.Click += new System.EventHandler(this.mniEditProjectFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
            // 
            // mniCreateBuildTemplate
            // 
            this.mniCreateBuildTemplate.Name = "mniCreateBuildTemplate";
            this.mniCreateBuildTemplate.Size = new System.Drawing.Size(200, 22);
            this.mniCreateBuildTemplate.Text = "Create Build Template...";
            this.mniCreateBuildTemplate.Click += new System.EventHandler(this.mniCreateBuildTemplate_Click);
            // 
            // quickChangesToolStripMenuItem
            // 
            this.quickChangesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniChangeDefaultAgent});
            this.quickChangesToolStripMenuItem.Name = "quickChangesToolStripMenuItem";
            this.quickChangesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.quickChangesToolStripMenuItem.Text = "Quick Changes";
            // 
            // mniChangeDefaultAgent
            // 
            this.mniChangeDefaultAgent.Name = "mniChangeDefaultAgent";
            this.mniChangeDefaultAgent.Size = new System.Drawing.Size(191, 22);
            this.mniChangeDefaultAgent.Text = "Change Default Agent";
            // 
            // imagesHeader
            // 
            this.imagesHeader.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesHeader.ImageStream")));
            this.imagesHeader.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesHeader.Images.SetKeyName(0, "sort_asc.gif");
            this.imagesHeader.Images.SetKeyName(1, "sort_desc.gif");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvDefinitions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvBuildTemplates);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(670, 436);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 5;
            // 
            // lvBuildTemplates
            // 
            this.lvBuildTemplates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvBuildTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTemplateName,
            this.colTemplateDefName,
            this.colTemplateAgent,
            this.colTemplateComputer,
            this.colDefaultDropLocation,
            this.colTemplateParameters});
            this.lvBuildTemplates.ContextMenuStrip = this.menuTemplates;
            this.lvBuildTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBuildTemplates.FullRowSelect = true;
            this.lvBuildTemplates.HideSelection = false;
            this.lvBuildTemplates.Location = new System.Drawing.Point(0, 25);
            this.lvBuildTemplates.Name = "lvBuildTemplates";
            this.lvBuildTemplates.Size = new System.Drawing.Size(670, 135);
            this.lvBuildTemplates.SmallImageList = this.imagesHeader;
            this.lvBuildTemplates.TabIndex = 7;
            this.lvBuildTemplates.Tag = "1";
            this.lvBuildTemplates.UseCompatibleStateImageBehavior = false;
            this.lvBuildTemplates.View = System.Windows.Forms.View.Details;
            this.lvBuildTemplates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvBuildTemplates_MouseDoubleClick);
            this.lvBuildTemplates.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvBuildTemplates_ColumnClick);
            this.lvBuildTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvBuildTemplates_KeyDown);
            // 
            // colTemplateName
            // 
            this.colTemplateName.Text = "Template Name";
            this.colTemplateName.Width = 179;
            // 
            // colTemplateDefName
            // 
            this.colTemplateDefName.Text = "Definition name";
            this.colTemplateDefName.Width = 110;
            // 
            // colTemplateAgent
            // 
            this.colTemplateAgent.Text = "Agent";
            this.colTemplateAgent.Width = 70;
            // 
            // colTemplateComputer
            // 
            this.colTemplateComputer.Text = "Computer";
            this.colTemplateComputer.Width = 80;
            // 
            // colDefaultDropLocation
            // 
            this.colDefaultDropLocation.Text = "Default Drop Location";
            this.colDefaultDropLocation.Width = 120;
            // 
            // colTemplateParameters
            // 
            this.colTemplateParameters.Text = "Parameters";
            this.colTemplateParameters.Width = 134;
            // 
            // menuTemplates
            // 
            this.menuTemplates.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniEditBuildTemplate,
            this.mniCopyBuildTemplate,
            this.mniDeleteBuildTemplate,
            this.toolStripSeparator1,
            this.mniReloadList,
            this.toolStripMenuItem2,
            this.mniQueueBuildTemplate,
            this.mniQueueMultiBuildTemplate,
            this.toolStripSeparator3,
            this.quickChangesToolStripMenuItem1});
            this.menuTemplates.Name = "menuTemplates";
            this.menuTemplates.Size = new System.Drawing.Size(254, 176);
            this.menuTemplates.Opening += new System.ComponentModel.CancelEventHandler(this.menuTemplates_Opening);
            // 
            // mniEditBuildTemplate
            // 
            this.mniEditBuildTemplate.Name = "mniEditBuildTemplate";
            this.mniEditBuildTemplate.Size = new System.Drawing.Size(253, 22);
            this.mniEditBuildTemplate.Text = "Edit Template";
            this.mniEditBuildTemplate.Click += new System.EventHandler(this.mniEditBuildTemplate_Click);
            // 
            // mniCopyBuildTemplate
            // 
            this.mniCopyBuildTemplate.Name = "mniCopyBuildTemplate";
            this.mniCopyBuildTemplate.Size = new System.Drawing.Size(253, 22);
            this.mniCopyBuildTemplate.Text = "Copy Template";
            this.mniCopyBuildTemplate.Click += new System.EventHandler(this.mniCopyBuildTemplate_Click);
            // 
            // mniDeleteBuildTemplate
            // 
            this.mniDeleteBuildTemplate.Name = "mniDeleteBuildTemplate";
            this.mniDeleteBuildTemplate.Size = new System.Drawing.Size(253, 22);
            this.mniDeleteBuildTemplate.Text = "Delete Template(s)";
            this.mniDeleteBuildTemplate.Click += new System.EventHandler(this.mniDeleteBuildTemplate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // mniReloadList
            // 
            this.mniReloadList.Name = "mniReloadList";
            this.mniReloadList.Size = new System.Drawing.Size(253, 22);
            this.mniReloadList.Text = "Reload list";
            this.mniReloadList.Click += new System.EventHandler(this.mniReloadList_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(250, 6);
            // 
            // mniQueueBuildTemplate
            // 
            this.mniQueueBuildTemplate.Name = "mniQueueBuildTemplate";
            this.mniQueueBuildTemplate.Size = new System.Drawing.Size(253, 22);
            this.mniQueueBuildTemplate.Text = "Queue Build Template...";
            this.mniQueueBuildTemplate.Click += new System.EventHandler(this.mniQueueBuildTemplate_Click);
            // 
            // mniQueueMultiBuildTemplate
            // 
            this.mniQueueMultiBuildTemplate.Name = "mniQueueMultiBuildTemplate";
            this.mniQueueMultiBuildTemplate.Size = new System.Drawing.Size(253, 22);
            this.mniQueueMultiBuildTemplate.Text = "Queue Multiple Build Templates...";
            this.mniQueueMultiBuildTemplate.Click += new System.EventHandler(this.mniQueueMultiBuildTemplate_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(250, 6);
            // 
            // quickChangesToolStripMenuItem1
            // 
            this.quickChangesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniChangeDefaultAgentTemplate,
            this.mniChangeDefaultDropLocation});
            this.quickChangesToolStripMenuItem1.Name = "quickChangesToolStripMenuItem1";
            this.quickChangesToolStripMenuItem1.Size = new System.Drawing.Size(253, 22);
            this.quickChangesToolStripMenuItem1.Text = "Quick Changes";
            // 
            // mniChangeDefaultAgentTemplate
            // 
            this.mniChangeDefaultAgentTemplate.Name = "mniChangeDefaultAgentTemplate";
            this.mniChangeDefaultAgentTemplate.Size = new System.Drawing.Size(243, 22);
            this.mniChangeDefaultAgentTemplate.Text = "Change Default Agent";
            // 
            // mniChangeDefaultDropLocation
            // 
            this.mniChangeDefaultDropLocation.Name = "mniChangeDefaultDropLocation";
            this.mniChangeDefaultDropLocation.Size = new System.Drawing.Size(243, 22);
            this.mniChangeDefaultDropLocation.Text = "Change Default Drop Location...";
            this.mniChangeDefaultDropLocation.Click += new System.EventHandler(this.mniChangeDefaultDropLocation_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.btnExportTemplates,
            this.btnOpenTemplates,
            this.lbCurrentTemplate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(670, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(147, 22);
            this.toolStripLabel1.Text = "Build Definition Templates";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExportTemplates
            // 
            this.btnExportTemplates.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExportTemplates.Image = global::TFSManager.Properties.Resources.export;
            this.btnExportTemplates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportTemplates.Name = "btnExportTemplates";
            this.btnExportTemplates.Size = new System.Drawing.Size(118, 22);
            this.btnExportTemplates.Text = "Export Templates";
            this.btnExportTemplates.Click += new System.EventHandler(this.btnExportTemplates_Click);
            // 
            // btnOpenTemplates
            // 
            this.btnOpenTemplates.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOpenTemplates.Image = global::TFSManager.Properties.Resources.open;
            this.btnOpenTemplates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenTemplates.Name = "btnOpenTemplates";
            this.btnOpenTemplates.Size = new System.Drawing.Size(114, 22);
            this.btnOpenTemplates.Text = "Open Templates";
            this.btnOpenTemplates.Click += new System.EventHandler(this.btnOpenTemplates_Click);
            // 
            // lbCurrentTemplate
            // 
            this.lbCurrentTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lbCurrentTemplate.Image = global::TFSManager.Properties.Resources.about;
            this.lbCurrentTemplate.Name = "lbCurrentTemplate";
            this.lbCurrentTemplate.Size = new System.Drawing.Size(16, 22);
            this.lbCurrentTemplate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbCurrentTemplate_MouseDown);
            // 
            // saveTD
            // 
            this.saveTD.DefaultExt = "templates";
            this.saveTD.Filter = "Build templates files (*.templates)|*.templates|All files|*.*";
            this.saveTD.SupportMultiDottedExtensions = true;
            this.saveTD.Title = "Export team build templates to file";
            // 
            // openTD
            // 
            this.openTD.DefaultExt = "templates";
            this.openTD.Filter = "Build templates files (*.templates)|*.templates|All files|*.*";
            this.openTD.SupportMultiDottedExtensions = true;
            this.openTD.Title = "Open team build templates file";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 500;
            this.toolTip1.ShowAlways = true;
            // 
            // ControlBuildDefinitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ControlBuildDefinitions";
            this.Size = new System.Drawing.Size(670, 436);
            this.menuDefinitions.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.menuTemplates.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDefinitions;
        private System.Windows.Forms.ColumnHeader colDef_Name;
        private System.Windows.Forms.ColumnHeader colDef_Enabled;
        private System.Windows.Forms.ColumnHeader colDef_SchedulesCount;
        private System.Windows.Forms.ColumnHeader colDef_DefAgent;
        private System.Windows.Forms.ColumnHeader colDef_Uri;
        private System.Windows.Forms.ContextMenuStrip menuDefinitions;
        private System.Windows.Forms.ToolStripMenuItem mniNewDefinition;
        private System.Windows.Forms.ToolStripMenuItem mniEditDefinition;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvBuildTemplates;
        private System.Windows.Forms.ColumnHeader colTemplateName;
        private System.Windows.Forms.ColumnHeader colTemplateDefName;
        private System.Windows.Forms.SaveFileDialog saveTD;
        private System.Windows.Forms.OpenFileDialog openTD;
        private System.Windows.Forms.ColumnHeader colTemplateComputer;
        private System.Windows.Forms.ColumnHeader colTemplateParameters;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mniCreateBuildTemplate;
        private System.Windows.Forms.ColumnHeader colTemplateAgent;
        private System.Windows.Forms.ContextMenuStrip menuTemplates;
        private System.Windows.Forms.ToolStripMenuItem mniQueueBuildTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mniCopyBuildTemplate;
        private System.Windows.Forms.ToolStripMenuItem mniEditBuildTemplate;
        private System.Windows.Forms.ToolStripMenuItem mniDeleteBuildTemplate;
        private System.Windows.Forms.ImageList imagesHeader;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniReloadList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lbCurrentTemplate;
        private System.Windows.Forms.ToolStripButton btnExportTemplates;
        private System.Windows.Forms.ToolStripButton btnOpenTemplates;
        private System.Windows.Forms.ToolStripMenuItem mniEditProjectFile;
        private System.Windows.Forms.ToolStripMenuItem mniQueueMultiBuildTemplate;
        private System.Windows.Forms.ToolStripMenuItem quickChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniChangeDefaultAgent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem quickChangesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mniChangeDefaultAgentTemplate;
        private System.Windows.Forms.ToolStripMenuItem mniChangeDefaultDropLocation;
        private System.Windows.Forms.ColumnHeader colDefaultDropLocation;
    }
}
