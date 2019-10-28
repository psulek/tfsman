namespace TFSManager.Controls
{
    partial class ControlDefinitionGeneral
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
            this.lbName = new System.Windows.Forms.Label();
            this.edName = new System.Windows.Forms.TextBox();
            this.edDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chDisable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(3, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(107, 13);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Build definition &name:";
            // 
            // edName
            // 
            this.edName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edName.Location = new System.Drawing.Point(6, 19);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(373, 20);
            this.edName.TabIndex = 1;
            this.edName.Leave += new System.EventHandler(this.edName_Leave);
            // 
            // edDescription
            // 
            this.edDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edDescription.Location = new System.Drawing.Point(6, 66);
            this.edDescription.Multiline = true;
            this.edDescription.Name = "edDescription";
            this.edDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edDescription.Size = new System.Drawing.Size(373, 229);
            this.edDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Description (optional):";
            // 
            // chDisable
            // 
            this.chDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chDisable.AutoSize = true;
            this.chDisable.Location = new System.Drawing.Point(6, 301);
            this.chDisable.Name = "chDisable";
            this.chDisable.Size = new System.Drawing.Size(298, 17);
            this.chDisable.TabIndex = 4;
            this.chDisable.Text = "Di&sable this build definition (no new builds will be queued).";
            this.chDisable.UseVisualStyleBackColor = true;
            // 
            // ControlDefinitionGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chDisable);
            this.Controls.Add(this.edDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edName);
            this.Controls.Add(this.lbName);
            this.Name = "ControlDefinitionGeneral";
            this.Size = new System.Drawing.Size(392, 326);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.TextBox edDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chDisable;
    }
}
