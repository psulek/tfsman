using TFSManager.Core.WinForms.Controls;

namespace TFSManager.Components
{
    partial class LoadingPanelEx
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbMessage = new System.Windows.Forms.Label();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            this.linkAction = new XPLinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.linkAction);
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.imgLoading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 34);
            this.panel1.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(34, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(362, 11);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessage.BackColor = System.Drawing.SystemColors.Info;
            this.lbMessage.Location = new System.Drawing.Point(31, 5);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(289, 27);
            this.lbMessage.TabIndex = 2;
            this.lbMessage.Text = "asdsad\r\nasdsad";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgLoading
            // 
            this.imgLoading.Image = global::TFSManager.Properties.Resources.loading_circle_03;
            this.imgLoading.Location = new System.Drawing.Point(3, 5);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(24, 24);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLoading.TabIndex = 1;
            this.imgLoading.TabStop = false;
            // 
            // linkAction
            // 
            this.linkAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkAction.ColorHover = System.Drawing.SystemColors.InfoText;
            this.linkAction.ColorNormal = System.Drawing.SystemColors.MenuHighlight;
            this.linkAction.FontHover = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkAction.FontNormal = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkAction.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.linkAction.Image = global::TFSManager.Properties.Resources.Cancel;
            this.linkAction.Location = new System.Drawing.Point(326, 9);
            this.linkAction.Name = "linkAction";
            this.linkAction.Size = new System.Drawing.Size(70, 16);
            this.linkAction.TabIndex = 3;
            this.linkAction.Tag = "0";
            this.linkAction.Text = "[Cancel]";
            this.linkAction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkAction.Click += new System.EventHandler(this.linkAction_Click);
            // 
            // LoadingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Name = "LoadingPanel";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(409, 36);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgLoading;
        private System.Windows.Forms.Label lbMessage;
        private XPLinkLabel linkAction;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
