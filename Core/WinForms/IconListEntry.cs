using System.Drawing;

namespace TFSManager.Core.WinForms
{
    public sealed class IconListEntry
    {
        #region Construction

        public IconListEntry(string text, object value): this(null, text, value) {}

        public IconListEntry(Image icon, string text, object value)
        {
            this.Icon = icon;
            this.Text = text;
            this.Value = value;
        }

        public IconListEntry(string text): this(null, text)
        {}

        public IconListEntry(Image icon, string text): this(icon, text, text)
        {}

        public IconListEntry() {}

        #endregion


        #region Methods
        public override string ToString()
        {
            return Text;
        }
        #endregion


        #region Properties
        public Image Icon { get; set; }

        public string Text { get; set; }

        public object Value { get; set; }
        #endregion
    }
}