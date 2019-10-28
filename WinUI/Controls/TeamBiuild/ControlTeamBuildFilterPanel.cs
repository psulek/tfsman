using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Server;

using TFSManager.Core;
using TFSManager.Core.WinForms;
using TFSManager.Core.WinForms.Controls;

namespace TFSManager.Controls.TeamBiuild
{
    public partial class ControlTeamBuildFilterPanel : UserControl, IControlTeamBuildFilter
    {
        #region class TeamProjectEntry

        public class TeamProjectEntry
        {
            public ProjectInfo Project { get; set; }

            public bool Checked { get; set; }
        }

        #endregion class TeamProjectEntry

        #region fields

        internal ControlTeamBuilds parentControl;
        private bool allowedAutoApply = true;
        private readonly Dictionary<string, XPLinkLabel> items = new Dictionary<string, XPLinkLabel>(StringComparer.OrdinalIgnoreCase);
        private string[] lastAppliedFilter = new string[0];
        private string lastAppliedFilterHashCode =  string.Empty;

        #endregion fields

        public ControlTeamBuildFilterPanel()
        {
            InitializeComponent();
        }

        private Action<string[]> OnApplyFilter;

        public void Initialize(ControlTeamBuilds parentControl, Action<string[]> onApplyFilter)
        {
            this.parentControl = parentControl;
            this.OnApplyFilter = onApplyFilter;

            layoutPanel.Controls.Clear();
            Enabled = Context.IsConnected;
            if (!Context.IsConnected)
            {
                return;
            }

            Dictionary<string, ProjectInfo> allProjects = Context.GetSortedProjects();
            foreach (var pair in allProjects)
            {
                string projectName = pair.Key;
                XPLinkLabel label = new XPLinkLabel {Text = projectName};
                label.Tag = new TeamProjectEntry { Project = pair.Value, Checked = false };
                items.Add(projectName, label);

                label.ColorNormal = SystemColors.ControlDark;
                label.ColorHover = SystemColors.HotTrack;
                label.FontNormal = new Font(label.FontNormal, FontStyle.Regular);
                label.FontHover = new Font(label.FontHover, FontStyle.Underline);
                label.TransparentBackground = false;
                //label.BorderStyle = BorderStyle.FixedSingle;
                //label.AutoSize = true;
                label.Size = new Size(130, label.Size.Height);
                label.Click += LabelOnClick;
                layoutPanel.Controls.Add(label);

                linkToolTip.SetToolTip(label, string.Format("Click to include team project '{0}' into filter", projectName));
            }
        }

        private void LabelOnClick(object sender, EventArgs eventArgs)
        {
            XPLinkLabel label = sender as XPLinkLabel;
            TeamProjectEntry entry = label.Tag as TeamProjectEntry;
            InternalCheckItem(label, !entry.Checked);

            if (this.chAutoApply.Checked && allowedAutoApply)
            {
                ApplyFilter();
            }
        }

        private void InternalCheckItem(XPLinkLabel label, bool @checked) 
        {
            TeamProjectEntry entry = label.Tag as TeamProjectEntry;
            entry.Checked = @checked;

            this.linkToolTip.SetToolTip(label, string.Format("Click to {0} team project '{1}' {2} filter", 
                entry.Checked ? "exclude" : "include", 
                label.Text,
                entry.Checked ? "from" : "into"));

            label.BackColor = entry.Checked ? SystemColors.ControlLight : SystemColors.Control;
            label.ColorNormal = entry.Checked ? SystemColors.Highlight : SystemColors.ControlDark;
        }

        private void linkAutoApply_Click(object sender, EventArgs e)
        {
            this.chAutoApply.Checked = !this.chAutoApply.Checked;
        }

        private void linkSelectItems(object sender, EventArgs e)
        {
            string action = (sender as XPLinkLabel).Tag as string;

            allowedAutoApply = false;

            try
            {
                bool selectAll = action == "0";
                foreach (var item in items)
                {
                    InternalCheckItem(item.Value, selectAll);
                }
            }
            finally
            {
                allowedAutoApply = true;
            }

            ApplyFilter();
        }

        #region Implementation of IControlTeamBuildFilter

        public string[] CheckedProjects
        {
            get
            {
                return (from item in this.items
                        let entry = item.Value.Tag as TeamProjectEntry
                        where entry.Checked
                        select item.Key).ToArray();
            }
        }

        public string LastAppliedFilterHashCode
        {
            get { return lastAppliedFilterHashCode; }
        }

        public void CheckProject(string teamProject, bool @checked)
        {
            if (this.items.ContainsKey(teamProject))
            {
                this.allowedAutoApply = false;
                try
                {
                    XPLinkLabel label = this.items[teamProject];
                    InternalCheckItem(label, @checked);
                }
                finally
                {
                    allowedAutoApply = true;
                }
            }
        }

        public void CheckAllProjects()
        {
            foreach (var item in items)
            {
                InternalCheckItem(item.Value, true);
            }
        }

        public void ClearFilter()
        {
            allowedAutoApply = false;

            try
            {
                foreach (var item in items)
                {
                    InternalCheckItem(item.Value, false);
                }
            }
            finally
            {
                allowedAutoApply = true;
            }
        }

        public void ApplyFilter()
        {
            if (OnApplyFilter != null)
            {
                bool savedallowedAutoApply = allowedAutoApply;

                allowedAutoApply = true;
                try
                {
                    OnApplyFilter(CheckedProjects);
                    this.lastAppliedFilter = this.CheckedProjects;

                    int[] hasCodes = (from proj in this.CheckedProjects
                                                   let hshCode = proj.GetHashCode()
                                                   select hshCode).ToArray();

                    this.lastAppliedFilterHashCode = Util.JoinCollection(hasCodes, "-");
                        //this.CheckedProjects.Sum(item => item.GetHashCode());
                }
                catch (Exception e)
                {
                    UIContext.Instance.HandleError(e);
                }
                finally
                {
                    this.allowedAutoApply = savedallowedAutoApply;
                }
            }
        }

        public bool IsCheckedProject(string teamProject)
        {
            bool result = false;

            foreach (var item in items)
            {
                TeamProjectEntry entry = item.Value.Tag as TeamProjectEntry;
                if (item.Key == teamProject)
                {
                    result = entry.Checked;
                }
            }

            return result;
        }

        #endregion

        private void chAutoApply_CheckedChanged(object sender, EventArgs e)
        {
            if (chAutoApply.Checked)
            {
                IEnumerable<string> enumerable = this.CheckedProjects.Except(this.lastAppliedFilter);
                if (enumerable.Count() > 0)
                {
                    ApplyFilter();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}
