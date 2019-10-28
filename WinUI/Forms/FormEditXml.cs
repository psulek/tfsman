using System;
using System.Threading;
using System.Windows.Forms;

using TFSManager.Core;

namespace TFSManager.Forms
{
    public partial class FormEditXml : Form
    {
        public FormEditXml()
        {
            InitializeComponent();
        }

        public Func<string> OnInitialLoadFromServer;
        public Func<string> OnReloadFromServer;
        private string caption;
        private string fileContent;
        private ManualResetEvent loadedDataEvent = new ManualResetEvent(false);
        private bool formClosing = false;

        public static bool DialogShow(string caption, ref string xmlText, 
            Func<string> onInitialLoadFromServer, Func<string> onReloadFromServer)
        {
            FormEditXml form = new FormEditXml();
            form.OnInitialLoadFromServer = onInitialLoadFromServer;
            form.OnReloadFromServer = onReloadFromServer;
            form.caption = caption;
            bool result = form.ShowDialog() == DialogResult.OK;

            xmlText = form.xmlEditor.EditorText;
            return result;
        }

        private void btnReload_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Do you want to reload file content from server?", "Reload from Server",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            if (OnReloadFromServer != null)
            {
                string fromServerValue = OnReloadFromServer();
                this.xmlEditor.EditorText = fromServerValue;
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Do you want to save changes to server?", "Save changes",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void FormEditXml_Load(object sender, System.EventArgs e)
        {
            UpdateControl(false);
            this.Cursor = Cursors.WaitCursor;
            this.btnCancel.Cursor = Cursors.Default;
            this.timer.Enabled = true;
            this.lbCaption.Text = "Downloading file from server...";
        }

        private void UpdateControl(bool enabled)
        {
            this.xmlEditor.Enabled = enabled;
            this.btnReload.Enabled = enabled;
            this.btnSave.Enabled = enabled;
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            timer.Enabled = false;

            ThreadPool.QueueUserWorkItem(delegate(object o)
                {
                    fileContent = this.OnInitialLoadFromServer();
                    loadedDataEvent.Set();
                });

            bool dataLoaded = false;
            DateTime startTime = DateTime.Now;
            bool loadCancel = false;

            while (!dataLoaded && !loadCancel && !this.formClosing)
            {
                dataLoaded = this.loadedDataEvent.WaitOne(100);
                Application.DoEvents();

                TimeSpan duration = DateTime.Now - startTime;
                if (duration.TotalMinutes >= 1)
                {
                    loadCancel = true;
                }
            }

            if ((loadCancel || this.formClosing) && !dataLoaded)
            {
                this.caption = "Could not load data from server, timeouted to load data!";
                fileContent = string.Empty;
            }
            else
            {
                UpdateControl(true);
            }

            if (!this.formClosing)
            {
                this.Cursor = Cursors.Default;
                this.lbCaption.Text = this.caption;
                this.xmlEditor.EditorText = fileContent;
            }
        }

        private void FormEditXml_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.formClosing = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.formClosing = true;
        }
    }
}
