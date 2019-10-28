namespace TFSManager.Forms
{
    partial class FormBrowseTFSFolder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBrowseTFSFolder));
            this.label1 = new System.Windows.Forms.Label();
            this.edServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.edFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.QueryPathTimer = new System.Windows.Forms.Timer(this.components);
            this.chQueryMode = new System.Windows.Forms.CheckBox();
            this.btnStopQuerying = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Team Foundation Server:";
            // 
            // edServer
            // 
            this.edServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edServer.Location = new System.Drawing.Point(12, 25);
            this.edServer.Name = "edServer";
            this.edServer.ReadOnly = true;
            this.edServer.Size = new System.Drawing.Size(426, 20);
            this.edServer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Folders:";
            // 
            // treeFolders
            // 
            this.treeFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFolders.HideSelection = false;
            this.treeFolders.ImageIndex = 0;
            this.treeFolders.ImageList = this.imageList1;
            this.treeFolders.Location = new System.Drawing.Point(12, 73);
            this.treeFolders.Name = "treeFolders";
            this.treeFolders.SelectedImageIndex = 0;
            this.treeFolders.Size = new System.Drawing.Size(426, 330);
            this.treeFolders.TabIndex = 3;
            this.treeFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterSelect);
            this.treeFolders.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterExpand);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "TEIcons_1.bmp");
            this.imageList1.Images.SetKeyName(1, "TEIcons_3.bmp");
            this.imageList1.Images.SetKeyName(2, "Resources.Folders_1.bmp");
            this.imageList1.Images.SetKeyName(3, "Resources.Folders_2.bmp");
            // 
            // edFolderPath
            // 
            this.edFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edFolderPath.Location = new System.Drawing.Point(12, 428);
            this.edFolderPath.Name = "edFolderPath";
            this.edFolderPath.ReadOnly = true;
            this.edFolderPath.Size = new System.Drawing.Size(426, 20);
            this.edFolderPath.TabIndex = 5;
            this.edFolderPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edFolderPath_KeyDown);
            this.edFolderPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edFolderPath_KeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Folder &path:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(282, 454);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(363, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // QueryPathTimer
            // 
            this.QueryPathTimer.Interval = 300;
            this.QueryPathTimer.Tick += new System.EventHandler(this.QueryPathTimer_Tick);
            // 
            // chQueryMode
            // 
            this.chQueryMode.AutoSize = true;
            this.chQueryMode.Location = new System.Drawing.Point(78, 408);
            this.chQueryMode.Name = "chQueryMode";
            this.chQueryMode.Size = new System.Drawing.Size(83, 17);
            this.chQueryMode.TabIndex = 9;
            this.chQueryMode.Text = "Query mode";
            this.chQueryMode.UseVisualStyleBackColor = true;
            this.chQueryMode.CheckedChanged += new System.EventHandler(this.chQueryMode_CheckedChanged);
            // 
            // btnStopQuerying
            // 
            this.btnStopQuerying.AutoSize = true;
            this.btnStopQuerying.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStopQuerying.Location = new System.Drawing.Point(328, 405);
            this.btnStopQuerying.Name = "btnStopQuerying";
            this.btnStopQuerying.Size = new System.Drawing.Size(110, 22);
            this.btnStopQuerying.TabIndex = 10;
            this.btnStopQuerying.Text = "Stop querying";
            this.btnStopQuerying.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStopQuerying.UseVisualStyleBackColor = true;
            this.btnStopQuerying.Visible = false;
            this.btnStopQuerying.Click += new System.EventHandler(this.btnStopQuerying_Click);
            // 
            // FormBrowseTFSFolder
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 494);
            this.Controls.Add(this.btnStopQuerying);
            this.Controls.Add(this.chQueryMode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.edFolderPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeFolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edServer);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowseTFSFolder";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TFS Manager / Browse for Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeFolders;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox edFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer QueryPathTimer;
        private System.Windows.Forms.CheckBox chQueryMode;
        private System.Windows.Forms.Button btnStopQuerying;
    }
}