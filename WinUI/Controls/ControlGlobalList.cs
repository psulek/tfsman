using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using TFSManager.Core;
using TFSManager.Forms;
using TFSManager.Properties;

namespace TFSManager.Controls
{
    public partial class ControlGlobalList: UserControl
    {
        public ControlGlobalList()
        {
            InitializeComponent();
        }

        private TreeNode SelectedNode
        {
            get
            {
                return this.tree.SelectedNode;
            }
            set
            {
                this.tree.SelectedNode = value;
            }
        }

        internal void Initialize()
        {
            RefreshGlobalList();
        }

        /// <summary>
        /// Show/Hide an hourglass cursor
        /// </summary>
        /// <param name="Show"></param>
        private void Hourglass(bool Show)
        {
            if (Show)
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }
            return;
        }

        private void RefreshGlobalList()
        {
            if (this.tree.Nodes.Count > 0)
            {
                this.tree.Nodes.RemoveAt(0);
            }

            Hourglass(true);

            if (Context.IsConnected)
            {
                Context.ExportGlobalLists();

                var rootNode = new TreeNode("Global List");
                rootNode.ImageIndex = 0;
                foreach (XmlNode list in Context.GlobalLists.DocumentElement.ChildNodes)
                {
                    var listNode = new TreeNode(list.Attributes["name"].Value);
                    listNode.Tag = "Server";
                    listNode.ImageIndex = 1;
                    listNode.SelectedImageIndex = 1;

                    foreach (XmlNode listItem in list.ChildNodes)
                    {
                        var treeListItem = new TreeNode(listItem.Attributes["value"].Value);
                        treeListItem.Tag = listItem;
                        treeListItem.ImageIndex = 2;
                        treeListItem.SelectedImageIndex = 2;
                        listNode.Nodes.Add(treeListItem);
                    }

                    rootNode.Nodes.Add(listNode);
                }
                rootNode.Expand();
                this.tree.Nodes.Add(rootNode);
            }

            Hourglass(false);

            UpdateButtons();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGlobalList();
        }

        private void UpdateButtons()
        {
            btnNewItem.Enabled = (this.SelectedNode != null && this.SelectedNode.Level == 1);
            btnEditItem.Enabled = (this.SelectedNode != null && this.SelectedNode.Level == 2);
            btnDeleteItem.Enabled = (this.SelectedNode != null && this.SelectedNode.Level == 2);

            this.mniGL_NewItem.Enabled = btnNewItem.Enabled;
            this.mniGL_EditItem.Enabled = btnEditItem.Enabled;
            this.mniGL_DeleteItem.Enabled = btnDeleteItem.Enabled;

            mniGL_FindRelatedWI.Enabled = (this.SelectedNode != null && this.SelectedNode.Level > 0);
        }

        /// <summary>
        /// Creates a new Node in the TreeView using the selected node
        /// </summary>
        private void NewItem()
        {
            TreeNode targetNode;

            if (SelectedNode.Parent != null && SelectedNode.Parent == this.tree.Nodes[0])
            {
                targetNode = SelectedNode;
            }
            else if (SelectedNode.Parent != null)
            {
                targetNode = SelectedNode.Parent;
            }
            else if (SelectedNode == this.tree.Nodes[0])
            {
                targetNode = SelectedNode;
            }
            else
            {
                MessageBox.Show("Please select a target list");
                return;
            }

            var newNode = new TreeNode("New Item");
            newNode.ImageIndex = 2;
            newNode.SelectedImageIndex = 2;

            //SelectedNode = newNode;

            this.tree.LabelEdit = true;

            targetNode.Nodes.Add(newNode);
            this.tree.SelectedNode = newNode;
            ExpandParents(newNode);
            newNode.BeginEdit();
        }

        private void ExpandParents(TreeNode node)
        {
            while (node.Parent != null)
            {
                node.Parent.Expand();
                node = node.Parent;
            }
        }

