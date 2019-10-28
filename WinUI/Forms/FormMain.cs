using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Core;
using TFSManager.Core.WinForms;
using TFSManager.Properties;

namespace TFSManager.Forms
{
    public partial class FormMain: Form, IUIContext
    {
        internal const int TABIDX_GLOBALLIST = 0;
        internal const int TABIDX_TEAMBUILDS = 3;
        internal const int TABIDX_USERS = 2;
        internal const int TABIDX_WORKITEMS = 1;

        private Queue<TrayIconParams> queuedTrayIconItems = new Queue<TrayIconParams>();
        private readonly object trayIconSync = new object();

        public FormMain()
        {
            InitializeComponent();

            UIContext.Initialize(this);

            bool result = Context.StartupConnect();

            if (!result)
            {
                UserLogin();
            }
            else
            {
                AfterLogin();
            }

            UpdateLoggedInfo();
        }

        public TreeView GlobalListTree
        {
            get
            {
                return this.controlGlobalList.tree;
            }
        }

        private bool UserLogin()
        {
            var form = new LoginForm();
            bool result = (form.ShowDialog() == DialogResult.OK);

            if (result)
            {
                BeforeLogin();

                LoginInfo info = form.GetLoginInfo();
                result = Context.Connect(info);
            }

            if (result)
            {
                AfterLogin();
            }

            return result;
        }

        private void BeforeLogin()
        {
            BuildServerEvents.Instance.OnBuildStatusChanged -= OnBuildStatusChanged;
            
            BuildServerEvents.Instance.DisconnectAll();
        }

        private void AfterLogin()
        {
            this.controlGlobalList.Initialize();
            this.controlWorkItems.Initialize();
            this.controlUsers.Initialize();
            this.controlTeamBuilds.Initialize();
            SetMainTabPage(TABIDX_GLOBALLIST);

            controlUsers.firstTimeLoaded = false;

            BuildServerEvents.Instance.OnBuildStatusChanged += OnBuildStatusChanged;
        }

        private void OnBuildStatusChanged(BuildStatusChangedEventArgs e)
        {
            if (e.Args.Changed)
            {
                foreach (IQueuedBuild build in e.Queue.QueuedBuilds)
                {
                    string message = string.Format("Team build '{0}' requested by '{1}' was promoted to its status '{2}'...", build.BuildDefinition.Name,
                        build.RequestedBy, build.Status);
                    UIContext.Instance.ShowTrayTooltip("Team build status change", message, ToolTipIcon.Info, 
                        new TeamBuildStatusChangeHandler(build));
                }
            }
        }

        public TreeNode FindNode(TreeView treeView, XmlNode xmlNode)
        {
            return this.FindNode(treeView.Nodes, xmlNode);
        }

        internal TreeNode FindNode(TreeNodeCollection nodes, XmlNode xmlNode)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag == xmlNode)
                {
                    return node;
                }

                if (node.Nodes.Count > 0)
                {
                    TreeNode result = FindNode(node.Nodes, xmlNode);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        private void lbTeamServer_Click(object sender, EventArgs e)
        {
            if (UserLogin())
            {
                UpdateLoggedInfo();
            }
        }

        private void UpdateLoggedInfo()
        {
            this.lbTeamServer.Text = string.Format("Team server: {0}", Context.ServerName);
            this.lbLoggedUser.Text = string.Format("Logged as: {0} ({1})", Context.LoggedDisplayUser, Context.LoggedUser);
            this.lbConnectedStatus.Text =
                string.Format("Connection status: {0}", Context.IsConnected ? "connected" : "not connected");
        }

        private void tabPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPages.SelectedTab == tabUsers)
            {
                if (!controlUsers.firstTimeLoaded)
                {
                    controlUsers.PopulateUsers(true, true);
                }
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Context.Disconnect();
        }

        #region IMainForm members

        public Form MainForm
        {
            get { return this; }
        }

        public IControlTeamBuilds ControlTeamBuilds
        {
            get
            {
                return this.controlTeamBuilds;
            }
        }

        public IControlTeamBuildFilter ControlTeamBuildFilter
        {
            get { return this.ControlTeamBuilds.ControlTeamBuildFilter;}
        }


        public IControlWorkItems ControlWorkItems
        {
            get { return this.controlWorkItems; }
        }


        void IUIContext.ShowTrayTooltip(string caption, string message, ToolTipIcon tipIcon, IBalloonClickHander balloonClickHander)
        {
            lock(trayIconSync)
            {
                queuedTrayIconItems.Enqueue(new TrayIconParams(caption, message, tipIcon, balloonClickHander));
            }
        }

