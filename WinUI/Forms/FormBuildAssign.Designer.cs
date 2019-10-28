namespace TFSManager.Forms
{
    partial class FormBuildAssign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuildAssign));
            this.lbCaption = new System.Windows.Forms.Label();
            this.cmbBuilds = new System.Windows.Forms.ComboBox();
            this.lbBuild = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.llAssign2 = new System.Windows.Forms.LinkLabel();
            this.llAssign1 = new System.Windows.Forms.LinkLabel();
            this.llClear2 = new System.Windows.Forms.LinkLabel();
            this.llSet2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.llClear1 = new System.Windows.Forms.LinkLabel();
            this.llSet1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCaption
            // 
            this.lbCaption.AutoSize = true;
            this.lbCaption.Location = new System.Drawing.Point(12, 9);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(124, 13);
            this.lbCaption.TabIndex = 0;
            this.lbCaption.Text = "Allowed team \'{0}\' builds:";
            // 
            // cmbBuilds
            // 
            this.cmbBuilds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBuilds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuilds.FormattingEnabled = true;
            this.cmbBuilds.Location = new System.Drawing.Point(12, 30);
            this.cmbBuilds.Name = "cmbBuilds";
            this.cmbBuilds.Size = new System.Drawing.Size(516, 21);
            this.cmbBuilds.TabIndex = 0;
            this.cmbBuilds.SelectedIndexChanged += new System.EventHandler(this.cmbBuilds_SelectedIndexChanged);
            // 
            // lbBuild
            // 
            this.lbBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBuild.BackColor = System.Drawing.SystemColors.Control;
            this.lbBuild.Location = new System.Drawing.Point(12, 61);
            this.lbBuild.Multiline = true;
            this.lbBuild.Name = "lbBuild";
            this.lbBuild.ReadOnly = true;
            this.lbBuild.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lbBuild.Size = new System.Drawing.Size(516, 229);
            this.lbBuild.TabIndex = 1;
            this.lbBuild.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 348);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 33);
            this.panel1.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(460, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(379, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.llAssign2);
            this.panel2.Controls.Add(this.llAssign1);
            this.panel2.Controls.Add(this.llClear2);
            this.panel2.Controls.Add(this.llSet2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.llClear1);
            this.panel2.Controls.Add(this.llSet1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 296);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 52);
            this.panel2.TabIndex = 10;
            // 
            // llAssign2
            // 
            this.llAssign2.AutoSize = true;
            this.llAssign2.Location = new System.Drawing.Point(225, 25);
            this.llAssign2.Name = "llAssign2";
            this.llAssign2.Size = new System.Drawing.Size(0, 13);
            this.llAssign2.TabIndex = 18;
            this.llAssign2.Tag = "1";
            this.llAssign2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NavigateTo_Click);
            // 
            // llAssign1
            // 
            this.llAssign1.AutoSize = true;
            this.llAssign1.Location = new System.Drawing.Point(225, 4);
            this.llAssign1.Name = "llAssign1";
            this.llAssign1.Size = new System.Drawing.Size(0, 13);
            this.llAssign1.TabIndex = 17;
            this.llAssign1.Tag = "0";
            this.llAssign1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NavigateTo_Click);
            // 
            // llClear2
            // 
            this.llClear2.AutoSize = true;
            this.llClear2.Location = new System.Drawing.Point(149, 25);
            this.llClear2.Name = "llClear2";
            this.llClear2.Size = new System.Drawing.Size(31, 13);
            this.llClear2.TabIndex = 15;
            this.llClear2.TabStop = true;
            this.llClear2.Tag = "1";
            this.llClear2.Text = "Clear";
            this.llClear2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Clear_Clicked);
            // 
            // llSet2
            // 
            this.llSet2.AutoSize = true;
            this.llSet2.Location = new System.Drawing.Point(188, 25);
            this.llSet2.Name = "llSet2";
            this.llSet2.Size = new System.Drawing.Size(23, 13);
            this.llSet2.TabIndex = 14;
            this.llSet2.TabStop = true;
            this.llSet2.Tag = "1";
            this.llSet2.Text = "Set";
            this.llSet2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Set_Clicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Assign to \'IntegrationBuild\' :";
            // 
            // llClear1
            // 
            this.llClear1.AutoSize = true;
            this.llClear1.Location = new System.Drawing.Point(149, 4);
            this.llClear1.Name = "llClear1";
            this.llClear1.Size = new System.Drawing.Size(31, 13);
            this.llClear1.TabIndex = 11;
            this.llClear1.TabStop = true;
            this.llClear1.Tag = "0";
            this.llClear1.Text = "Clear";
            this.llClear1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Clear_Clicked);
            // 
            // llSet1
            // 
            this.llSet1.AutoSize = true;
            this.llSet1.Location = new System.Drawing.Point(188, 4);
            this.llSet1.Name = "llSet1";
            this.llSet1.Size = new System.Drawing.Size(23, 13);
            this.llSet1.TabIndex = 10;
            this.llSet1.TabStop = true;
            this.llSet1.Tag = "0";
            this.llSet1.Text = "Set";
            this.llSet1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Set_Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Assign to \'FoundIn\' :";
            // 
            // FormBuildAssign
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(544, 381);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbBuild);
            this.Controls.Add(this.cmbBuilds);
            this.Controls.Add(this.lbCaption);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBuildAssign";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TFS Manager / Assign build to work item(s)";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.ComboBox cmbBuilds;
        private System.Windows.Forms.TextBox lbBuild;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel llClear2;
        private System.Windows.Forms.LinkLabel llSet2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llClear1;
        private System.Windows.Forms.LinkLabel llSet1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llAssign2;
        private System.Windows.Forms.LinkLabel llAssign1;
    }
}