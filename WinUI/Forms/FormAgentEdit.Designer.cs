namespace TFSManager.Forms
{
    partial class FormAgentEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgentEdit));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.edName = new System.Windows.Forms.TextBox();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.edMachineName = new System.Windows.Forms.TextBox();
            this.edPort = new System.Windows.Forms.TextBox();
            this.chRequireSecureChannel = new System.Windows.Forms.CheckBox();
            this.edBuildDirectory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lbQueueCount = new System.Windows.Forms.Label();
            this.edMaxProcesses = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTeamProject = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.edMaxProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ma&x processes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Communications &port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "&Computer name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Display &name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "&Working directory:";
            // 
            // edName
            // 
            this.edName.Location = new System.Drawing.Point(15, 70);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(371, 20);
            this.edName.TabIndex = 1;
            // 
            // edDescription
            // 
            this.edDescription.Location = new System.Drawing.Point(15, 113);
            this.edDescription.Multiline = true;
            this.edDescription.Name = "edDescription";
            this.edDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edDescription.Size = new System.Drawing.Size(371, 64);
            this.edDescription.TabIndex = 2;
            // 
            // edMachineName
            // 
            this.edMachineName.Location = new System.Drawing.Point(15, 200);
            this.edMachineName.Name = "edMachineName";
            this.edMachineName.Size = new System.Drawing.Size(243, 20);
            this.edMachineName.TabIndex = 3;
            // 
            // edPort
            // 
            this.edPort.Location = new System.Drawing.Point(268, 200);
            this.edPort.Name = "edPort";
            this.edPort.Size = new System.Drawing.Size(118, 20);
            this.edPort.TabIndex = 4;
            // 
            // chRequireSecureChannel
            // 
            this.chRequireSecureChannel.AutoSize = true;
            this.chRequireSecureChannel.Location = new System.Drawing.Point(15, 226);
            this.chRequireSecureChannel.Name = "chRequireSecureChannel";
            this.chRequireSecureChannel.Size = new System.Drawing.Size(184, 17);
            this.chRequireSecureChannel.TabIndex = 5;
            this.chRequireSecureChannel.Text = "&Require secure channel (HTTPS)";
            this.chRequireSecureChannel.UseVisualStyleBackColor = true;
            // 
            // edBuildDirectory
            // 
            this.edBuildDirectory.Location = new System.Drawing.Point(15, 267);
            this.edBuildDirectory.Name = "edBuildDirectory";
            this.edBuildDirectory.Size = new System.Drawing.Size(371, 20);
            this.edBuildDirectory.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Agent &status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(15, 307);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(243, 21);
            this.cmbStatus.TabIndex = 7;
            // 
            // lbQueueCount
            // 
            this.lbQueueCount.AutoSize = true;
            this.lbQueueCount.Location = new System.Drawing.Point(264, 310);
            this.lbQueueCount.Name = "lbQueueCount";
            this.lbQueueCount.Size = new System.Drawing.Size(87, 13);
            this.lbQueueCount.TabIndex = 20;
            this.lbQueueCount.Text = "0 builds in queue";
            // 
            // edMaxProcesses
            // 
            this.edMaxProcesses.Location = new System.Drawing.Point(15, 350);
            this.edMaxProcesses.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.edMaxProcesses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edMaxProcesses.Name = "edMaxProcesses";
            this.edMaxProcesses.Size = new System.Drawing.Size(120, 20);
            this.edMaxProcesses.TabIndex = 8;
            this.edMaxProcesses.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(230, 378);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(311, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "&Team project:";
            // 
            // cmbTeamProject
            // 
            this.cmbTeamProject.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmbTeamProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeamProject.FormattingEnabled = true;
            this.cmbTeamProject.Location = new System.Drawing.Point(15, 25);
            this.cmbTeamProject.MaxDropDownItems = 20;
            this.cmbTeamProject.Name = "cmbTeamProject";
            this.cmbTeamProject.Size = new System.Drawing.Size(371, 21);
            this.cmbTeamProject.TabIndex = 0;
            // 
            // FormAgentEdit
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 410);
            this.Controls.Add(this.cmbTeamProject);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.edMaxProcesses);
            this.Controls.Add(this.lbQueueCount);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edBuildDirectory);
            this.Controls.Add(this.chRequireSecureChannel);
            this.Controls.Add(this.edPort);
            this.Controls.Add(this.edMachineName);
            this.Controls.Add(this.edDescription);
            this.Controls.Add(this.edName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAgentEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TFS Manager / Build agent detail";
            this.Shown += new System.EventHandler(this.FormAgentEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.edMaxProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.TextBox edDescription;
        private System.Windows.Forms.TextBox edMachineName;
        private System.Windows.Forms.TextBox edPort;
        private System.Windows.Forms.CheckBox chRequireSecureChannel;
        private System.Windows.Forms.TextBox edBuildDirectory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lbQueueCount;
        private System.Windows.Forms.NumericUpDown edMaxProcesses;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTeamProject;

    }
}