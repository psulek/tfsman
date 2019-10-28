using System.Windows.Forms;

namespace TFSManager.Forms
{
    public partial class FormGotoWorkItem: Form
    {
        public FormGotoWorkItem()
        {
            InitializeComponent();
        }

        private static FormGotoWorkItem form;

        public static bool DialogShow(out int ID, out bool newQuery)
        {
            if (form == null)
            {
                form = new FormGotoWorkItem();
            }

            form.edID.Focus();
            form.edID.Select(0, form.edID.Text.Length);

            bool result = form.ShowDialog() == DialogResult.OK;
            ID = (int) form.edID.Value;
            newQuery = form.rbMakeNewQuery.Checked;

            return result;
        }
    }
}