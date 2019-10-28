using System.Drawing;
using System.Windows.Forms;

using TFSManager.Core;

namespace TFSManager.Components
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        public static LoadingForm DialogShow(string message, IWin32Window ownerForm)
        {
            LoadingForm form = new LoadingForm();
            form.lbMessage.Text = message;

            if (ownerForm == null)
            {
                ownerForm = UIContext.Instance.MainForm;
            }

            form.Show(ownerForm);
            return form;
        }

        private void LoadingForm_Load(object sender, System.EventArgs e)
        {
            Point location = UIContext.Instance.MainForm.Location;
            Rectangle rect = UIContext.Instance.MainForm.DesktopBounds;

            int x = (rect.Width - this.Width) / 2;
            int y = (rect.Height - this.Height) / 2;
            this.Location = new Point(location.X + x, location.Y + y);
        }
    }
}
