using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Linq;

namespace TFSManager.Core.WinForms.Controls
{
    [Designer(typeof(XPLinkLabelDesigner))]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(LinkLabel))]
    public class XPLinkLabel: Label
    {
        #region " API "

        private const int WM_SETCURSOR = 32;
        private const int WM_MOUSELEAVE = 675;
        private const int IDC_HAND = 32649;

        [DllImport("user32.dll")]
        private static extern int LoadCursor(int hInstance, int lpCursorName);

        [DllImport("user32.dll")]
        private static extern int SetCursor(int hCursor);

        #endregion

        private Color _ColorNormal = SystemColors.ActiveCaption;
        private Color _ColorHover = SystemColors.GradientActiveCaption;
        private Font _FontNormal = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((238)));
        private Font _FontHover = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((238)));
        private Color savedBackColor = SystemColors.Control;
        private bool savedDoubleBuffered = true;

        [Category("Appearance")]
        [Description("Color of the text while the mouse is NOT hovering over it.")]
        public Color ColorNormal
        {
            get
            {
                return this._ColorNormal;
            }
            set
            {
                ForeColor = value;
                this._ColorNormal = value;
            }
        }

        [Category("Appearance")]
        [Description("Color of the text while the mouse is hovering over it.")]
        public Color ColorHover
        {
            get
            {
                return this._ColorHover;
            }
            set
            {
                this._ColorHover = value;
            }
        }

        [Category("Appearance")]
        public Font FontNormal
        {
            get
            {
                return this._FontNormal;
            }
            set
            {
                this._FontNormal = value;
            }
        }

        [Category("Appearance")]
        public Font FontHover
        {
            get
            {
                return this._FontHover;
            }
            set
            {
                this._FontHover = value;
            }
        }

        private bool transparentBackground;

        [DefaultValue(true)]
        public bool TransparentBackground
        {
            get { return this.transparentBackground; }
            set
            {
                if (this.transparentBackground != value)
                {
                    this.transparentBackground = value;

                    if (value)
                    {
                        savedBackColor = this.BackColor;
                        savedDoubleBuffered = this.DoubleBuffered;
                        this.BackColor = Color.Transparent;
                        this.DoubleBuffered = false;
                    }
                    else
                    {
                        this.BackColor = this.savedBackColor;
                        this.DoubleBuffered = this.savedDoubleBuffered;
                    }

                    this.Invalidate();
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_SETCURSOR:
                    SetCursor(LoadCursor(0, IDC_HAND));
                    Font = _FontHover; //new Font(Font.Name, Font.Size, FontStyle.Underline);
                    ForeColor = this._ColorHover;
                    break;
                case WM_MOUSELEAVE:
                    SetCursor(0);
                    Font = _FontNormal; //new Font(Font.Name, Font.Size, FontStyle.Regular);
                    ForeColor = this._ColorNormal;
                    break;
            }
        }

        public XPLinkLabel()
        {
            ForeColor = this._ColorNormal;
            AutoSize = false;
            Height = 16;

            this.transparentBackground = true;

            this.BackColor = Color.Transparent;
            this.DoubleBuffered = false;
        }

        /// <summary>
        /// Overrides base class CreateParams method to add Transparency style
        /// to the label window.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                if (this.TransparentBackground)
                {
                    cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
                }

                return cp;
            }
        }

        /// <summary>
        /// Overrides base class OnPaintBackground method 
        /// to avoid background painting.
        /// </summary>
        /// <param name="pevent">Paint event arguments.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (!this.TransparentBackground)
            {
                base.OnPaintBackground(pevent);
            }
        }

        public new bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                if (value != base.AutoSize)
                {
                    if (value)
                    {
                        Graphics graphics = this.CreateGraphics();
                        SizeF calculatedA = graphics.MeasureString(this.Text, this.FontNormal);
                        SizeF calculatedB = graphics.MeasureString(this.Text, this.Font);
                        SizeF calculatedC = graphics.MeasureString(this.Text, this.FontHover);

                        float maxWidth = new[] {calculatedA.Width, calculatedB.Width, calculatedC.Width}.Max();

                        int width = (int)Math.Ceiling(maxWidth);
                        this.Size = new Size(width + 7, (int)calculatedA.Height);
                    }
                    base.AutoSize = value;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //SmoothingMode sm = e.Graphics.SmoothingMode;
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            try
            {
                //            if (!this.Enabled && (this.Image != null))
                //            {
                //                base.OnPaint(e);
                //                return;
                //            }

                /*if (this.AutoSize)
                {
                    SizeF calculatedSize = e.Graphics.MeasureString(this.Text, this.Font);
                    //MessageBox.Show(string.Format("Size: {0}, calculated size: {1}", this.Size, calculatedSize));
                    this.Size = calculatedSize.ToSize();
                }*/

                Rectangle imageRect = new Rectangle();
                Rectangle textRect = new Rectangle();

                imageRect.X = 0 + Padding.Left;
                imageRect.Y = 0 + Padding.Top;

                if ((Image != null))
                {
                    imageRect.Width = Image.Width;
                    imageRect.Height = Image.Height;

                    textRect.X = Image.Width + Padding.Left + 5;

                    if (Enabled)
                    {
                        e.Graphics.DrawImage(Image, imageRect);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(e.Graphics, Image, imageRect.X, imageRect.Y, BackColor);
                    }
                }
                else
                {
                    textRect.X = 0 + Padding.Left;
                }

                textRect.Y = (int) (1.25 + Padding.Top);
                textRect.Height = Height - (Padding.Bottom + Padding.Top);
                textRect.Width = this.Size.Width + 5; //(Width - textRect.X - Padding.Right) + 7;


                if (Enabled)
                {
                    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRect);
                }
                else
                {
                    Rectangle r = base.ClientRectangle;
                    ControlPaint.DrawStringDisabled(e.Graphics, Text, Font, SystemColors.ControlLight, textRect,
                        StringFormat.GenericDefault);
                }
            }
            finally
            {
                //e.Graphics.SmoothingMode = sm;
            }
        }
    }

    public class XPLinkLabelDesigner: ControlDesigner
    {
        private DesignerActionListCollection lists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (this.lists == null)
                {
                    this.lists = new DesignerActionListCollection();
                    this.lists.Add(new XPLinkLabelActionList(Component));
                }
                return this.lists;
            }
        }

        //remove the properties that we don't want the user to change
        protected override void PreFilterProperties(IDictionary properties)
        {
            //            properties.Remove("Cursor");
            //            properties.Remove("ForeColor");
            //            properties.Remove("ImageAlign");
            //            properties.Remove("TextAlign");
            //            properties.Remove("AutoSize");
        }
    }

    public class XPLinkLabelActionList: DesignerActionList
    {
        private readonly XPLinkLabel MyLabel;
        private DesignerActionUIService designerActionSvc;

        public XPLinkLabelActionList(IComponent component)
            : base(component)
        {
            this.MyLabel = component as XPLinkLabel;
            this.designerActionSvc = (DesignerActionUIService) GetService(typeof(DesignerActionUIService));
        }

        private PropertyDescriptor GetPropertyByName(string propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(this.MyLabel)[propName];
            if (prop == null)
            {
                throw new ArgumentException("Invalid property.", propName);
            }
            else
            {
                return prop;
            }
        }

        public Color ColorNormal
        {
            get
            {
                return this.MyLabel.ColorNormal;
            }
            set
            {
                GetPropertyByName("ColorNormal").SetValue(this.MyLabel, value);
            }
        }

        public Color ColorHover
        {
            get
            {
                return this.MyLabel.ColorHover;
            }
            set
            {
                GetPropertyByName("ColorHover").SetValue(this.MyLabel, value);
            }
        }

        public Image Image
        {
            get
            {
                return this.MyLabel.Image;
            }
            set
            {
                GetPropertyByName("Image").SetValue(this.MyLabel, value);
            }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();
            items.Add(new DesignerActionHeaderItem("Appearance"));
            items.Add(
                new DesignerActionPropertyItem("Image", "Link Image", "Appearance",
                    "Sets the image to be displayed in the label."));
            items.Add(
                new DesignerActionPropertyItem("ColorNormal", "Normal Color", "Appearance",
                    "Sets the color of the text while the mouse is NOT hovering over it."));
            items.Add(
                new DesignerActionPropertyItem("ColorHover", "Hover Color", "Appearance",
                    "Sets the color of the text while the mouse is hovering over it."));
            return items;
        }
    }
}