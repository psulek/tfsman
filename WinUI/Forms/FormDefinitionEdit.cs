using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Core;
using TFSManager.Core.WinForms;

namespace TFSManager.Forms
{
    public partial class FormDefinitionEdit: Form, IMasterForm
    {
        private IBuildDefinition definition;
        private int lastSelectedPageIdx = -1;
        private FormActionMode mode;
        private UserControl[] pageControls;
        private int totalWarnings = 0;

        public FormDefinitionEdit()
        {
            InitializeComponent();
        }

        private int SelectedPage
        {
            get
            {
                int idx = -1;

                for (int i = 0; i < this.pageList.Items.Count; i++)
                {
                    var item = (ToolStripButton) this.pageList.Items[i];
                    if (item.Checked)
                    {
                        idx = i;
                        break;
                    }
                }

                return idx;
            }
        }

        #region IMasterForm Members

        public void Notify(IChildControl child, params object[] args)
        {
            int pageIdx = GetPageControlIndex(child);
            var button = this.pageList.Items[pageIdx] as ToolStripButton;
            var warning = (bool) args[0];

            bool wasChange;

            if (warning)
            {
                wasChange = (button.Image == null);
                button.Image = this.imageList1.Images[0];
            }
            else
            {
                wasChange = (button.Image != null);
                button.Image = null;
            }

            if (wasChange)
            {
                this.totalWarnings = warning ? this.totalWarnings + 1 : this.totalWarnings - 1;
            }

            this.lbWarningMsg.Visible = (this.totalWarnings > 0);
        }

        #endregion

        private void Initialize()
        {
            this.pageControls = new UserControl[] {this.controlGeneral, this.controlWorkspace, this.controlProjectFile};

            foreach (UserControl pageControl in this.pageControls)
            {
                pageControl.Visible = false;
            }

            this.controlGeneral.InitializeControl(this);
            this.controlGeneral.Initialize(this.definition);

            this.controlWorkspace.InitializeControl(this);
            this.controlWorkspace.Initialize(this.definition);

            this.controlProjectFile.InitializeControl(this);
            this.controlProjectFile.Initialize(this.definition);

            this.btnGeneral.Checked = true;
            this.lastSelectedPageIdx = 0;
            PopulatePage();
        }

        internal List<string> GetServerFolders()
        {
            var result = new List<string>();

            foreach (IWorkspaceMapping mapping in this.definition.Workspace.Mappings)
            {
                result.Add(mapping.ServerItem);
            }

            return result;
        }

        private void PopulatePage()
        {
            foreach (UserControl pageControl in this.pageControls)
            {
                pageControl.Visible = false;
            }

            int pageIdx = SelectedPage;
            this.pageControls[pageIdx].Visible = true;
            this.pageControls[pageIdx].Dock = DockStyle.Fill;
        }

        private void PageList_Click(object sender, EventArgs e)
        {
            if (this.lastSelectedPageIdx > -1)
            {
                (this.pageList.Items[this.lastSelectedPageIdx] as ToolStripButton).Checked = false;
            }

            var button = sender as ToolStripButton;
            int btnIdx = Convert.ToInt32(button.Tag as string);
            button.Checked = true;

            this.lastSelectedPageIdx = btnIdx;
            PopulatePage();
        }

        private int GetPageControlIndex(IChildControl control)
        {
            int result = -1;

            for (int i = 0; i < this.pageControls.Length; i++)
            {
                var pageControl = this.pageControls[i] as IChildControl;

                if (pageControl == control)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        #region DialogShow

        private static FormDefinitionEdit form;

        public static IBuildDefinition DialogShow(IBuildDefinition definition, FormActionMode mode)
        {
            IBuildDefinition result = null;

            if (form == null)
            {
                form = new FormDefinitionEdit();
            }

            if (definition == null)
            {
                definition = new TempBuildDefinition();
            }

            form.definition = definition;
            form.mode = mode;
            form.Initialize();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.mode != FormActionMode.View)
                {
                    result = new TempBuildDefinition();
                    // general
                    result.Name = form.controlGeneral.DefinitionName;
                    result.Description = form.controlGeneral.Description;
                    result.Enabled = !form.controlGeneral.DisableBuildDefinition;
                    // workspace
                }
            }

            return result;
        }

        #endregion
    }
}