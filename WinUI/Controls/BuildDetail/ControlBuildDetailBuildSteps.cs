using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

using XPTable.Models;

namespace TFSManager.Controls
{
    public partial class ControlBuildDetailBuildSteps: UserControl
    {
        private int buildStepSizeDelta = 0;

        private ImageList imageList;
        private int initPanelWidth = 0;
        private int lastFormWidth = 0;

        public ControlBuildDetailBuildSteps()
        {
            InitializeComponent();

            HScroll = true;
            //            initColumnWidth = columnBuildStep.Width;
            //            buildStepSizeDelta = lvItems.Width - columnBuildStep.Width;
        }

        internal BuildDetailSectionStatus Initialize(IBuildDetail bd, ImageList imageList)
        {
            var result = new BuildDetailSectionStatus();

            this.imageList = imageList;

            bd.RefreshAllDetails();
            List<IBuildInformationNode> stepsNodes = BuildStepsNodes(bd);

            int successedCount = 0;

            this.lvItems.BeginUpdate();
            try
            {
                this.lvItems.Controls.Clear();
                this.table.Rows.Clear();
                stepsNodes.ForEach(node =>
                {
                    var newRow = new Row();
                    //newRow.Height = 20;

                    // icon cell
                    var iconCell = new Cell();
                    newRow.Cells.Add(iconCell);

                    // Build step message cell
                    string message = node.Fields["Message"];
                    var messageCell = new Cell(message);
                    newRow.Cells.Add(messageCell);

                    // Completed On cell
                    string finishTime = node.Fields["FinishTime"];
                    DateTime completedOn = DateTime.Parse(finishTime);
                    var completedOnCell = new Cell(completedOn.ToString());
                    newRow.Cells.Add(completedOnCell);

                    this.table.Rows.Add(newRow);

                    // icon cell image
                    string status = node.Fields["Status"];
                    bool successed = status.ToLower() == "succeeded";
                    LinkLabel iconControl = CreateIcon(successed);
                    this.lvItems.Controls.Add(iconControl);
                    Rectangle iconCellRect = this.lvItems.CellRect(iconCell);
                    iconControl.Location = new Point(iconCellRect.X, iconCellRect.Y + 1);
                    iconControl.BringToFront();

                    if (successed)
                    {
                        successedCount++;
                    }
                });

                result.Success = successedCount == stepsNodes.Count;
                result.Message = string.Format("{0} succeeded, {1} failed", successedCount,
                    stepsNodes.Count - successedCount);
            }
            finally
            {
                this.lvItems.EndUpdate();
            }

            return result;
        }

        private List<IBuildInformationNode> BuildStepsNodes(IBuildDetail bd)
        {
            var result = new List<IBuildInformationNode>();
            List<IBuildInformationNode> nodes = bd.Information.GetNodesByType("BuildStep");
            nodes.ForEach(node =>
            {
                result.Add(node);

                var childNodes = new List<IBuildInformationNode>();

                string status = node.Fields["Status"];
                bool successed = status.ToLower() == "succeeded";
                if (!successed)
                {
                    RecurseStepsNode(node, childNodes, 0);
                    result.AddRange(childNodes);
                }
            });

            return result;
        }

        private void RecurseStepsNode(IBuildInformationNode node, List<IBuildInformationNode> result, int level)
        {
            foreach (IBuildInformationNode childNode in node.Children.Nodes)
            {
                string status = childNode.Fields["Status"];
                bool successed = status.ToLower() == "succeeded";
                //if (!successed || (level <= 1))
                {
                    result.Add(childNode);
                    RecurseStepsNode(childNode, result, level + 1);
                }
            }
        }

        private LinkLabel CreateIcon(bool success)
        {
            var icon = new LinkLabel();
            icon.AutoSize = false;
            icon.Size = new Size(18, 16);
            icon.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            icon.BackColor = Color.Transparent;
            icon.ImageAlign = ContentAlignment.MiddleLeft;
            icon.ImageIndex = success ? 1 : 0;
            icon.ImageList = this.imageList;
            icon.LinkArea = new LinkArea(0, 0);
            icon.LinkBehavior = LinkBehavior.NeverUnderline;
            icon.Text = string.Empty;

            return icon;
        }

        private void lvItems_Resize(object sender, EventArgs e)
        {
            ReflectResize();
        }

        private void ReflectResize()
        {
            if (this.buildStepSizeDelta == 0)
            {
                return;
            }

            int newDelta = this.lvItems.Width - this.columnBuildStep.Width;

            if (newDelta > this.buildStepSizeDelta)
            {
                //if (this.Width <= initPanelWidth) return;

                this.columnBuildStep.Width = this.columnBuildStep.Width + (newDelta - this.buildStepSizeDelta);
            }
            else if (newDelta < this.buildStepSizeDelta)
            {
                this.columnBuildStep.Width = this.columnBuildStep.Width - (this.buildStepSizeDelta - newDelta);
            }


            //            int newDelta = panel1.Width - lvItems.Width;
            //            this.columnBuildStep.Width = initColumnWidth + newDelta;
        }

        private void ControlBuildDetailBuildSteps_Resize(object sender, EventArgs e)
        {
            //            int newDelta = Math.Abs(this.Width - panel1.Width);
            //
            //            if (newDelta < this.initPanelWidth)
            //            {
            //                panel1.Width = panel1.Width - (this.initPanelWidth - newDelta);
            //            }

            int newDelta = (Width - this.lastFormWidth);
            if (newDelta < 0)
            {
                this.panel1.Width = this.panel1.Width - Math.Abs(newDelta);

                if (this.panel1.Width < this.initPanelWidth)
                {
                    this.panel1.Width = this.initPanelWidth;
                }
            }

            this.lastFormWidth = Width;
        }

        private void ControlBuildDetailBuildSteps_Load(object sender, EventArgs e)
        {
            this.lastFormWidth = Width;
            this.initPanelWidth = this.panel1.Width;

            //this.columnBuildStep.Width = (this.lvItems.Width - this.columnIcon.Width - this.columnCompletedOn.Width);
            this.buildStepSizeDelta = this.lvItems.Width - this.columnBuildStep.Width + 60;
            this.columnBuildStep.Width = this.columnBuildStep.Width - 20;

            //ReflectResize();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            //            if (panel1.Width - this.initPanelWidth > 0)
            //            {
            //                panelDelta = panel1.Width - this.initPanelWidth;
            //            }
        }
    }
}