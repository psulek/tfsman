using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ICSharpCode.TextEditor;

using TFSManager.Components;
using TFSManager.Core;

namespace TFSManager.Controls
{
    public partial class ControlEditor : UserControl
    {
        private FindAndReplaceForm findForm;
        private int foundIndex;
        private string foundWord;

        public ControlEditor()
        {
            InitializeComponent();
        }

        private void xmlTextEditor1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.F)
                {
                    ExecuteFind(false);
                }
                else if (e.KeyCode == Keys.H)
                {
                    ExecuteFind(true);
                }
            }
        }

        private void ExecuteFind(bool replaceMode) 
        {
            if (this.findForm == null)
            {
                this.findForm = new FindAndReplaceForm();
                this.findForm.Owner = this.ParentForm;
            }
            TextEditorControl editor = ActiveEditor;
            if (editor == null) return;
            findForm.ShowFor(editor, replaceMode);
        }

        /// <summary>Returns the currently displayed editor, or null if none are open</summary>
        private TextEditorControl ActiveEditor
        {
            get
            {
                return this.textEditor;
            }
        }

        public string EditorText
        {
            get
            {
                return ActiveEditor.Text;
            }
            set
            {
                ActiveEditor.Text = value;
            }
        }

        private void ctxMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mniRedo.Enabled = this.textEditor.CanRedo();
            mniUndo.Enabled = this.textEditor.CanUndo();
            mniCut.Enabled = this.textEditor.CanCut();
            mniCopy.Enabled = this.textEditor.CanCopy();
            mniPaste.Enabled = this.textEditor.CanPaste();
            mniClear.Enabled = this.textEditor.Text.Length > 0;
            mniSelectAll.Enabled = this.textEditor.CanSelectAll();
        }

        private void TextEditorContextMenu_Click(object sender, EventArgs e)
        {
            string actionstr = (sender as ToolStripItem).Tag as string;
            EditorContextMenuAction action = (EditorContextMenuAction) Convert.ToInt32(actionstr);
            switch (action)
            {
                case EditorContextMenuAction.Undo:
                    this.textEditor.Undo();
                    break;
                case EditorContextMenuAction.Redo:
                    this.textEditor.Redo();
                    break;
                case EditorContextMenuAction.Cut:
                    this.textEditor.Cut();
                    break;
                case EditorContextMenuAction.Copy:
                    textEditor.Copy();
                    break;
                case EditorContextMenuAction.Paste:
                    textEditor.Paste();
                    break;
                case EditorContextMenuAction.Clear:
                    textEditor.Text = string.Empty;
                textEditor.Refresh();
                    break;
                case EditorContextMenuAction.Find:
                    ExecuteFind(false);
                    break;
                case EditorContextMenuAction.Replace:
                    ExecuteFind(true);
                    break;
                case EditorContextMenuAction.SelectAll:
                    textEditor.SelectAll();
                    break;
            }
        }

        public enum EditorContextMenuAction
        {
            Undo = 0,
            Redo,
            Cut,
            Copy,
            Paste,
            Clear,
            Find,
            Replace,
            SelectAll
        }
    }
}
