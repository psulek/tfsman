namespace TFSManager.Controls
{
    partial class ControlBuildDetailSummary
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
            this.textColumn1 = new XPTable.Models.TextColumn();
            this.textColumn2 = new XPTable.Models.TextColumn();
            this.table = new XPTable.Models.TableModel();
            ((System.ComponentModel.ISupportInitialize)(this.lvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.BorderColor = System.Drawing.Color.Black;
            this.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvItems.ColumnModel = this.columnModel1;
            this.lvItems.DataMember = null;
            this.lvItems.DataSourceColumnBinder = dataSourceColumnBinder1;
            this.lvItems.EnableHeaderContextMenu = false;
            this.lvItems.GridLines = XPTable.Models.GridLines.Rows;
            this.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvItems.Location = new System.Drawing.Point(15, 3);
            this.lvItems.Name = "lvItems";
            this.lvItems.NoItemsText = "";
            this.lvItems.Scrollable = false;
            this.lvItems.SelectionStyle = XPTable.Models.SelectionStyle.Grid;
            this.lvItems.Size = new System.Drawing.Size(466, 209);
            this.lvItems.TabIndex = 3;
            this.lvItems.TableModel = this.table;
            this.lvItems.Text = "table1";
            this.lvItems.UnfocusedBorderColor = System.Drawing.Color.Black;
            // 
            // columnModel1
            // 
            this.columnModel1.Columns.AddRange(new XPTable.Models.Column[] {
            this.textColumn1,
            this.textColumn2});
            // 
            // textColumn1
            // 
            this.textColumn1.ContentWidth = 0;
            this.textColumn1.Editable = false;
            this.textColumn1.Resizable = false;
            this.textColumn1.Selectable = false;
            this.textColumn1.Sortable = false;
            this.textColumn1.Width = 150;
            // 
            // textColumn2
            // 
            this.textColumn2.ContentWidth = 0;
            this.textColumn2.Editable = false;
            this.textColumn2.Selectable = false;
            this.textColumn2.Sortable = false;
            this.textColumn2.Width = 700;
            // 
            // ControlBuildDetailSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lvItems);
            this.Name = "ControlBuildDetailSummary";
            this.Size = new System.Drawing.Size(481, 212);
            ((System.ComponentModel.ISupportInitialize)(this.lvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XPTable.Models.Table lvItems;
        private XPTable.Models.ColumnModel columnModel1;
        private XPTable.Models.TextColumn textColumn1;
        private XPTable.Models.TextColumn textColumn2;
        private XPTable.Models.TableModel table;

    }
}
