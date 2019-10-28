namespace TFSManager.Controls
{
    partial class ControlBuildDetailBuildSteps
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
            XPTable.Models.DataSourceColumnBinder dataSourceColumnBinder1 = new XPTable.Models.DataSourceColumnBinder();
            this.lvItems = new XPTable.Models.Table();
            this.columnModel1 = new XPTable.Models.ColumnModel();
            this.columnIcon = new XPTable.Models.TextColumn();
            this.columnBuildStep = new XPTable.Models.TextColumn();
            this.columnCompletedOn = new XPTable.Models.TextColumn();
            this.table = new XPTable.Models.TableModel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lvItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.BorderColor = System.Drawing.Color.Black;
            this.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvItems.ColumnModel = this.columnModel1;
            this.lvItems.DataMember = null;
            this.lvItems.DataSourceColumnBinder = dataSourceColumnBinder1;
            this.lvItems.EnableHeaderContextMenu = false;
            this.lvItems.GridLines = XPTable.Models.GridLines.Rows;
            this.lvItems.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvItems.Location = new System.Drawing.Point(0, 0);
            this.lvItems.Name = "lvItems";
            this.lvItems.NoItemsText = "";
            this.lvItems.Scrollable = false;
            this.lvItems.SelectionStyle = XPTable.Models.SelectionStyle.Grid;
            this.lvItems.Size = new System.Drawing.Size(565, 280);
            this.lvItems.TabIndex = 4;
            this.lvItems.TableModel = this.table;
            this.lvItems.Text = "table1";
            this.lvItems.UnfocusedBorderColor = System.Drawing.Color.Black;
            this.lvItems.Resize += new System.EventHandler(this.lvItems_Resize);
            // 
            // columnModel1
            // 
            this.columnModel1.Columns.AddRange(new XPTable.Models.Column[] {
            this.columnIcon,
            this.columnBuildStep,
            this.columnCompletedOn});
            // 
            // columnIcon
            // 
            this.columnIcon.ContentWidth = 0;
            this.columnIcon.Editable = false;
            this.columnIcon.Resizable = false;
            this.columnIcon.Selectable = false;
            this.columnIcon.Sortable = false;
            this.columnIcon.Text = "";
            this.columnIcon.Width = 20;
            // 
            // columnBuildStep
            // 
            this.columnBuildStep.ContentWidth = 0;
            this.columnBuildStep.Editable = false;
            this.columnBuildStep.Resizable = false;
            this.columnBuildStep.Selectable = false;
            this.columnBuildStep.Sortable = false;
            this.columnBuildStep.Text = "Build step";
            this.columnBuildStep.ToolTipText = "";
            this.columnBuildStep.Width = 400;
            // 
            // columnCompletedOn
            // 
            this.columnCompletedOn.ContentWidth = 0;
            this.columnCompletedOn.Editable = false;
            this.columnCompletedOn.Resizable = false;
            this.columnCompletedOn.Selectable = false;
            this.columnCompletedOn.Sortable = false;
            this.columnCompletedOn.Text = "Completed On";
            this.columnCompletedOn.Width = 120;
            // 
            // table
            // 
            this.table.RowHeight = 25;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.lvItems);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.panel1.Location = new System.Drawing.Point(15, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 283);
            this.panel1.TabIndex = 5;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // ControlBuildDetailBuildSteps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(481, 212);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel1);
            this.Name = "ControlBuildDetailBuildSteps";
            this.Size = new System.Drawing.Size(469, 132);
            this.Load += new System.EventHandler(this.ControlBuildDetailBuildSteps_Load);
            this.Resize += new System.EventHandler(this.ControlBuildDetailBuildSteps_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.lvItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XPTable.Models.Table lvItems;
        private XPTable.Models.ColumnModel columnModel1;
        private XPTable.Models.TableModel table;
        private XPTable.Models.TextColumn columnIcon;
        private XPTable.Models.TextColumn columnBuildStep;
        private XPTable.Models.TextColumn columnCompletedOn;
        private System.Windows.Forms.Panel panel1;
    }
}
