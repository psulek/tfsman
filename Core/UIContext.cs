using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using TFSManager.Core.WinForms;

namespace TFSManager.Core
{
    public class UIContext: IUIContext
    {
        private IUIContext mainForm;
        private readonly static UIContext instance = new UIContext();

        public static IUIContext Instance
        {
            get
            {
                return instance;
            }
        }

        public static void Initialize(IUIContext form)
        {
            instance.mainForm = form;
        }

        #region Implementation of IUIContext

        public Form MainForm
        {
            get { return mainForm.MainForm; }
        }

        public IControlTeamBuilds ControlTeamBuilds
        {
            get { return mainForm.ControlTeamBuilds; }
        }

        public IControlTeamBuildFilter ControlTeamBuildFilter
        {
            get { return this.mainForm.ControlTeamBuildFilter; }
        }

        public IControlWorkItems ControlWorkItems
        {
            get { return mainForm.ControlWorkItems; }
        }

        public TreeView GlobalListTree
        {
            get { return mainForm.GlobalListTree; }
        }

        void IUIContext.ShowTrayTooltip(string caption, string message, ToolTipIcon tipIcon, IBalloonClickHander balloonClickHander)
        {
            mainForm.ShowTrayTooltip(caption, message, tipIcon, balloonClickHander) ;
        }

        public TreeNode FindNode(TreeView treeView, XmlNode xmlNode)
        {
            return mainForm.FindNode(treeView, xmlNode);
        }

        TreeNode IUIContext.FindNode(TreeNodeCollection nodes, XmlNode xmlNode)
        {
            return mainForm.FindNode(nodes, xmlNode);
        }

        void IUIContext.ProgressBegin(int maximum, int step)
        {
            mainForm.ProgressBegin(maximum, step);
        }

        void IUIContext.ProgressDoStep()
        {
            mainForm.ProgressDoStep();
        }

        void IUIContext.ProgressEnd()
        {
            mainForm.ProgressEnd();
        }

        public void HandleError(Exception exception)
        {
            mainForm.HandleError(exception);
        }

        public void LogMessage(IconListEntry entry)
        {
            mainForm.LogMessage(entry);
        }

        public void LogMessageNewLine()
        {
            mainForm.LogMessageNewLine();
        }

        public Image GetLogImage(LogImage logImage)
        {
            return mainForm.GetLogImage(logImage);
        }

        public void SetMainTabPage(int index)
        {
            mainForm.SetMainTabPage(index);
        }

        public int GetMainTabPage()
        {
            return mainForm.GetMainTabPage();
        }

        public void SetGlobalListSelectedNode(TreeNode node)
        {
            mainForm.SetGlobalListSelectedNode(node);
        }

        public TreeNode GetGlobalListSelectedNode()
        {
            return mainForm.GetGlobalListSelectedNode();
        }

        #endregion
    }
}