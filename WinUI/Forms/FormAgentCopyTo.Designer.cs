namespace TFSManager.Forms
{
    partial class FormAgentCopyTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgentCopyTo));
            this.lbSourceTeamProject = new System.Windows.Forms.Label();
            this.lbSourceBuildAgent = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkSourceAgentDetails = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkAgentDetails = new System.Windows.Forms.LinkLabel();
            this.cmbTargetTeamProject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSourceTeamProject
            // 
            this.lbSourceTeamProject.AutoSize = true;
            this.lbSourceTeamProject.Location = new System.Drawing.Point(14, 22);
            this.lbSourceTeamProject.Name = "lbSourceTeamProject";
            this.lbSourceTeamProject.Size = new System.Drawing.Size(72, 13);
            this.lbSourceTeamProject.TabIndex = 0;
            this.lbSourceTeamProject.Text = "Team project:";
            // 
            // lbSourceBuildAgent
            // 
            this.lbSourceBuildAgent.AutoSize = true;
            this.lbSourceBuildAgent.Location = new System.Drawing.Point(14, 51);
            this.lbSourceBuildAgent.Name = "lbSourceBuildAgent";
            this.lbSourceBuildAgent.Size = new System.Drawing.Size(63, 13);
            this.lbSourceBuildAgent.TabIndex = 1;
            this.lbSourceBuildAgent.Text = "Build agent:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkSourceAgentDetails);
            this.groupBox1.Controls.Add(this.lbSourceTeamProject);
            this.groupBox1.Controls.Add(this.lbSourceBuildAgent);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // linkSourceAgentDetails
            // 
            this.linkSourceAgentDetails.AutoSize = true;
            this.linkSourceAgentDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSourceAgentDetails.Location = new System.Drawing.Point(208, 51);
            this.linkSourceAgentDetails.Name = "linkSourceAgentDetails";
            this.linkSourceAgentDetails.Size = new System.Drawing.Size(72, 13);
            this.linkSourceAgentDetails.TabIndex = 2;
            this.linkSourceAgentDetails.TabStop = true;
            this.linkSourceAgentDetails.Text = "View details...";
            this.linkSourceAgentDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSourceAgentDetails_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkAgentDetails);
            this.groupBox2.Controls.Add(this.cmbTargetTeamProject);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 74);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // linkAgentDetails
            // 
            this.linkAgentDetails.AutoSize = true;
            this.linkAgentDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkAgentDetails.Location = new System.Drawing.Point(116, 51);
            this.linkAgentDetails.Name = "linkAgentDetails";
            this.linkAgentDetails.Size = new System.Drawing.Size(67, 13);
            this.linkAgentDetails.TabIndex = 1;
            this.linkAgentDetails.TabStop = true;
            this.linkAgentDetails.Text = "Edit details...";
            this.linkAgentDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAgentDetails_LinkClicked);
            // 
            // cmbTargetTeamProject
            // 
            this.cmbTargetTeamProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetTeamProject.FormattingEnabled = true;
            this.cmbTargetTeamProject.Location = new System.Drawing.Point(119, 19);
            this.cmbTargetTeamProject.MaxDropDownItems = 20;
            this.cmbTargetTeamProject.Name = "cmbTargetTeamProject";
            this.cmbTargetTeamProject.Size = new System.Drawing.Size(213, 21);
            this.cmbTargetTeamProject.TabIndex = 0;
            this.cmbTargetTeamProject.SelectedIndexChanged += new System.EventHandler(this.cmbTargetTeamProject_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Team project:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Build agent details:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 34);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(12, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FormAgentCopyTo
            // 
            this.AcceptButton = this.btnCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(366, 219);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAgentCopyTo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TFS Manager / Copy build agent to target team project";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbSourceTeamProject;
        private System.Windows.Forms.Label lbSourceBuildAgent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbTargetTeamProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.LinkLabel linkAgentDetails;
        private System.Windows.Forms.LinkLabel linkSourceAgentDetails;
    }
}