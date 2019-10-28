using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TFSManager.Core.WinForms.Controls
{
    public sealed class IconListBox : ListBox
    {
        #region Construction
        private readonly IconItemPaintHelper helper;

        public IconListBox()
        {
            helper = new IconItemPaintHelper();
            DrawMode = DrawMode.OwnerDrawVariable;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }
        #endregion


        #region Methods
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            e.ItemHeight = 18;
        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < this.Items.Count)
            {
                helper.DrawItem(e, e.Index > -1 ? Items[e.Index] : null);
            }
        }
        #endregion


        #region Properties
        public Image DefaultImage
        {
            get { return helper.DefaultImage; }
            set { helper.DefaultImage = value; }
        }
        #endregion
    }

 #region class IconItemPaintHelper

    internal sealed class IconItemPaintHelper
    {
        public IconItemPaintHelper()
        {

        }


        public void DrawItem(DrawItemEventArgs e, object item)
        {
            if (e.Index == -1)
                return;

            if (!(item is IconListEntry))
            {
                if (item is KeyValuePair<String, Int32>)
                {
                    var vp = (KeyValuePair<String, Int32>)item;
                    item = new IconListEntry { Text = vp.Key, Value = vp.Value };
                }
                else
                    return;
            }

            Rectangle fullRect = new Rectangle(e.Bounds.X + 1, e.Bounds.Y,
                e.Bounds.Width - 1, e.Bounds.Height);
            Brush textBrush = SystemBrushes.ControlText;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, fullRect);
                textBrush = SystemBrushes.HighlightText;
            }
            else if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
            {
                e.Graphics.FillRectangle(SystemBrushes.Control, fullRect);
                textBrush = SystemBrushes.GrayText;
            }
            else
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);

            Point imagePoint = new Point(e.Bounds.X + 2, e.Bounds.Y);
            IconListEntry entry = (IconListEntry)item;
            Bitmap bmp = (Bitmap)(entry.Icon ?? DefaultImage);

            if (bmp != null)
            {
                bmp.MakeTransparent(Color.Magenta);
                e.Graphics.DrawImage(bmp, imagePoint);
            }

            e.Graphics.DrawString(entry.Text, ComboBox.DefaultFont, textBrush,
                new Point(e.Bounds.X + 20, e.Bounds.Y + 1));
        }

        public Image DefaultImage { get; set; }
    }

    #endregion class IconItemPaintHelper
}