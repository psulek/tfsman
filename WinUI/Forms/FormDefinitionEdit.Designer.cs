using System;
using System.Windows.Forms;

namespace TFSManager.Forms
{
    partial class FormDefinitionEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDefinitionEdit));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.controlOwner = new System.Windows.Forms.Panel();
            this.controlProjectFile = new TFSManager.Controls.ControlDefinitionProjectFile();
            this.controlWorkspace = new TFSManager.Controls.ControlDefinitionWorkspace();
            this.controlGeneral = new TFSManager.Controls.ControlDefinitionGeneral();
            this.pageList = new System.Windows.Forms.ToolStrip();
            this.btnGeneral = new System.Windows.Forms.ToolStripButton();
            this.btnWorkspace = new System.Windows.Forms.ToolStripButton();
            this.btnProjectFile = new System.Windows.Forms.ToolStripButton();
            this.btnRetention = new System.Windows.Forms.ToolStripButton();
            this.btnBuildDefaults = new System.Windows.Forms.ToolStripButton();
            this.btnTrigger = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lbWarningMsg = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.controlOwner.SuspendLayout();
            this.pageList.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(445, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(526, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // controlOwner
            // 
            this.controlOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.controlOwner.Controls.Add(this.controlProjectFile);
            this.controlOwner.Controls.Add(this.controlWorkspace);
            this.controlOwner.Controls.Add(this.controlGeneral);
            this.controlOwner.Location = new System.Drawing.Point(145, 12);
            this.controlOwner.Name = "controlOwner";
            this.controlOwner.Size = new System.Drawing.Size(455, 333);
            this.controlOwner.TabIndex = 1;
            // 
            // controlProjectFile
            // 
            this.controlProjectFile.Location = new System.Drawing.Point(38, 58);
            this.controlProjectFile.Name = "controlProjectFile";
            this.controlProjectFile.Size = new System.Drawing.Size(355, 167);
            this.controlProjectFile.TabIndex = 2;
            // 
            // controlWorkspace
            // 
            this.controlWorkspace.Location = new System.Drawing.Point(16, 23);
            this.controlWorkspace.Name = "controlWorkspace";
            this.controlWorkspace.Size = new System.Drawing.Size(399, 184);
            this.controlWorkspace.TabIndex = 1;
            // 
            // controlGeneral
            // 
            this.controlGeneral.Location = new System.Drawing.Point(3, 3);
            this.controlGeneral.Name = "controlGeneral";
            this.controlGeneral.Size = new System.Drawing.Size(437, 150);
            this.controlGeneral.TabIndex = 0;
            // 
            // pageList
            // 
            this.pageList.AutoSize = false;
            this.pageList.CanOverflow = false;
            this.pageList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pageList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.pageList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGeneral,
            this.btnWorkspace,
            this.btnProjectFile,
            this.btnRetention,
            this.btnBuildDefaults,
            this.btnTrigger});
            this.pageList.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.pageList.Location = new System.Drawing.Point(0, 0);
            this.pageList.Name = "pageList";
            this.pageList.Size = new System.Drawing.Size(130, 351);
            this.pageList.Stretch = true;
            this.pageList.TabIndex = 4;
            this.pageList.Text = "toolStrip1";
            this.pageList.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // btnGeneral
            // 
            this.btnGeneral.AutoSize = false;
            this.btnGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnGeneral.Size = new System.Drawing.Size(122, 25);
            this.btnGeneral.Tag = "0";
            this.btnGeneral.Text = "General";
            this.btnGeneral.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnGeneral.Click += new System.EventHandler(this.PageList_Click);
            // 
            // btnWorkspace
            // 
            this.btnWorkspace.AutoSize = false;
            this.btnWorkspace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWorkspace.Name = "btnWorkspace";
            this.btnWorkspace.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnWorkspace.Size = new System.Drawing.Size(122, 25);
            this.btnWorkspace.Tag = "1";
            this.btnWorkspace.Text = "Workspace";
            this.btnWorkspace.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnWorkspace.Click += new System.EventHandler(this.PageList_Click);
            // 
            // btnProjectFile
            // 
            this.btnProjectFile.AutoSize = false;
            this.btnProjectFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProjectFile.Name = "btnProjectFile";
            this.btnProjectFile.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnProjectFile.Size = new System.Drawing.Size(122, 25);
            this.btnProjectFile.Tag = "2";
            this.btnProjectFile.Text = "Project File";
            this.btnProjectFile.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnProjectFile.Click += new System.EventHandler(this.PageList_Click);
            // 
            // btnRetention
            // 
            this.btnRetention.AutoSize = false;
            this.btnRetention.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRetention.Name = "btnRetention";
            this.btnRetention.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnRetention.Size = new System.Drawing.Size(122, 25);
            this.btnRetention.Tag = "3";
            this.btnRetention.Text = "Retention Policy";
            this.btnRetention.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnRetention.Click += new System.EventHandler(this.PageList_Click);
            // 
            // btnBuildDefaults
            // 
            this.btnBuildDefaults.AutoSize = false;
            this.btnBuildDefaults.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuildDefaults.Name = "btnBuildDefaults";
            this.btnBuildDefaults.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnBuildDefaults.Size = new System.Drawing.Size(122, 25);
            this.btnBuildDefaults.Tag = "4";
            this.btnBuildDefaults.Text = "Build Defaults";
            this.btnBuildDefaults.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnBuildDefaults.Click += new System.EventHandler(this.PageList_Click);
            // 
            // btnTrigger
            // 
            this.btnTrigger.AutoSize = false;
            this.btnTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnTrigger.Size = new System.Drawing.Size(122, 25);
            this.btnTrigger.Tag = "5";
            this.btnTrigger.Text = "Trigger";
            this.btnTrigger.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnTrigger.Click += new System.EventHandler(this.PageList_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lbWarningMsg);
            this.panelBottom.Controls.Add(this.btnOK);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 351);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(612, 35);
            this.panelBottom.TabIndex = 5;
            // 
            // lbWarningMsg
            // 
            this.lbWarningMsg.Image = global::TFSManager.Properties.Resources.Warning;
            this.lbWarningMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbWarningMsg.Location = new System.Drawing.Point(1, 13);
            this.lbWarningMsg.Name = "lbWarningMsg";
            this.lbWarningMsg.Size = new System.Drawing.Size(259, 13);
            this.lbWarningMsg.TabIndex = 4;
            this.lbWarningMsg.Text = "This icon indicates that the tab requires input.";
            this.lbWarningMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbWarningMsg.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList1.Images.SetKeyName(0, "info.png");
            // 
            // FormDefinitionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 386);
            this.Controls.Add(this.pageList);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.controlOwner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDefinitionEdit";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TFS Manager / Build definition detail";
            this.controlOwner.ResumeLayout(false);
            this.pageList.ResumeLayout(false);
            this.pageList.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnOK;
        private Button btnCancel;
        private Panel controlOwner;
        private TFSManager.Controls.ControlDefinitionGeneral controlGeneral;
        private TFSManager.Controls.ControlDefinitionWorkspace controlWorkspace;
        private ToolStrip pageList;
        private ToolStripButton btnGeneral;
        private ToolStripButton btnWorkspace;
        private ToolStripButton btnProjectFile;
        private ToolStripButton btnRetention;
        private ToolStripButton btnBuildDefaults;
        private ToolStripButton btnTrigger;
        private Panel panelBottom;
        private Label lbWarningMsg;
        private ImageList imageList1;
        private TFSManager.Controls.ControlDefinitionProjectFile controlProjectFile;
    }
}