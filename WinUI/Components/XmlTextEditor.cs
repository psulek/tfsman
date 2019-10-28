using System;
using System.Text;

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor.Addons;

using System.Drawing;

using ICSharpCode.TextEditor.Actions;

using TFSManager.Core;

namespace TFSManager.Components
{
	class XmlTextEditor : TextEditorControl
	{
		// Methods
		public XmlTextEditor()
		{
			base.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
			base.Document.FoldingManager.FoldingStrategy = new XmlFoldingStrategy();
			base.Document.FormattingStrategy = new XmlFormattingStrategy();
			base.TextEditorProperties = this.InitializeProperties();
			base.Document.DocumentChanged += new DocumentEventHandler(this.Document_DocumentChanged);
		}

        public void SetHighlighting(string mode)
        {
            IHighlightingStrategy strategy = HighlightingStrategyFactory.CreateHighlightingStrategy(mode);
            //IHighlightingStrategy strategy = HighlightingManager.Manager.FindHighlighter(mode);
            Document.HighlightingStrategy = strategy;
        }

	    public bool CanCopy()
		{
			return base.TextArea.SelectionManager.HasSomethingSelected;
		}

		public bool CanCut()
		{
			return base.TextArea.SelectionManager.HasSomethingSelected;
		}

		public bool CanDelete()
		{
			return this.CanCopy();
		}

		public bool CanFormatXaml()
		{
			return this.CanSelectAll();
		}

		public bool CanPaste()
		{
			return base.TextArea.ClipboardHandler.EnablePaste;
		}

		public bool CanRedo()
		{
			return base.Document.UndoStack.CanRedo;
		}

		public bool CanSelectAll()
		{
			if (base.Document.TextContent == null) return false;
			if (base.Document.TextContent.Trim().Equals(String.Empty)) return false;
			return true;
		}

		public bool CanUndo()
		{
			return base.Document.UndoStack.CanUndo;
		}

		public void Copy()
		{
			new Copy().Execute(base.TextArea);
			base.TextArea.Focus();
		}

		public void Cut()
		{
			new Cut().Execute(base.TextArea);
			base.TextArea.Focus();
		}

		public void Delete()
		{
			new Delete().Execute(base.TextArea);
			base.TextArea.Focus();
		}

		private void Document_DocumentChanged(object sender, DocumentEventArgs e)
		{
			this.UpdateFoldings();
		}

        public void FormatXaml()
        {
            string xmlText = base.Document.TextContent.Trim();
            xmlText = xmlText.Replace("\r\n", "");
            string formatXml = XmlPrettyFormatter.Format(xmlText);
            Document.TextContent = formatXml;


            FormatBuffer buffer = new FormatBuffer();
            buffer.Execute(base.TextArea);

            base.TextArea.Focus();
        }

	    private ITextEditorProperties InitializeProperties()
		{
			DefaultTextEditorProperties properties = new DefaultTextEditorProperties();
			properties.Font = new Font(FontFamily.GenericMonospace.Name, 10);
			properties.IndentStyle = IndentStyle.Auto;
			properties.ShowSpaces = false;
			properties.LineTerminator = "\n";
			properties.ShowTabs = false;
			properties.ShowInvalidLines = false;
			properties.ShowEOLMarker = false;
			properties.UseAntiAliasedFont = true;
			properties.TabIndent = 3;
			properties.CutCopyWholeLine = true;
			properties.LineViewerStyle = LineViewerStyle.None;
			properties.MouseWheelScrollDown = true;
			properties.MouseWheelTextZoom = true;
			properties.AllowCaretBeyondEOL = false;
			properties.AutoInsertCurlyBracket = true;
			properties.BracketMatchingStyle = BracketMatchingStyle.After;
			properties.ConvertTabsToSpaces = false;
			properties.ShowMatchingBracket = true;
			properties.EnableFolding = true;
			properties.ShowVerticalRuler = false;
			properties.IsIconBarVisible = false;
			properties.Encoding = Encoding.Unicode;
			return properties;
		}

		public void Paste()
		{
			new Paste().Execute(base.TextArea);
			base.TextArea.Focus();
		}

		public void SelectAll()
		{
			new SelectWholeDocument().Execute(base.TextArea);
			base.TextArea.Focus();
		}

		public void SelectText(int start, int length)
		{
			int textLength = base.Document.TextLength;
			if (textLength < (start + length))
			{
				length = (textLength - 1) - start;
			}
			base.TextArea.Caret.Position = base.Document.OffsetToPosition(start + length);
			base.TextArea.SelectionManager.ClearSelection();
			base.TextArea.SelectionManager.SetSelection(new DefaultSelection(base.Document, base.Document.OffsetToPosition(start), base.Document.OffsetToPosition(start + length)));
			base.Refresh();
		}

		public void UpdateFoldings()
		{
			base.Document.FoldingManager.UpdateFoldings(string.Empty, null);
			base.TextArea.Refresh(base.TextArea.FoldMargin);
		}
	}


}
