using System;
using System.Drawing;
using System.Windows.Forms;

using TFSManager.Core;

namespace TFSManager.Forms
{
    public partial class FormEditBox: Form
    {
        public FormEditBox()
        {
            InitializeComponent();
        }

        private static FormEditBox form = null;
        private bool requiredValue;
        private bool autoClose;
        private event EventHandler<OkClickEventArgs> okClicked;

        private void Initialize(string caption, string text, string okText, string cancelText, DialogResult buttons,
            string initValue, Bitmap okImage, Bitmap cancelImage, bool requiredValue, bool autoClose, EventHandler<OkClickEventArgs> okClicked)
        {
            Text = caption;
            this.lbText.Text = text;
            this.btnOk.Text = okText ?? "Ok";
            this.btnOk.Image = okImage;
            this.btnOk.Visible = Util.IsFlagSet(DialogResult.OK, buttons);
            this.btnCancel.Text = cancelText ?? "Cancel";
            this.btnCancel.Image = cancelImage;
            this.btnCancel.Visible = Util.IsFlagSet(DialogResult.Cancel, buttons);
            this.edValue.Text = initValue;
            this.requiredValue = requiredValue;
            this.autoClose = autoClose;
            this.okClicked = okClicked;
            
            btnOk.DialogResult = autoClose ? DialogResult.OK : DialogResult.None;
        }

        public static DialogResult DialogShow(string caption, string text, string okText, Bitmap okImage,
            bool requiredValue, ref string resultValue)
        {
            return DialogShow(caption, text, okText, okImage, requiredValue, true, ref resultValue);
        }

        public static DialogResult DialogShow(string caption, string text, string okText, Bitmap okImage,
            bool requiredValue, bool autoClose, ref string resultValue)
        {
            return DialogShow(caption, text, okText, okImage, requiredValue, autoClose, null, ref resultValue);
        }

        public static DialogResult DialogShow(string caption, string text, string okText, Bitmap okImage,
            bool requiredValue, bool autoClose, EventHandler<OkClickEventArgs> okClicked, ref string resultValue)
        {
            return DialogShow(caption, text, okText, null, okImage, null, DialogResult.OK | DialogResult.Cancel,
                requiredValue, autoClose, okClicked, ref resultValue);
        }

        public static DialogResult DialogShow(string caption, string text, string okText, string cancelText,
            Bitmap okImage, Bitmap cancelImage, DialogResult buttons, bool requiredValue, bool autoClose, EventHandler<OkClickEventArgs> okClicked, 
            ref string resultValue)
        {
            if (form == null)
            {
                form = new FormEditBox();
            }

            form.Initialize(caption, text, okText, cancelText, buttons, resultValue, okImage, cancelImage, requiredValue,
                autoClose, okClicked);

            DialogResult result = form.ShowDialog();
            resultValue = form.edValue.Text;

            return result;
        }

        private void FormEditBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && string.IsNullOrEmpty(edValue.Text) && this.requiredValue)
            {
                MessageBox.Show("Value is required", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void FormEditBox_Shown(object sender, System.EventArgs e)
        {
            this.edValue.Focus();
            this.edValue.SelectAll();
        }


        private void InvokeOkClicked()
        {
            EventHandler<OkClickEventArgs> clicked = this.okClicked;
            if (clicked != null)
            {
                clicked(this, new OkClickEventArgs{Value = edValue.Text});
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            InvokeOkClicked();
        }
    }

    public class OkClickEventArgs: EventArgs
    {
        public string Value { get; set; }
    }
}