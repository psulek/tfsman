using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using TFSManager.Core.WinForms;

namespace TFSManager.Core
{
    public interface IUIContext
    {
        Form MainForm { get; }

        IControlTeamBuilds ControlTeamBuilds { get; }

        IControlTeamBuildFilter ControlTeamBuildFilter { get; }

        IControlWorkItems ControlWorkItems { get; }

        TreeView GlobalListTree { get; }

        void ShowTrayTooltip(string caption, string message, ToolTipIcon tipIcon, IBalloonClickHander balloonClickHander);

        TreeNode FindNode(TreeView treeView, XmlNode xmlNode);

        TreeNode FindNode(TreeNodeCollection nodes, XmlNode xmlNode);

        void ProgressBegin(int maximum, int step);

        void ProgressDoStep();

        void ProgressEnd();

        void HandleError(Exception exception);

        void LogMessage(IconListEntry entry);

        void LogMessageNewLine();

        Image GetLogImage(LogImage logImage);

        void SetMainTabPage(int index);

        int GetMainTabPage();

        void SetGlobalListSelectedNode(TreeNode node);

        TreeNode GetGlobalListSelectedNode();
    }

    public enum LogImage
    {
        Empty,
        Info,
        Warning,
        Error
    }
}