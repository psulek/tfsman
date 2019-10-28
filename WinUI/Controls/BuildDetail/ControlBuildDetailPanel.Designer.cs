namespace TFSManager.Controls
{
    partial class ControlBuildDetailPanel
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBuildDetailPanel));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.collapsibleControl1 = new TFSManager.Controls.CollapsibleControl();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "BuildStatusIcons_4.bmp");
            this.imageList.Images.SetKeyName(1, "BuildStatusIcons_3.bmp");
            // 
            // collapsibleControl1
            // 
            this.collapsibleControl1.BackColor = System.Drawing.SystemColors.Window;
            this.collapsibleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleControl1.Location = new System.Drawing.Point(0, 0);
            this.collapsibleControl1.Name = "collapsibleControl1";
            this.collapsibleControl1.Size = new System.Drawing.Size(242, 512);
            this.collapsibleControl1.TabIndex = 0;
            // 
            // ControlBuildDetailPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.collapsibleControl1);
            this.Name = "ControlBuildDetailPanel";
            this.Size = new System.Drawing.Size(242, 512);
            this.ResumeLayout(false);

        }

        #endregion

        private CollapsibleControl collapsibleControl1;
        private System.Windows.Forms.ImageList imageList;
    }
}