        /// <summary>
        /// Creates the Global List XML Document from the TreeView
        /// </summary>
        /// <returns>XML Document in Global List Format</returns>
        private XmlDocument CreateXMLDocFromTree()
        {
            var doc = new XmlDocument();
            XmlElement rootNode = doc.CreateElement("gl", "GLOBALLISTS",
                "http://schemas.microsoft.com/VisualStudio/2005/workitemtracking/globallists");


            foreach (TreeNode treeList in this.tree.Nodes[0].Nodes)
            {
                XmlElement listNode = doc.CreateElement("GLOBALLIST");
                XmlAttribute listNodeName = doc.CreateAttribute("name");
                listNodeName.Value = treeList.Text;
                listNode.Attributes.Append(listNodeName);

                if (treeList.Nodes.Count > 0)
                {
                    foreach (TreeNode treeListItem in treeList.Nodes)
                    {
                        XmlElement listItemNode = doc.CreateElement("LISTITEM");
                        XmlAttribute listItemNodeValue = doc.CreateAttribute("value");
                        listItemNodeValue.Value = treeListItem.Text;
                        listItemNode.Attributes.Append(listItemNodeValue);
                        listNode.AppendChild(listItemNode);
                    }
                }
                else
                {
                    XmlElement listItemNode = doc.CreateElement("LISTITEM");
                    XmlAttribute listItemNodeValue = doc.CreateAttribute("value");
                    listItemNodeValue.Value = Context.BUILD_NONE;
                    listItemNode.Attributes.Append(listItemNodeValue);
                    listNode.AppendChild(listItemNode);
                }

                rootNode.AppendChild(listNode);
            }
            doc.AppendChild(rootNode);
            return doc;
        }

        private void btnUpdateChanges_Click(object sender, EventArgs e)
        {
            Hourglass(true);

            XmlDocument doc = CreateXMLDocFromTree();

            //ask if we want to back up global list first
            DialogResult backupDialog = MessageBox.Show("Would you like to backup the current global list?",
                "Backup List?", MessageBoxButtons.YesNo);

            if (backupDialog == DialogResult.Yes)
            {
                DialogResult saveDiagResult = this.saveFileDialog1.ShowDialog();

                if (saveDiagResult == DialogResult.OK)
                {
                    Context.ItemStore.ExportGlobalLists().Save(this.saveFileDialog1.FileName);
                }
                else
                {
                    Hourglass(false);
                    return;
                }
            }

            try
            {
                Context.ItemStore.ImportGlobalLists(doc.DocumentElement);
                MessageBox.Show("Global List Saved.");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Could not save the list. Error:" + exp);
            }

            Hourglass(false);
        }

