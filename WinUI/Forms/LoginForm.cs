using System;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Client;

using TFSManager.Core;

namespace TFSManager.Forms
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ReloadServers();
            this.edUserName.Text = Context.LoginInfo.UserName != null ? Context.LoginInfo.UserName : "";
            this.edPassword.Text = Context.LoginInfo.Password != null ? Context.LoginInfo.Password : "";
            this.edDomain.Text = Context.LoginInfo.Domain != null
                ? Context.LoginInfo.Domain : Environment.UserDomainName;
            this.chUseCurrentCredentials.Checked = (Context.LoginInfo.UserName == null);
        }


        /// <summary>
        /// Reloads the servers.
        /// </summary>
        public void ReloadServers()
        {
            // Get the registered server list and populate the combo box with them
            string[] serverNames = RegisteredServers.GetServerNames();
            foreach (string server in serverNames)
            {
                this.cmbServers.Items.Add(server);
            }

            // If there is at least one server than set it as the current server
            if (serverNames.Length > 0)
            {
                this.cmbServers.Text = serverNames[0];
            }
        }

        /// <summary>
        /// Gets the login info.
        /// </summary>
        /// <returns></returns>
        public LoginInfo GetLoginInfo()
        {
            if (this.chUseCurrentCredentials.Checked)
            {
                return new LoginInfo(this.cmbServers.Text);
            }
            else
            {
                return new LoginInfo(this.edDomain.Text, this.edUserName.Text, this.edPassword.Text,
                    this.cmbServers.Text);
            }
        }

        private void chUseCurrentCredentials_CheckedChanged(object sender, EventArgs e)
        {
            this.edUserName.ReadOnly = this.chUseCurrentCredentials.Checked;
            this.edPassword.ReadOnly = this.chUseCurrentCredentials.Checked;
            this.edDomain.ReadOnly = this.chUseCurrentCredentials.Checked;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            LoginInfo info = GetLoginInfo();

            bool result = TFSUtils.TestConnection(info);

            MessageBox.Show(string.Format("Connection test {0}", result ? "passed." : "failed."));
        }
    }
}