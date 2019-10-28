using System.Collections.Generic;
using System.Windows.Forms;

namespace TFSManager.Forms
{
    public partial class FormCheckedList : Form
    {
        public FormCheckedList()
        {
            InitializeComponent();
        }

        public static bool DialogShow(string formTitle, string caption, List<string> items, bool checkAll)
        {
            FormCheckedList form = new FormCheckedList();
            form.Text = string.Format("TFS Manager / {0}", formTitle);
            form.lbCaption.Text = caption;

            foreach (string item in items)
            {
                form.chItems.Items.Add(item);
                if (checkAll)
                {
                    form.chItems.SetItemChecked(form.chItems.Items.Count-1, true);
                }
            }

            bool result = form.ShowDialog() == DialogResult.OK;

            if (result)
            {
                items.Clear();
                foreach (string checkedItem in form.chItems.CheckedItems)
                {
                    items.Add(checkedItem);
                }
            }

            return result;
        }
    }
}