        private void tree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && btnDeleteItem.Enabled)
            {
                mniGL_DeleteItem_Click(sender, e);
            }

            if (e.KeyCode == Keys.Insert && btnNewItem.Enabled)
            {
                mniGL_NewItem_Click(sender, e);
            }
        }

        private void tree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (SelectedNode.Parent == this.tree.Nodes[0] && SelectedNode.Tag == "Server")
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("Cannot rename lists that have been saved to the server.");
                    }
                    else if (e.Label.IndexOfAny(new[] {'@', ',', '!', '\\'}) == -1)
                    {
                        // Stop editing without canceling the label change.
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n" +
                            "The invalid characters are: '@', ',', '!', '\'",
                            "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                        "Node Label Edit");
                    e.Node.Parent.Expand();
                    e.Node.Expand();
                    e.Node.BeginEdit();
                }
                this.tree.LabelEdit = false;
            }
        }

        private string GetTeamProjectName(TreeNode node)
        {
            string[] split = node.Text.Split('-');
            if (split.Length > 0)
            {
                return split[split.Length - 1].Trim();
            }

            return string.Empty;
        }

        private string BuildINCondition(TreeNode parentNode)
        {
            var sb = new StringBuilder();

            foreach (TreeNode node in parentNode.Nodes)
            {
                sb.AppendFormat("'{0}',", node.Text);
            }

            string result = sb.ToString();
            return result.Remove(result.Length - 1, 1);
        }

        private void mniGL_FindRelatedWI_Click(object sender, EventArgs e)
        {
            if (!Context.IsConnected)
            {
                return;
            }
            TreeNode selectedNode = this.tree.SelectedNode;
            if (selectedNode == null || selectedNode.Level == 0)
            {
                return;
            }

            string inCondition;
            TreeNode teamProjectNode;
            if (selectedNode.Tag == "Server")
            {
                if (selectedNode.Nodes.Count == 0)
                {
                    return;
                }

                teamProjectNode = selectedNode;

                inCondition = BuildINCondition(selectedNode);
            }
            else
            {
                inCondition = string.Format("'{0}'", selectedNode.Text);
                teamProjectNode = selectedNode.Parent;
            }

            if (teamProjectNode == null)
            {
                return;
            }

            string teamProject = GetTeamProjectName(teamProjectNode);

            string query = string.Format(
                @"SELECT [System.Id], [System.Title], [System.TeamProject], [Microsoft.VSTS.Build.FoundIn], [Microsoft.VSTS.Build.IntegrationBuild] FROM WorkItems 
WHERE ([Microsoft.VSTS.Build.FoundIn] IN ({0}) OR [Microsoft.VSTS.Build.IntegrationBuild] IN ({0})) AND [System.TeamProject] = '{1}'
ORDER BY [System.TeamProject] ASC, [System.Id] DESC",
                inCondition, teamProject);

            UIContext.Instance.ControlWorkItems.FindRelatedWorkItems(teamProject, query, null);
            //this.mainForm.controlWorkItems.FindRelatedWI(teamProject, query, null);//TODO: filter hight...
        }

        private void mniGL_NewItem_Click(object sender, EventArgs e)
        {
            NewItem();
        }

        private void mniGL_EditItem_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null && SelectedNode.Parent != null)
            {
                this.tree.SelectedNode = SelectedNode;
                this.tree.LabelEdit = true;
                if (!SelectedNode.IsEditing)
                {
                    SelectedNode.BeginEdit();
                }
            }
            else
            {
                MessageBox.Show("No tree node selected or selected node is a root node.\n" +
                    "Editing of root nodes is not allowed.", "Invalid selection");
            }
        }

        private void mniGL_DeleteItem_Click(object sender, EventArgs e)
        {
            if (SelectedNode == null) return;

            if (MessageBox.Show(string.Format("Do you want to delete selected item '{0}'?", SelectedNode.Text), 
                "Delete item", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (this.tree.Nodes[0] != SelectedNode) //Can't delete root node
            {
                if (SelectedNode.Parent == this.tree.Nodes[0] && SelectedNode.Tag == "Server")
                {
                    MessageBox.Show("Cannot delete lists that have been saved to the server.");
                }
                else
                {
                    this.tree.Nodes.Remove(SelectedNode);
                }
            }
            else
            {
                MessageBox.Show("Cannot delete the root node.");
            }
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateButtons();
        }

        private void menuGlobalList_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateButtons();

            string item = string.Empty;
            if (SelectedNode != null)
            {
                item = SelectedNode.Text;
            }
            mniGL_FindRelatedWI.Text = string.Format("Find related work items for '{0}'", item);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DoFind();
        }

        private void DoFind() 
        {
            string findValue = string.Empty;
            if (FormEditBox.DialogShow("Find item in global list", "Enter item name", "Find...", Resources.file_find,
                true, false, (sender,args) => FindItem(args.Value), ref findValue) == DialogResult.Cancel)
            {
                return;
            }

            //FindItem(findValue);
        }

        private void FindItem(string findValue) 
        {
            TreeNode node = this.tree.Nodes[0];
            if (this.SelectedNode != null)
            {
                node = this.SelectedNode;
            }
            else
            {
                if (Util.StrContain(node.Text, findValue, true))
                {
                    this.SelectedNode = node;
                    return;
                }
            }

            this.SelectedNode = FindNode(node, findValue);

            if (this.SelectedNode != null)
            {
                this.SelectedNode.EnsureVisible();
            }
        }

        private TreeNode FindNode(TreeNode fromNode, string findValue)
        {
            TreeNode result;

            do
            {
                result = FindInNodes(fromNode.Nodes, findValue);
                if (result != null)
                {
                    break;
                }

                fromNode = fromNode.NextNode;
            } while (fromNode != null);

            return result;
        }

        private TreeNode FindInNodes(TreeNodeCollection nodes, string findValue)
        {
            TreeNode result = null;

            foreach (TreeNode node in nodes)
            {
                if (Util.StrContain(node.Text, findValue, true))
                {
                    result = node;
                }
                else if (node.Nodes.Count > 0)
                {
                    result = FindInNodes(node.Nodes, findValue);
                }

                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

        private void mniFindItem_Click(object sender, EventArgs e)
        {
            DoFind();
        }
    }
}