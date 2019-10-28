using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.VersionControl.Common;

using TFSManager.Core;

namespace TFSManager.Forms
{
    public partial class FormBrowseTFSFolder: Form
    {
        public FormBrowseTFSFolder()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            PopulateTree();
        }

        private void PopulateTree()
        {
            this.edServer.Text = string.Format("{0} ({1})", Context.TfsServer.Name, Context.TfsServer.Uri);

            this.treeFolders.BeginUpdate();
            this.disableExpandAutoLoad = true;
            try
            {
                this.treeFolders.Nodes.Clear();
                TreeNode rootNode = AddNode(this.treeFolders.Nodes, Context.TfsServer.Name, 0);
                var dummyRootChild = new TreeNode(VersionControlPath.RootFolder + "/dummy");
                rootNode.Nodes.Add(dummyRootChild);
                rootNode.Tag = VersionControlPath.RootFolder;
                rootNode.Expand();
                //AfterExpand(rootNode);
                //rootNode.EnsureVisible();

                if (this._pathToSelect != null)
                {
                    SelectFolder(this._pathToSelect);
                }
            }
            finally
            {
                this.treeFolders.EndUpdate();
                this.disableExpandAutoLoad = false;
            }
        }

        private void PopulateFolders(TreeNode ownerNode, string queryPath)
        {
            ownerNode.Nodes.Clear();

            ItemSet folders = Context.ControlServer.GetItems(queryPath, VersionSpec.Latest, RecursionType.OneLevel,
                DeletedState.NonDeleted,
                ItemType.Folder);
            foreach (Item folderItem in folders.Items)
            {
                if (folderItem.ServerItem == queryPath)
                {
                    continue;
                }

                int icon = VersionControlPath.GetFolderDepth(folderItem.ServerItem) == 1 ? 1 : 2;

                TreeNode newNode = AddNode(ownerNode.Nodes, VersionControlPath.GetFileName(folderItem.ServerItem), icon);
                newNode.Tag = folderItem.ServerItem;

                var dummyNode = new TreeNode(queryPath + "/dummy");
                newNode.Nodes.Add(dummyNode);
            }
        }

        private TreeNode AddNode(TreeNodeCollection ownerNodes, string text, int icon)
        {
            var newNode = new TreeNode(text, icon, icon);
            ownerNodes.Add(newNode);

            return newNode;
        }

        private void treeFolders_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Expand)
            {
                if (this.disableExpandAutoLoad || e.Node == null)
                {
                    return;
                }
                AfterExpand(e.Node);
                return;
            }
        }

        private void AfterExpand(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            if (node.Tag == VersionControlPath.RootFolder)
            {
                node.Nodes.Clear();
            }

            PopulateFolders(node, node.Tag as string);
        }

        private void treeFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                UpdateSelectedNode();
            }
        }

        private void UpdateSelectedNode()
        {
            if (this.treeFolders.SelectedNode != null)
            {
                this.edFolderPath.Text = this.treeFolders.SelectedNode.Tag as string;
            }
            else
            {
                this.edFolderPath.Text = string.Empty;
            }
        }

        private void SelectFolder(string pathToSelect)
        {
            if (pathToSelect.StartsWith(VersionControlPath.RootFolder))
            {
                pathToSelect = pathToSelect.Remove(0, 2);
            }
            var folderParts = new List<string>(pathToSelect.Split('/'));

            SelectFolder(this.treeFolders.Nodes, folderParts);
            UpdateSelectedNode();
        }

        private TreeNode SelectFolder(TreeNodeCollection nodes, List<string> folderParts)
        {
            TreeNode result = null;
            var nodesToRecurse = new List<TreeNode>();

            string folderToFound = folderParts[0];

            foreach (TreeNode node in nodes)
            {
                //AfterExpand(node);
                Application.DoEvents();
                if (stopQuerying)
                {
                    break;
                }

                var serverPath = node.Tag as string;
                string serverItemName = VersionControlPath.GetFileName(serverPath);
                bool equal = VersionControlPath.Equals(folderToFound, serverItemName);

                if (equal)
                {
                    result = node;
                    SetSingleSelectedNode(node, true);
                    folderParts.RemoveAt(0);
                    nodesToRecurse.Clear();
                }
                else
                {
                    //AfterExpand(node);
                }

                if (folderParts.Count > 0 && node.Nodes.Count > 0)
                {
                    nodesToRecurse.Add(node);
                }

                if (equal)
                {
                    break;
                }
            }

            if (nodesToRecurse.Count > 0 && folderParts.Count > 0)
            {
                foreach (TreeNode node in nodesToRecurse)
                {
                    AfterExpand(node);
                    result = SelectFolder(node.Nodes, folderParts);
                    if (result != null)
                    {
                        break;
                    }
                }
            }

            if (result != null)
            {
                AfterExpand(result);

                //                disableExpandAutoLoad = true;
                //                try
                //                {
                //                    TreeNode parent = result.Parent;
                //                    while (parent != null)
                //                    {
                //                        parent.Expand();
                //                        parent = parent.Parent;
                //                    }
                //                }
                //                finally
                //                {
                //                    disableExpandAutoLoad = false;
                //                }
            }

            return result;
        }

        internal void SetSingleSelectedNode(TreeNode node, bool expand)
        {
            this.treeFolders.SelectedNode = node;
            node.EnsureVisible();
            if (expand)
            {
                node.Expand();
            }
        }

        #region DialogShow

        private static FormBrowseTFSFolder form;
        private string _pathToSelect = null;
        private bool disableExpandAutoLoad = false;
        private bool stopQuerying = false;

        internal string SelectedFolder
        {
            get
            {
                return this.treeFolders.SelectedNode.Tag as string;
            }
        }

        public static string DialogShow(string pathToSelect)
        {
            if (form == null)
            {
                form = new FormBrowseTFSFolder();
            }

            form._pathToSelect = pathToSelect;
            form.Initialize();

            return (form.ShowDialog() == DialogResult.OK ? form.SelectedFolder : null);
        }

        #endregion

        private void edFolderPath_KeyUp(object sender, KeyEventArgs e)
        {
            if (!QueryPathTimer.Enabled)
            {
                QueryPathTimer.Enabled = true;
            }
        }

        private void edFolderPath_KeyDown(object sender, KeyEventArgs e)
        {
            DisableTimer();
        }

        private void DisableTimer()
        {
            this.QueryPathTimer.Enabled = false;
        }

        private void QueryPathTimer_Tick(object sender, System.EventArgs e)
        {
            DisableTimer();

            edFolderPath.ReadOnly = true;
            btnStopQuerying.Visible = true;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (!edFolderPath.Text.EndsWith(@"/") && VersionControlPath.IsValidPath(edFolderPath.Text) &&
                    Context.ControlServer.ServerItemExists(edFolderPath.Text, ItemType.Folder))
                {
                    SelectFolder(edFolderPath.Text);
                }
            }
            finally
            {
                btnStopQuerying.Visible = false;
                edFolderPath.ReadOnly = !chQueryMode.Checked;
                this.Cursor = Cursors.Default;
            }
        }

        private void chQueryMode_CheckedChanged(object sender, System.EventArgs e)
        {
            edFolderPath.ReadOnly = !chQueryMode.Checked;
        }

        private void btnStopQuerying_Click(object sender, System.EventArgs e)
        {
            stopQuerying = true;
        }
    }
}