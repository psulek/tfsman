using TFSManager.Properties;

namespace TFSManager.Controls
{
    partial class ControlMSBuildProjSelections
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSolutions = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chSelectAll = new System.Windows.Forms.CheckBox();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solutions are listed based on the specified workspace. Selected solutions will be" +
                " built sequentially in the order specified below.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select and order solutions to build:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbSolutions);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 269);
            this.panel1.TabIndex = 2;
            // 
            // lbSolutions
            // 
            this.lbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSolutions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSolutions.FormattingEnabled = true;
            this.lbSolutions.Location = new System.Drawing.Point(0, 28);
            this.lbSolutions.Name = "lbSolutions";
            this.lbSolutions.Size = new System.Drawing.Size(433, 240);
            this.lbSolutions.TabIndex = 6;
            this.lbSolutions.SelectedIndexChanged += new System.EventHandler(this.lbSolutions_SelectedIndexChanged);
            this.lbSolutions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbSolutions_ItemCheck);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chSelectAll);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 26);
            this.panel2.TabIndex = 0;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // chSelectAll
            // 
            this.chSelectAll.AutoSize = true;
            this.chSelectAll.Location = new System.Drawing.Point(3, 5);
            this.chSelectAll.Name = "chSelectAll";
            this.chSelectAll.Size = new System.Drawing.Size(76, 17);
            this.chSelectAll.TabIndex = 0;
            this.chSelectAll.Text = "(Select &All)";
            this.chSelectAll.UseVisualStyleBackColor = true;
            this.chSelectAll.CheckedChanged += new System.EventHandler(this.chSelectAll_CheckedChanged);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = Resources.arrow_up_blue;
            this.btnMoveUp.Location = new System.Drawing.Point(444, 65);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(28, 25);
            this.btnMoveUp.TabIndex = 3;
            this.btnMoveUp.Tag = "0";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.MoveItem_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = Resources.arrow_down_blue;
            this.btnMoveDown.Location = new System.Drawing.Point(444, 96);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(28, 25);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.Tag = "1";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.MoveItem_Click);
            // 
            // ControlMSBuildProjSelections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ControlMSBuildProjSelections";
            this.Size = new System.Drawing.Size(477, 340);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chSelectAll;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.CheckedListBox lbSolutions;
    }
}
