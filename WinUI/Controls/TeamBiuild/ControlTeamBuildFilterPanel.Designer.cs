namespace TFSManager.Controls.TeamBiuild
{
    partial class ControlTeamBuildFilterPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lineControl1 = new TFSManager.Core.WinForms.Controls.LineControl();
            this.linkToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chAutoApply = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.linkAutoRefresh = new TFSManager.Core.WinForms.Controls.XPLinkLabel();
            this.linkSelectAll = new TFSManager.Core.WinForms.Controls.XPLinkLabel();
            this.linkSelectNone = new TFSManager.Core.WinForms.Controls.XPLinkLabel();
            this.lineControl2 = new TFSManager.Core.WinForms.Controls.LineControl();
            this.lineControl3 = new TFSManager.Core.WinForms.Controls.LineControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Team project filter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutPanel
            // 
            this.layoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutPanel.AutoScroll = true;
            this.layoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layoutPanel.Location = new System.Drawing.Point(6, 41);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(295, 274);
            this.layoutPanel.TabIndex = 0;
            // 
            // lineControl1
            // 
            this.lineControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineControl1.Location = new System.Drawing.Point(0, 0);
            this.lineControl1.Name = "lineControl1";
            this.lineControl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.lineControl1.Size = new System.Drawing.Size(308, 345);
            this.lineControl1.TabIndex = 0;
            this.lineControl1.Text = "lineControl1";
            // 
            // linkToolTip
            // 
            this.linkToolTip.ShowAlways = true;
            this.linkToolTip.UseAnimation = false;
            this.linkToolTip.UseFading = false;
            // 
            // chAutoApply
            // 
            this.chAutoApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chAutoApply.AutoSize = true;
            this.chAutoApply.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.chAutoApply.Checked = true;
            this.chAutoApply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAutoApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chAutoApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(238)));
            this.chAutoApply.ForeColor = System.Drawing.SystemColors.GrayText;
            this.chAutoApply.Location = new System.Drawing.Point(97, 325);
            this.chAutoApply.Name = "chAutoApply";
            this.chAutoApply.Size = new System.Drawing.Size(13, 12);
            this.chAutoApply.TabIndex = 4;
            this.chAutoApply.UseVisualStyleBackColor = true;
            this.chAutoApply.CheckedChanged += new System.EventHandler(this.chAutoApply_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(6, 318);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(88, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = global::TFSManager.Properties.Resources.apply;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton1.Text = "Apply filter";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // linkAutoRefresh
            // 
            this.linkAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkAutoRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.linkAutoRefresh.ColorHover = System.Drawing.SystemColors.HotTrack;
            this.linkAutoRefresh.ColorNormal = System.Drawing.SystemColors.ControlDark;
            this.linkAutoRefresh.FontHover = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkAutoRefresh.FontNormal = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkAutoRefresh.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.linkAutoRefresh.Location = new System.Drawing.Point(110, 323);
            this.linkAutoRefresh.Name = "linkAutoRefresh";
            this.linkAutoRefresh.Size = new System.Drawing.Size(191, 15);
            this.linkAutoRefresh.TabIndex = 1;
            this.linkAutoRefresh.Text = "Auto apply filter";
            this.linkAutoRefresh.TransparentBackground = false;
            this.linkAutoRefresh.Click += new System.EventHandler(this.linkAutoApply_Click);
            // 
            // linkSelectAll
            // 
            this.linkSelectAll.AutoSize = true;
            this.linkSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.linkSelectAll.ColorHover = System.Drawing.SystemColors.HotTrack;
            this.linkSelectAll.ColorNormal = System.Drawing.SystemColors.ControlDark;
            this.linkSelectAll.FontHover = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkSelectAll.FontNormal = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkSelectAll.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.linkSelectAll.Location = new System.Drawing.Point(6, 22);
            this.linkSelectAll.Name = "linkAutoRefresh";
            this.linkSelectAll.Size = new System.Drawing.Size(51, 13);
            this.linkSelectAll.TabIndex = 2;
            this.linkSelectAll.Tag = "0";
            this.linkSelectAll.Text = "Select All";
            this.linkSelectAll.TransparentBackground = false;
            this.linkSelectAll.Click += new System.EventHandler(this.linkSelectItems);
            // 
            // linkSelectNone
            // 
            this.linkSelectNone.AutoSize = true;
            this.linkSelectNone.BackColor = System.Drawing.SystemColors.Control;
            this.linkSelectNone.ColorHover = System.Drawing.SystemColors.HotTrack;
            this.linkSelectNone.ColorNormal = System.Drawing.SystemColors.ControlDark;
            this.linkSelectNone.FontHover = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkSelectNone.FontNormal = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkSelectNone.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.linkSelectNone.Location = new System.Drawing.Point(71, 22);
            this.linkSelectNone.Name = "linkAutoRefresh";
            this.linkSelectNone.Size = new System.Drawing.Size(66, 13);
            this.linkSelectNone.TabIndex = 3;
            this.linkSelectNone.Tag = "1";
            this.linkSelectNone.Text = "Select None";
            this.linkSelectNone.TransparentBackground = false;
            this.linkSelectNone.Click += new System.EventHandler(this.linkSelectItems);
            // 
            // lineControl2
            // 
            this.lineControl2.Location = new System.Drawing.Point(64, 24);
            this.lineControl2.Name = "lineControl2";
            this.lineControl2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.lineControl2.Size = new System.Drawing.Size(3, 12);
            this.lineControl2.TabIndex = 8;
            this.lineControl2.Text = "lineControl2";
            // 
            // lineControl3
            // 
            this.lineControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineControl3.Location = new System.Drawing.Point(6, 37);
            this.lineControl3.Name = "lineControl3";
            this.lineControl3.Size = new System.Drawing.Size(295, 2);
            this.lineControl3.TabIndex = 9;
            this.lineControl3.Text = "lineControl3";
            // 
            // ControlTeamBuildFilterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineControl3);
            this.Controls.Add(this.lineControl2);
            this.Controls.Add(this.linkSelectNone);
            this.Controls.Add(this.linkSelectAll);
            this.Controls.Add(this.linkAutoRefresh);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chAutoApply);
            this.Controls.Add(this.layoutPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lineControl1);
            this.Name = "ControlTeamBuildFilterPanel";
            this.Size = new System.Drawing.Size(308, 345);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TFSManager.Core.WinForms.Controls.LineControl lineControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel layoutPanel;
        private System.Windows.Forms.ToolTip linkToolTip;
        private System.Windows.Forms.CheckBox chAutoApply;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private TFSManager.Core.WinForms.Controls.XPLinkLabel linkAutoRefresh;
        private TFSManager.Core.WinForms.Controls.XPLinkLabel linkSelectAll;
        private TFSManager.Core.WinForms.Controls.XPLinkLabel linkSelectNone;
        private TFSManager.Core.WinForms.Controls.LineControl lineControl2;
        private TFSManager.Core.WinForms.Controls.LineControl lineControl3;

    }
}
