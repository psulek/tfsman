namespace TFSManager.Controls
{
    partial class ControlMSBuildProjConfigurations
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
            this.label2 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.colConfiguration = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPlatform = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRemove = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menuGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solutions will be built in the listed configurations.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Which configurations would you like to build?";
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConfiguration,
            this.colPlatform});
            this.grid.ContextMenuStrip = this.menuGrid;
            this.grid.Location = new System.Drawing.Point(0, 37);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(414, 282);
            this.grid.TabIndex = 2;
            this.grid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_UserDeletingRow);
            // 
            // colConfiguration
            // 
            this.colConfiguration.HeaderText = "Configuration";
            this.colConfiguration.Items.AddRange(new object[] {
            "Debug",
            "Release"});
            this.colConfiguration.MinimumWidth = 200;
            this.colConfiguration.Name = "colConfiguration";
            // 
            // colPlatform
            // 
            this.colPlatform.HeaderText = "Platform";
            this.colPlatform.Items.AddRange(new object[] {
            "x86",
            "x64",
            "Itanium",
            "Win32",
            "Any CPU",
            ".NET",
            "Mixed Platforms"});
            this.colPlatform.MinimumWidth = 150;
            this.colPlatform.Name = "colPlatform";
            // 
            // menuGrid
            // 
            this.menuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniRemove});
            this.menuGrid.Name = "menuGrid";
            this.menuGrid.Size = new System.Drawing.Size(125, 48);
            this.menuGrid.Opening += new System.ComponentModel.CancelEventHandler(this.menuGrid_Opening);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(124, 22);
            this.mniAdd.Text = "&Add";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniRemove
            // 
            this.mniRemove.Name = "mniRemove";
            this.mniRemove.Size = new System.Drawing.Size(124, 22);
            this.mniRemove.Text = "&Remove";
            this.mniRemove.Click += new System.EventHandler(this.mniRemove_Click);
            // 
            // ControlMSBuildProjConfigurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ControlMSBuildProjConfigurations";
            this.Size = new System.Drawing.Size(416, 321);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.menuGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewComboBoxColumn colConfiguration;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPlatform;
        private System.Windows.Forms.ContextMenuStrip menuGrid;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniRemove;
    }
}
