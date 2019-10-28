using TFSManager.Controls;

namespace TFSManager.Forms
{
    partial class FormProjectFileCreateWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProjectFileCreateWizard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkOptions = new System.Windows.Forms.LinkLabel();
            this.linkConfigurations = new System.Windows.Forms.LinkLabel();
            this.linkSelections = new System.Windows.Forms.LinkLabel();
            this.panelControlsX = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.controlConfigurations = new TFSManager.Controls.ControlMSBuildProjConfigurations();
            this.controlSelections = new TFSManager.Controls.ControlMSBuildProjSelections();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelControlsX.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 62);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(46, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select and order solutions to build";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.linkOptions);
            this.panel2.Controls.Add(this.linkConfigurations);
            this.panel2.Controls.Add(this.linkSelections);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 429);
            this.panel2.TabIndex = 1;
            // 
            // linkOptions
            // 
            this.linkOptions.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkOptions.BackColor = System.Drawing.SystemColors.ControlDark;
            this.linkOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkOptions.ForeColor = System.Drawing.Color.Black;
            this.linkOptions.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkOptions.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkOptions.LinkColor = System.Drawing.Color.Black;
            this.linkOptions.Location = new System.Drawing.Point(0, 56);
            this.linkOptions.Name = "linkOptions";
            this.linkOptions.Size = new System.Drawing.Size(178, 19);
            this.linkOptions.TabIndex = 2;
            this.linkOptions.Tag = "2";
            this.linkOptions.Text = "   Options";
            this.linkOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkOptions.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkOptions.Click += new System.EventHandler(this.Link_Click);
            // 
            // linkConfigurations
            // 
            this.linkConfigurations.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkConfigurations.BackColor = System.Drawing.SystemColors.ControlDark;
            this.linkConfigurations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkConfigurations.ForeColor = System.Drawing.Color.Black;
            this.linkConfigurations.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkConfigurations.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkConfigurations.LinkColor = System.Drawing.Color.Black;
            this.linkConfigurations.Location = new System.Drawing.Point(0, 34);
            this.linkConfigurations.Name = "linkConfigurations";
            this.linkConfigurations.Size = new System.Drawing.Size(178, 19);
            this.linkConfigurations.TabIndex = 1;
            this.linkConfigurations.Tag = "1";
            this.linkConfigurations.Text = "   Configurations";
            this.linkConfigurations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkConfigurations.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkConfigurations.Click += new System.EventHandler(this.Link_Click);
            // 
            // linkSelections
            // 
            this.linkSelections.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkSelections.BackColor = System.Drawing.SystemColors.ControlDark;
            this.linkSelections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkSelections.ForeColor = System.Drawing.Color.Black;
            this.linkSelections.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkSelections.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkSelections.LinkColor = System.Drawing.Color.Black;
            this.linkSelections.Location = new System.Drawing.Point(0, 12);
            this.linkSelections.Name = "linkSelections";
            this.linkSelections.Size = new System.Drawing.Size(178, 19);
            this.linkSelections.TabIndex = 0;
            this.linkSelections.Tag = "0";
            this.linkSelections.Text = "   Selections";
            this.linkSelections.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkSelections.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkSelections.Click += new System.EventHandler(this.Link_Click);
            // 
            // panelControlsX
            // 
            this.panelControlsX.BackColor = System.Drawing.SystemColors.Control;
            this.panelControlsX.Controls.Add(this.panelControls);
            this.panelControlsX.Location = new System.Drawing.Point(180, 62);
            this.panelControlsX.Name = "panelControlsX";
            this.panelControlsX.Size = new System.Drawing.Size(515, 377);
            this.panelControlsX.TabIndex = 2;
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControls.Controls.Add(this.controlConfigurations);
            this.panelControls.Controls.Add(this.controlSelections);
            this.panelControls.Location = new System.Drawing.Point(12, 12);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(490, 361);
            this.panelControls.TabIndex = 1;
            // 
            // controlConfigurations
            // 
            this.controlConfigurations.Location = new System.Drawing.Point(16, 104);
            this.controlConfigurations.Name = "controlConfigurations";
            this.controlConfigurations.Size = new System.Drawing.Size(319, 283);
            this.controlConfigurations.TabIndex = 1;
            this.controlConfigurations.Visible = false;
            // 
            // controlSelections
            // 
            this.controlSelections.Location = new System.Drawing.Point(3, 3);
            this.controlSelections.Name = "controlSelections";
            this.controlSelections.Size = new System.Drawing.Size(370, 258);
            this.controlSelections.TabIndex = 0;
            this.controlSelections.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnFinish);
            this.panel4.Controls.Add(this.btnNext);
            this.panel4.Controls.Add(this.btnPrevious);
            this.panel4.Location = new System.Drawing.Point(180, 441);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(515, 50);
            this.panel4.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(427, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(343, 14);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "&Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(262, 14);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(181, 14);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "< &Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // FormProjectFileCreateWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(694, 491);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelControlsX);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProjectFileCreateWizard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TFS Manager / MSBuild Project File Creation Wizard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelControlsX.ResumeLayout(false);
            this.panelControls.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelControlsX;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.LinkLabel linkSelections;
        private System.Windows.Forms.LinkLabel linkOptions;
        private System.Windows.Forms.LinkLabel linkConfigurations;
        private TFSManager.Controls.ControlMSBuildProjSelections controlSelections;
        private System.Windows.Forms.Panel panelControls;
        private ControlMSBuildProjConfigurations controlConfigurations;
    }
}