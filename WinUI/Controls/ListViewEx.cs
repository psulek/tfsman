using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TFSManager.Controls
{
    /// <summary>
    /// Zusammenfassung für ListViewEx.
    /// </summary>
    public class ListViewEx: ListView
    {
        #region Interop-Defines

        // ListView messages
        private const int LVM_FIRST = 0x1000;
        private const int LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59);

        // Windows Messages

        private const string REORDER = "Reorder";
        private const int WM_PAINT = 0x000F;
        private Rectangle highLightedRect;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wPar, IntPtr lPar);

        private event EmbeddControlEndEditingEvent embeddControlEndEditing;

        private void InvokeEmbeddControlEndEditing(EmbeddControlEndEditingArgs args)
        {
            EmbeddControlEndEditingEvent editing = embeddControlEndEditing;
            if (editing != null)
            {
                editing(args);
            }
        }

        public event EmbeddControlEndEditingEvent EmbeddControlEndEditing
        {
            add
            {
                embeddControlEndEditing += value;
            }
            remove
            {
                embeddControlEndEditing -= value;
            }
        }

        #endregion

        private readonly List<EmbeddedControl> _embeddedControls = new List<EmbeddedControl>();
        private bool allowRowReorder = true;

        public ListViewEx()
        {
            AllowRowReorder = true;
            SingleClickEditMode = false;
        }

        public bool AllowRowReorder
        {
            get
            {
                return this.allowRowReorder;
            }
            set
            {
                this.allowRowReorder = value;
                base.AllowDrop = value;
            }
        }

        public bool SingleClickEditMode { get; set; }

        [DefaultValue(View.LargeIcon)]
        public new View View
        {
            get
            {
                return base.View;
            }
            set
            {
                // Embedded controls are rendered only when we're in Details mode
                foreach (EmbeddedControl ec in this._embeddedControls)
                {
                    if (ec.AlwasyVisible)
                    {
                        ec.Control.Visible = (value == View.Details);
                    }
                }

                base.View = value;
            }
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);
            if (!AllowRowReorder)
            {
                base.OnDragOver(e);
                return;
            }
            if (base.SelectedItems.Count == 0)
            {
                base.OnDragOver(e);
                return;
            }
            Point cp = base.PointToClient(new Point(e.X, e.Y));
            ListViewItem dragToItem = base.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            int dropIndex = dragToItem.Index;
            if (dropIndex > base.SelectedItems[0].Index)
            {
                dropIndex++;
            }

            var embControls =
                new Dictionary<ListViewItem, List<EmbeddedControl>>();

            var insertItems = new List<ListViewItem>(base.SelectedItems.Count);
            foreach (ListViewItem item in base.SelectedItems)
            {
                List<EmbeddedControl> ecList = GetEmbeddedControlsForItem(item);

                var clonedItem = item.Clone() as ListViewItem;
                insertItems.Add(clonedItem);

                UpdateEmbeddedControls(ecList, clonedItem);
                embControls.Add(clonedItem, ecList);
            }

            for (int i = insertItems.Count - 1; i >= 0; i--)
            {
                ListViewItem insertItem = insertItems[i];
                base.Items.Insert(dropIndex, insertItem);

                List<EmbeddedControl> ecList = embControls[insertItem];
                UpdateEmbeddedControlsRow(ecList, insertItem.Index);
            }

            RemoveEmbeddedControls(SelectedItems);

            foreach (ListViewItem removeItem in base.SelectedItems)
            {
                base.Items.Remove(removeItem);
            }

            AddEmbeddedControls(embControls.Values);
        }

        private void AddEmbeddedControls(ICollection values)
        {
            foreach (List<EmbeddedControl> ecList in values)
            {
                this._embeddedControls.AddRange(ecList);
            }
        }

        private void RemoveEmbeddedControls(SelectedListViewItemCollection selectedItems)
        {
            foreach (ListViewItem item in selectedItems)
            {
                int idx = 0;
                do
                {
                    EmbeddedControl ec = this._embeddedControls[idx];
                    if (ec.Item == item)
                    {
                        this._embeddedControls.RemoveAt(idx);
                    }
                    else
                    {
                        idx++;
                    }
                } while (idx < this._embeddedControls.Count);
            }
        }

        private void UpdateEmbeddedControlsRow(List<EmbeddedControl> ecList, int index)
        {
            for (int i = 0; i < ecList.Count; i++)
            {
                EmbeddedControl ec = ecList[i];
                ec.Row = index;
                ecList[i] = ec;
            }

            //            foreach (EmbeddedControl ec in ecList)
            //            {
            //                ec.Row = index;
            //            }
        }

        private void UpdateEmbeddedControls(List<EmbeddedControl> ecList, ListViewItem item)
        {
            for (int i = 0; i < ecList.Count; i++)
            {
                EmbeddedControl ec = ecList[i];
                ec.Item = item;
                ecList[i] = ec;
            }

            //            foreach (EmbeddedControl ec in ecList)
            //            {
            //                ec.Item = item;
            //            }
        }

        private void ClearDragHighligh()
        {
            if (this.highLightedRect != Rectangle.Empty)
            {
                Invalidate(this.highLightedRect);
            }
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            if (!AllowRowReorder)
            {
                e.Effect = DragDropEffects.None;
                base.OnDragOver(e);
                ClearDragHighligh();
                return;
            }
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                base.OnDragOver(e);
                ClearDragHighligh();
                return;
            }
            Point cp = base.PointToClient(new Point(e.X, e.Y));
            ListViewItem hoverItem = base.GetItemAt(cp.X, cp.Y);
            if (hoverItem == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            foreach (ListViewItem moveItem in base.SelectedItems)
            {
                if (moveItem.Index == hoverItem.Index)
                {
                    e.Effect = DragDropEffects.None;
                    hoverItem.EnsureVisible();
                    return;
                }
            }
            base.OnDragOver(e);
            var text = (String) e.Data.GetData(REORDER.GetType());
            if (text.CompareTo(REORDER) == 0)
            {
                e.Effect = DragDropEffects.Move;
                hoverItem.EnsureVisible();

                if (this.highLightedRect != hoverItem.Bounds)
                {
                    ClearDragHighligh();

                    this.highLightedRect = hoverItem.Bounds;
                    Graphics g = Graphics.FromHwnd(Handle);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(64, Color.FromKnownColor(KnownColor.Highlight))),
                        this.highLightedRect);
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            if (!AllowRowReorder)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            if (!e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            base.OnDragEnter(e);
            var text = (String) e.Data.GetData(REORDER.GetType());
            if (text.CompareTo(REORDER) == 0)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

            this.highLightedRect = Rectangle.Empty;
        }


        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
            ClearDragHighligh();
        }

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            base.OnItemDrag(e);
            if (!AllowRowReorder)
            {
                return;
            }
            base.DoDragDrop(REORDER, DragDropEffects.Move);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (SingleClickEditMode)
            {
                EnterEditMode(e);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (!SingleClickEditMode)
            {
                EnterEditMode(e);
            }
        }

        private void EnterEditMode(MouseEventArgs e)
        {
            ListViewItem viewItem = GetItemAt(e.X, e.Y);
            if (viewItem != null)
            {
                ListViewHitTestInfo hitTest = HitTest(e.Location);
                int columnIndex = viewItem.SubItems.IndexOf(hitTest.SubItem);

                UpdateEmbeddedEditing(columnIndex, viewItem.Index, true);
                Invalidate();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            // when leaving this listview, set all embedd controls editing to false
            EndEditing();
            Invalidate();
        }

        public void EndEditing()
        {
            for (int i = 0; i < this._embeddedControls.Count; i++)
            {
                EmbeddedControl ec = this._embeddedControls[i];
                ec.Editing = false;
                InvokeEmbeddControlEndEditing(new EmbeddControlEndEditingArgs(ec));
            }
        }

        /// <summary>
        /// Retrieve the order in which columns appear
        /// </summary>
        /// <returns>Current display order of column indices</returns>
        protected int[] GetColumnOrder()
        {
            IntPtr lPar = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * Columns.Count);

            IntPtr res = SendMessage(Handle, LVM_GETCOLUMNORDERARRAY, new IntPtr(Columns.Count), lPar);
            if (res.ToInt32() == 0) // Something went wrong
            {
                Marshal.FreeHGlobal(lPar);
                return null;
            }

            var order = new int[Columns.Count];
            Marshal.Copy(lPar, order, 0, Columns.Count);

            Marshal.FreeHGlobal(lPar);

            return order;
        }

        /// <summary>
        /// Retrieve the bounds of a ListViewSubItem
        /// </summary>
        /// <param name="Item">The Item containing the SubItem</param>
        /// <param name="SubItem">Index of the SubItem</param>
        /// <returns>Subitem's bounds</returns>
        protected Rectangle GetSubItemBounds(ListViewItem Item, int SubItem)
        {
            Rectangle subItemRect = Rectangle.Empty;

            if (Item == null)
            {
                throw new ArgumentNullException("Item");
            }

            int[] order = GetColumnOrder();
            if (order == null) // No Columns
            {
                return subItemRect;
            }

            if (SubItem >= order.Length)
            {
                throw new IndexOutOfRangeException("SubItem " + SubItem + " out of range");
            }

            // Retrieve the bounds of the entire ListViewItem (all subitems)
            Rectangle lviBounds = Item.GetBounds(ItemBoundsPortion.Entire);
            int subItemX = lviBounds.Left;

            // Calculate the X position of the SubItem.
            // Because the columns can be reordered we have to use Columns[order[i]] instead of Columns[i] !
            ColumnHeader col;
            int i;
            for (i = 0; i < order.Length; i++)
            {
                col = Columns[order[i]];
                if (col.Index == SubItem)
                {
                    break;
                }
                subItemX += col.Width;
            }

            subItemRect = new Rectangle(subItemX, lviBounds.Top, Columns[order[i]].Width, lviBounds.Height);

            return subItemRect;
        }

        /// <summary>
        /// Add a control to the ListView
        /// </summary>
        /// <param name="c">Control to be added</param>
        /// <param name="col">Index of column</param>
        /// <param name="row">Index of row</param>
        public void AddEmbeddedControl(Control c, int col, int row)
        {
            AddEmbeddedControl(c, col, row, DockStyle.Fill);
        }

        /// <summary>
        /// Add a control to the ListView
        /// </summary>
        /// <param name="c">Control to be added</param>
        /// <param name="col">Index of column</param>
        /// <param name="row">Index of row</param>
        /// <param name="dock">Location and resize behavior of embedded control</param>
        public void AddEmbeddedControl(Control c, int col, int row, DockStyle dock)
        {
            AddEmbeddedControl(c, col, row, dock, true);
        }

        /// <summary>
        /// Add a control to the ListView
        /// </summary>
        /// <param name="c">Control to be added</param>
        /// <param name="col">Index of column</param>
        /// <param name="row">Index of row</param>
        /// <param name="dock">Location and resize behavior of embedded control</param>
        /// <param name="alwasyVisible"></param>
        public void AddEmbeddedControl(Control c, int col, int row, DockStyle dock, bool alwasyVisible)
        {
            if (c == null)
            {
                throw new ArgumentNullException();
            }
            if (col >= Columns.Count || row >= Items.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var ec = new EmbeddedControl()
                     {
                         Control = c, Column = col, Row = row, Dock = dock, Item = Items[row],
                         AlwasyVisible = alwasyVisible, Editing = false
                     };

            this._embeddedControls.Add(ec);

            // Add a Click event handler to select the ListView row when an embedded control is clicked
            c.Click += _embeddedControl_Click;
            c.Leave += _embeddedControl_Leave;

            Controls.Add(c);
        }


        private List<EmbeddedControl> GetEmbeddedControlsForItem(ListViewItem item)
        {
            var result = new List<EmbeddedControl>();

            foreach (EmbeddedControl ec in this._embeddedControls)
            {
                if (ec.Item == item)
                {
                    result.Add(ec);
                }
            }

            return result;
        }

        /// <summary>
        /// Remove a control from the ListView
        /// </summary>
        /// <param name="c">Control to be removed</param>
        public void RemoveEmbeddedControl(Control c)
        {
            if (c == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < this._embeddedControls.Count; i++)
            {
                EmbeddedControl ec = this._embeddedControls[i];
                if (ec.Control == c)
                {
                    c.Click -= new EventHandler(_embeddedControl_Click);
                    Controls.Remove(c);
                    this._embeddedControls.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Control not found!");
        }

        /// <summary>
        /// Retrieve the control embedded at a given location
        /// </summary>
        /// <param name="col">Index of Column</param>
        /// <param name="row">Index of Row</param>
        /// <returns>Control found at given location or null if none assigned.</returns>
        public Control GetEmbeddedControl(int col, int row)
        {
            foreach (EmbeddedControl ec in this._embeddedControls)
            {
                if (ec.Row == row && ec.Column == col)
                {
                    return ec.Control;
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieve the control embedded at a given location
        /// </summary>
        /// <param name="col">Index of Column</param>
        /// <param name="row">Index of Row</param>
        /// <param name="editing"></param>
        public void UpdateEmbeddedEditing(int col, int row, bool editing)
        {
            foreach (EmbeddedControl ec in this._embeddedControls)
            {
                if (ec.Row == row && ec.Column == col)
                {
                    ec.Editing = editing;
                    if (editing)
                    {
                        ec.Control.Select();
                        ec.Control.Focus();
                    }
                    InvokeEmbeddControlEndEditing(new EmbeddControlEndEditingArgs(ec));
                }
            }
        }


        public Control GetEmbeddedControl(ListViewItem item, int column)
        {
            foreach (EmbeddedControl ec in this._embeddedControls)
            {
                if (ec.Item == item && ec.Column == column)
                {
                    return ec.Control;
                }
            }

            return null;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (View != View.Details)
                    {
                        break;
                    }

                    // Calculate the position of all embedded controls
                    foreach (EmbeddedControl ec in this._embeddedControls)
                    {
                        Rectangle rc = GetSubItemBounds(ec.Item, ec.Column);

                        if ((HeaderStyle != ColumnHeaderStyle.None) &&
                            (rc.Top < Font.Height)) // Control overlaps ColumnHeader
                        {
                            ec.Control.Visible = false;
                            continue;
                        }
                        else
                        {
                            ec.Control.Visible = true;
                        }

                        if (!ec.AlwasyVisible)
                        {
                            ec.Control.Visible = ec.Editing;
                        }

                        switch (ec.Dock)
                        {
                            case DockStyle.Fill:
                                break;
                            case DockStyle.Top:
                                rc.Height = ec.Control.Height;
                                break;
                            case DockStyle.Left:
                                rc.Width = ec.Control.Width;
                                break;
                            case DockStyle.Bottom:
                                rc.Offset(0, rc.Height - ec.Control.Height);
                                rc.Height = ec.Control.Height;
                                break;
                            case DockStyle.Right:
                                rc.Offset(rc.Width - ec.Control.Width, 0);
                                rc.Width = ec.Control.Width;
                                break;
                            case DockStyle.None:
                                rc.Size = ec.Control.Size;
                                break;
                        }

                        // Set embedded control's bounds
                        ec.Control.Bounds = rc;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void _embeddedControl_Click(object sender, EventArgs e)
        {
            // When a control is clicked the ListViewItem holding it is selected
            foreach (EmbeddedControl ec in this._embeddedControls)
            {
                if (ec.Control == sender)
                {
                    SelectedItems.Clear();
                    ec.Item.Selected = true;
                }
            }
        }

        private void _embeddedControl_Leave(object sender, EventArgs args)
        {
            // When a control is clicked the ListViewItem holding it is selected
            for (int i = 0; i < this._embeddedControls.Count; i++)
            {
                EmbeddedControl ec = this._embeddedControls[i];

                if (ec.Control == sender)
                {
                    ec.Editing = false;
                    InvokeEmbeddControlEndEditing(new EmbeddControlEndEditingArgs(ec));
                }
            }

            Invalidate();
        }

        #region Nested type: EmbeddedControl

        /// <summary>
        /// Structure to hold an embedded control's info
        /// </summary>
        internal class EmbeddedControl
        {
            public bool AlwasyVisible;
            public int Column;
            public Control Control;
            public DockStyle Dock;
            private bool editing;
            public ListViewItem Item;
            public int Row;

            public bool Editing
            {
                get
                {
                    return this.editing;
                }
                set
                {
                    this.editing = value;
                }
            }
        }

        #endregion
    }

    public class EmbeddControlEndEditingArgs: EventArgs
    {
        internal EmbeddControlEndEditingArgs(ListViewEx.EmbeddedControl ec):
            this(ec.Control, ec.Item, ec.Column, ec.Row, ec.Editing) {}

        public EmbeddControlEndEditingArgs() {}

        public EmbeddControlEndEditingArgs(Control embeddControl, ListViewItem controlItem, int column, int row,
            bool editing)
        {
            EmbeddControl = embeddControl;
            ControlItem = controlItem;
            Column = column;
            Row = row;
            Editing = editing;
        }

        public Control EmbeddControl { get; set; }

        public ListViewItem ControlItem { get; set; }

        public int Column { get; set; }

        public int Row { get; set; }

        public bool Editing { get; set; }
    }

    public delegate void EmbeddControlEndEditingEvent(EmbeddControlEndEditingArgs args);
}