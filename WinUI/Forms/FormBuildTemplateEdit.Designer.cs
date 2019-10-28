namespace TFSManager.Forms
{
    partial class FormBuildTemplateEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuildTemplateEdit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.edName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chPostponed = new System.Windows.Forms.CheckBox();
            this.edCmdArgs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edDropFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkBuildAgent = new System.Windows.Forms.LinkLabel();
            this.cmbBuildController = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkBuildDefinition = new System.Windows.Forms.LinkLabel();
            this.cmbBuildDefinition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTeamProject = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chSaveChanges = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edDescription);
            this.groupBox1.Controls.Add(this.edName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 139);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Template";
            // 
            // edDescription
            // 
            this.edDescription.Location = new System.Drawing.Point(13, 78);
            this.edDescription.Multiline = true;
            this.edDescription.Name = "edDescription";
            this.edDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edDescription.Size = new System.Drawing.Size(371, 49);
            this.edDescription.TabIndex = 1;
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(13, 35);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(371, 20);
            this.edName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "&Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "&Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chPostponed);
            this.groupBox2.Controls.Add(this.edCmdArgs);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbPriority);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.edDropFolder);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.linkBuildAgent);
            this.groupBox2.Controls.Add(this.cmbBuildController);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.linkBuildDefinition);
            this.groupBox2.Controls.Add(this.cmbBuildDefinition);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbTeamProject);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 324);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Definition";
            // 
            // chPostponed
            // 
            this.chPostponed.AutoSize = true;
            this.chPostponed.Location = new System.Drawing.Point(13, 303);
            this.chPostponed.Name = "chPostponed";
            this.chPostponed.Size = new System.Drawing.Size(77, 17);
            this.chPostponed.TabIndex = 8;
            this.chPostponed.Text = "Postponed";
            this.chPostponed.UseVisualStyleBackColor = true;
            // 
            // edCmdArgs
            // 
            this.edCmdArgs.Location = new System.Drawing.Point(13, 248);
            this.edCmdArgs.Multiline = true;
            this.edCmdArgs.Name = "edCmdArgs";
            this.edCmdArgs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edCmdArgs.Size = new System.Drawing.Size(371, 49);
            this.edCmdArgs.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "MSBuild command-line arguments (optional):";
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(13, 206);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(370, 21);
            this.cmbPriority.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Priority in queue:";
            // 
            // edDropFolder
            // 
            this.edDropFolder.Location = new System.Drawing.Point(13, 166);
            this.edDropFolder.Name = "edDropFolder";
            this.edDropFolder.Size = new System.Drawing.Size(371, 20);
            this.edDropFolder.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Dro&p folder for this build:";
            // 
            // linkBuildAgent
            // 
            this.linkBuildAgent.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkBuildAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkBuildAgent.AutoSize = true;
            this.linkBuildAgent.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkBuildAgent.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkBuildAgent.Location = new System.Drawing.Point(340, 106);
            this.linkBuildAgent.Name = "linkBuildAgent";
            this.linkBuildAgent.Size = new System.Drawing.Size(43, 13);
            this.linkBuildAgent.TabIndex = 4;
            this.linkBuildAgent.TabStop = true;
            this.linkBuildAgent.Text = "Detail...";
            this.linkBuildAgent.Visible = false;
            this.linkBuildAgent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBuildController_LinkClicked);
            // 
            // cmbBuildController
            // 
            this.cmbBuildController.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbBuildController.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuildController.FormattingEnabled = true;
            this.cmbBuildController.Location = new System.Drawing.Point(13, 122);
            this.cmbBuildController.MaxDropDownItems = 20;
            this.cmbBuildController.Name = "cmbBuildController";
            this.cmbBuildController.Size = new System.Drawing.Size(370, 21);
            this.cmbBuildController.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Build controller:";
            // 
            // linkBuildDefinition
            // 
            this.linkBuildDefinition.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkBuildDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkBuildDefinition.AutoSize = true;
            this.linkBuildDefinition.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkBuildDefinition.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkBuildDefinition.Location = new System.Drawing.Point(340, 62);
            this.linkBuildDefinition.Name = "linkBuildDefinition";
            this.linkBuildDefinition.Size = new System.Drawing.Size(43, 13);
            this.linkBuildDefinition.TabIndex = 2;
            this.linkBuildDefinition.TabStop = true;
            this.linkBuildDefinition.Text = "Detail...";
            this.linkBuildDefinition.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBuildDefinition_LinkClicked);
            // 
            // cmbBuildDefinition
            // 
            this.cmbBuildDefinition.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbBuildDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuildDefinition.FormattingEnabled = true;
            this.cmbBuildDefinition.Location = new System.Drawing.Point(13, 78);
            this.cmbBuildDefinition.MaxDropDownItems = 20;
            this.cmbBuildDefinition.Name = "cmbBuildDefinition";
            this.cmbBuildDefinition.Size = new System.Drawing.Size(370, 21);
            this.cmbBuildDefinition.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Build definition:";
            // 
            // cmbTeamProject
            // 
            this.cmbTeamProject.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbTeamProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeamProject.FormattingEnabled = true;
            this.cmbTeamProject.Location = new System.Drawing.Point(13, 34);
            this.cmbTeamProject.MaxDropDownItems = 20;
            this.cmbTeamProject.Name = "cmbTeamProject";
            this.cmbTeamProject.Size = new System.Drawing.Size(371, 21);
            this.cmbTeamProject.TabIndex = 0;
            this.cmbTeamProject.SelectedIndexChanged += new System.EventHandler(this.cmbTeamProject_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "&Team project:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(307, 470);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(226, 470);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chSaveChanges
            // 
            this.chSaveChanges.AutoSize = true;
            this.chSaveChanges.Location = new System.Drawing.Point(2, 473);
            this.chSaveChanges.Name = "chSaveChanges";
            this.chSaveChanges.Size = new System.Drawing.Size(155, 17);
            this.chSaveChanges.TabIndex = 36;
            this.chSaveChanges.Text = "Save changes to templates";
            this.chSaveChanges.UseVisualStyleBackColor = true;
            // 
            // FormBuildTemplateEdit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 501);
            this.Controls.Add(this.chSaveChanges);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBuildTemplateEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TFS Manager / Team Build Template Detail";
            this.Shown += new System.EventHandler(this.FormBuildTemplateEdit_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edDescription;
        private System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkBuildAgent;
        private System.Windows.Forms.ComboBox cmbBuildController;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkBuildDefinition;
        private System.Windows.Forms.ComboBox cmbBuildDefinition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTeamProject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox edDropFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox edCmdArgs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chPostponed;
        private System.Windows.Forms.CheckBox chSaveChanges;
    }
}