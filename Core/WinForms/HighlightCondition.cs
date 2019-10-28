using System.Drawing;

namespace TFSManager.Core.WinForms
{
    public class HighlightCondition
    {
        public HighlightCondition(string value, Color foreColor): this(value, foreColor, Color.Transparent) {}

        public HighlightCondition(string value, Color foreColor, Color backColor)
        {
            this.Value = value;
            this.ForeColor = foreColor;
            this.BackColor = backColor;
        }

        public string Value { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
    }
}