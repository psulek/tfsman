using System.Drawing;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

namespace TFSManager.Controls
{
    public partial class ControlBuildDetailPanel: UserControl
    {
        private readonly ControlBuildDetailBuildSteps controlBuildSteps = new ControlBuildDetailBuildSteps();
        private readonly ControlBuildDetailSummary controlSummary = new ControlBuildDetailSummary();
        private readonly LinkLabel[] sectionIcons = new LinkLabel[2];

        public ControlBuildDetailPanel()
        {
            InitializeComponent();

            this.sectionIcons[0] = CreateSectionIcon();
            this.sectionIcons[1] = CreateSectionIcon();

            var section_summary = new CollapsibleControlSection("Summary", this.controlSummary, this.sectionIcons[0]);
            this.collapsibleControl1.AddSection(section_summary);

            var section_buildSteps = new CollapsibleControlSection("Build steps", this.controlBuildSteps,
                this.sectionIcons[1]);
            this.collapsibleControl1.AddSection(section_buildSteps);
        }

        private LinkLabel CreateSectionIcon()
        {
            var icon = new LinkLabel();
            icon.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            icon.BackColor = Color.Transparent;
            icon.ImageAlign = ContentAlignment.MiddleLeft;
            //icon.ImageIndex = success ? 1 : 0;
            icon.ImageList = this.imageList;
            icon.LinkArea = new LinkArea(0, 0);
            icon.LinkBehavior = LinkBehavior.NeverUnderline;
            icon.LinkColor = SystemColors.ControlText;
            icon.Location = new Point(300, 1);
            icon.Name = "sectionIcon";
            icon.Padding = new Padding(20, 0, 0, 0);
            icon.Size = new Size(169, 17);
            icon.TabIndex = 1;
            //icon.Text = message;
            icon.TextAlign = ContentAlignment.MiddleLeft;
            return icon;
        }

        private void UpdateSectionIcon(LinkLabel icon, BuildDetailSectionStatus status)
        {
            icon.ImageIndex = status.Success ? 1 : 0;
            icon.Text = status.Message;
        }

        internal void Initialize(IBuildDetail bd)
        {
            var statuses = new BuildDetailSectionStatus[2];
            statuses[0] = this.controlSummary.Initialize(bd);
            statuses[1] = this.controlBuildSteps.Initialize(bd, this.imageList);

            for (int i = 0; i < this.sectionIcons.Length; i++)
            {
                LinkLabel sectionIcon = this.sectionIcons[i];
                BuildDetailSectionStatus sectionStatus = statuses[i];

                sectionIcon.Left = this.controlSummary.ValueColumnLeftPos;
                UpdateSectionIcon(sectionIcon, sectionStatus);
            }
        }
    }

    #region struct BuildDetailSectionStatus

    public struct BuildDetailSectionStatus
    {
        public string Message;
        public bool Success;

        public BuildDetailSectionStatus(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }

    #endregion struct BuildDetailSectionStatus}
}