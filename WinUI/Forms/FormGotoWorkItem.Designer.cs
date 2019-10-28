namespace TFSManager.Forms
{
    partial class FormGotoWorkItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGotoWorkItem));
            this.label1 = new System.Windows.Forms.Label();
            this.edID = new System.Windows.Forms.NumericUpDown();
            this.rbFoundInList = new System.Windows.Forms.RadioButton();
            this.rbMakeNewQuery = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.edID)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // edID
            // 
            this.edID.Location = new System.Drawing.Point(15, 33);
            this.edID.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.edID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edID.Name = "edID";
            this.edID.Size = new System.Drawing.Size(143, 20);
            this.edID.TabIndex = 1;
            this.edID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbFoundInList
            // 
            this.rbFoundInList.AutoSize = true;
            this.rbFoundInList.Checked = true;
            this.rbFoundInList.Location = new System.Drawing.Point(15, 68);
            this.rbFoundInList.Name = "rbFoundInList";
            this.rbFoundInList.Size = new System.Drawing.Size(117, 17);
            this.rbFoundInList.TabIndex = 2;
            this.rbFoundInList.TabStop = true;
            this.rbFoundInList.Text = "Found in current list";
            this.rbFoundInList.UseVisualStyleBackColor = true;
            // 
            // rbMakeNewQuery
            // 
            this.rbMakeNewQuery.AutoSize = true;
            this.rbMakeNewQuery.Location = new System.Drawing.Point(15, 91);
            this.rbMakeNewQuery.Name = "rbMakeNewQuery";
            this.rbMakeNewQuery.Size = new System.Drawing.Size(104, 17);
            this.rbMakeNewQuery.TabIndex = 3;
            this.rbMakeNewQuery.Text = "Make new query";
            this.rbMakeNewQuery.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(125, 130);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(206, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormGotoWorkItem
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(293, 165);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rbMakeNewQuery);
            this.Controls.Add(this.rbFoundInList);
            this.Controls.Add(this.edID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGotoWorkItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TFS Manager / Go To Work Item";
            ((System.ComponentModel.ISupportInitialize)(this.edID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown edID;
        private System.Windows.Forms.RadioButton rbFoundInList;
        private System.Windows.Forms.RadioButton rbMakeNewQuery;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}