        TreeNode IUIContext.FindNode(TreeNodeCollection nodes, XmlNode xmlNode)
        {
            return this.FindNode(nodes, xmlNode);
        }

        void IUIContext.ProgressBegin(int maximum, int step)
        {
            Action action = new Action(() =>
                {
                    this.progressMain.Visible = true;
                    this.progressMain.Maximum = maximum;
                    this.progressMain.Step = step;
                    Application.DoEvents();
                });

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        void IUIContext.ProgressDoStep()
        {
            Action action = new Action(() =>
                {
                    this.progressMain.PerformStep();
                    Application.DoEvents();
                });

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        void IUIContext.ProgressEnd()
        {
            Action action = new Action(() =>
                {
                    this.progressMain.Visible = false;
                    Application.DoEvents();
                });

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        void IUIContext.HandleError(Exception exception)
        {
            MessageBox.Show(string.Format("Error: {0}", exception.Message), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);                
        }

        public void LogMessage(IconListEntry entry)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<IconListEntry>(this.LogMessage), entry);
                return;
            }

            this.logBox.Items.Add(entry);
            this.logBox.SelectedIndex = this.logBox.Items.Count - 1;
        }

        public void LogMessageNewLine()
        {
            LogMessage(new IconListEntry(GetLogImage(LogImage.Empty), string.Empty));
        }

        public Image GetLogImage(LogImage logImage)
        {
            Image result = Resources.Empty;

            switch (logImage)
            {
                case LogImage.Info:
                    result = Resources.Information;
                    break;
                case LogImage.Warning:
                    result = Resources.Warning;
                    break;
                case LogImage.Error:
                    result = Resources.Error;
                    break;
            }

            return result;
        }

        public void SetMainTabPage(int index)
        {
            tabPages.SelectedIndex = index;
        }

        public int GetMainTabPage()
        {
            return tabPages.SelectedIndex;
        }

        public void SetGlobalListSelectedNode(TreeNode node)
        {
            GlobalListTree.SelectedNode = node;
        }

        public TreeNode GetGlobalListSelectedNode()
        {
            return GlobalListTree.SelectedNode;
        }

        #endregion IMainForm members

        private void mniShowMainForm_Click(object sender, EventArgs e)
        {
            ReshowForm();
        }

        private void ReshowForm() 
        {
            this.Show();
            this.BringToFront();
        }

        private void trayIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            ReshowForm();
            IBalloonClickHander hander = this.trayIcon.Tag as IBalloonClickHander;
            if (hander != null)
            {
                try
                {
                    hander.OnClick();
                }
                catch (Exception ex)
                {
                    UIContext.Instance.HandleError(ex);
                }
            }
        }

        #region class TrayIconParams

        public class TrayIconParams
        {
            public TrayIconParams(string caption, string message, ToolTipIcon tipIcon, IBalloonClickHander balloonClickHander)
            {
                this.Caption = caption;
                this.Message = message;
                this.TipIcon = tipIcon;
                this.BalloonClickHander = balloonClickHander;
            }

            public string Caption { get; private set; }

            public string Message { get; private set; }

            public ToolTipIcon TipIcon { get; private set; }

            public IBalloonClickHander BalloonClickHander { get; private set; }
        }

        #endregion class TrayIconParams

        private void timerForTrayIcon_Tick(object sender, EventArgs e)
        {
            timerForTrayIcon.Enabled = false;
            TrayIconParams trayIconParams = null;
            lock(trayIconSync)
            {
                if (this.queuedTrayIconItems.Count > 0)
                {
                    trayIconParams = this.queuedTrayIconItems.Dequeue();
                }
            }

            if (trayIconParams != null)
            {
                trayIcon.Tag = trayIconParams.BalloonClickHander;
                trayIcon.ShowBalloonTip(3000, trayIconParams.Caption, trayIconParams.Message, trayIconParams.TipIcon);
            }
            else
            {
                timerForTrayIcon.Enabled = true;
            }
        }

        private void trayIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            timerForTrayIcon.Enabled = true;
        }
    }

    #region class TeamBuildStatusChangeHandler

    internal class TeamBuildStatusChangeHandler: IBalloonClickHander
    {
        private readonly IQueuedBuild build;

        public TeamBuildStatusChangeHandler(IQueuedBuild build)
        {
            this.build = build;
        }

        public void OnClick()
        {
            UIContext.Instance.ControlTeamBuilds.FocusAndSelectTeamBuild(build);
            UIContext.Instance.SetMainTabPage(FormMain.TABIDX_TEAMBUILDS);
        }
    }

    #endregion class TeamBuildStatusChangeHandler
}