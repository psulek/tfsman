using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

using TFSManager.Properties;

namespace TFSManager.Controls
{
    [DefaultEvent("ListHeaderStateChanged")]
    public partial class ListHeader: UserControl
    {
        private string _text;
        private bool isMinus = true;

        private ResourceManager rm = null;

        public ListHeader()
        {
            InitializeComponent();

            this.rm = new ResourceManager(GetType());

            //Cursor = Cursors.Hand;

            Paint += new PaintEventHandler(ListHeader_Paint);
        }

        // The text to display inside the control.
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return (this._text);
            }
            set
            {
                this._text = value;
            }
        }

        public event ListHeaderStateChangedEventHandler ListHeaderStateChanged;

        // Paint in a custom gradient background, and render the text centered.
        private void ListHeader_Paint(object sender, PaintEventArgs e)
        {
            var brush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(219, 217, 200),
                Color.FromArgb(196, 193, 176), 90);
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width, Height));

            // Render the text next to the plus/minus box.
            //            int textOffsetX = this.pictureBox1.Location.X + this.pictureBox1.Width;
            //            RectangleF textRect = new RectangleF(textOffsetX + 4, 0, this.Width - textOffsetX, this.Height);
            //            StringFormat textFormat = new StringFormat();
            //            textFormat.Alignment = StringAlignment.Near;
            //            textFormat.LineAlignment = StringAlignment.Center;
            //            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect, textFormat);

            this.lbHeader.Text = Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Image plusImage;

            if (this.isMinus)
            {
                plusImage = (Image) Resources.plusbox; //this.rm.GetObject("plusbox");
                this.isMinus = false;
                OnListHeaderStateChanged(new ListHeaderStateChangedEventArgs(ListHeaderState.Collapsed));
            }
            else
            {
                plusImage = (Image) this.rm.GetObject("pictureBox1.Image");
                this.isMinus = true;
                OnListHeaderStateChanged(new ListHeaderStateChangedEventArgs(ListHeaderState.Expanded));
            }

            this.pictureBox1.Image = plusImage;
        }

        protected virtual void OnListHeaderStateChanged(ListHeaderStateChangedEventArgs e)
        {
            if (ListHeaderStateChanged != null)
            {
                ListHeaderStateChanged(this, e);
            }
        }
    }

    public class ListHeaderStateChangedEventArgs: EventArgs
    {
        private ListHeaderState _state;

        public ListHeaderStateChangedEventArgs(ListHeaderState state): base()
        {
            this._state = state;
        }

        public ListHeaderState State
        {
            get
            {
                return (this._state);
            }
        }
    }

    public enum ListHeaderState
    {
        Expanded = 0,
        Collapsed
    }

    public delegate void ListHeaderStateChangedEventHandler(object sender, ListHeaderStateChangedEventArgs e);
}