using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

using XPTable.Models;

namespace TFSManager.Controls
{
    public partial class ControlBuildDetailSummary: UserControl
    {
        private readonly string[] itemNames = new[]
                                              {
                                                  "Build name:", "Requested by:", "Team project:", "Definition name:",
                                                  "Agent name:",
                                                  "Command-line arguments:", "Started on:", "Completed on:",
                                                  "Last changed by:",
                                                  "Last changed on:", "Quality:",
                                                  "Work items opened:", "Source control version:", "Log:"
                                              };

        internal int ValueColumnLeftPos = -1;

        public ControlBuildDetailSummary()
        {
            InitializeComponent();
        }

        internal BuildDetailSectionStatus Initialize(IBuildDetail bd)
        {
            var result = new BuildDetailSectionStatus();

            bd.RefreshAllDetails();

            var workItemsOpened = new StringBuilder();
            List<IBuildInformationNode> workItemsOpenedNodes = bd.Information.GetNodesByType("OpenedWorkItem");
            workItemsOpenedNodes.ForEach(node =>
            {
                workItemsOpened.AppendFormat("{0} ({1}/{2}) ; ",
                    node.Fields["WorkItemId"],
                    node.Fields["Status"],
                    node.Fields["AssignedTo"]);
            });

            List<IBuildInformationNode> steps = bd.Information.GetNodesByType("BuildStep");
            IBuildInformationNode buildCompletedNode = steps.Find(node =>
            {
                return node.Fields["Name"] == "BuildCompleted";
            });

            if (buildCompletedNode != null)
            {
                result.Success = (buildCompletedNode.Fields["Status"].ToLower() == "succeeded");
                result.Message = buildCompletedNode.Fields["Message"];
            }
            else
            {
                result.Success = false;
                result.Message = string.Empty;
            }


            // build name link label
            var control_BuildName = new LinkLabel();
            control_BuildName.BackColor = Color.Transparent;
            control_BuildName.Text = bd.BuildNumber;
            control_BuildName.AutoSize = true;
            control_BuildName.Tag = bd.DropLocation;
            control_BuildName.Click += BuildName_Click;

            // log file link label
            var control_Log = new LinkLabel();
            control_Log.BackColor = Color.Transparent;
            control_Log.Text = bd.LogLocation;
            control_Log.AutoSize = true;
            control_Log.Click += LogFile_Click;

            var itemValues = new List<object>
                             {
                                 control_BuildName, bd.RequestedBy, bd.BuildDefinition.TeamProject,
                                 bd.BuildDefinition.Name, 
                                 string.Empty, //bd.BuildAgent.Name, 
                                 string.Empty, //bd.CommandLineArguments,
                                 bd.StartTime.ToString(), bd.FinishTime.ToString(), bd.LastChangedBy,
                                 bd.LastChangedOn.ToString(), bd.Quality,
                                 workItemsOpened.ToString(), bd.SourceGetVersion, control_Log
                             };

            this.lvItems.BeginUpdate();
            try
            {
                this.lvItems.Controls.Clear();
                this.table.Rows.Clear();
                for (int i = 0; i < this.itemNames.Length; i++)
                {
                    string itemName = this.itemNames[i];
                    var itemValue = (itemValues[i] is string ? itemValues[i] : string.Empty) as string;

                    var newRow = new Row();
                    newRow.Cells.Add(new Cell(itemName));
                    var cell = new Cell(itemValue);
                    newRow.Cells.Add(cell);
                    this.table.Rows.Add(newRow);

                    if (itemValues[i] is Control)
                    {
                        Rectangle cellRect = this.lvItems.CellRect(cell);
                        var control = itemValues[i] as Control;
                        this.lvItems.Controls.Add(control);
                        control.Location = new Point(cellRect.X, cellRect.Y - 1);
                        control.BringToFront();
                    }
                }
            }
            finally
            {
                this.lvItems.EndUpdate();
                Rectangle rectangle = this.lvItems.ColumnRect(1);
                this.ValueColumnLeftPos = rectangle.Left + 14;
            }

            #region debug

            //                        Debug.WriteLine(new string('-', 120));
            //                        foreach (var node in bd.Information.Nodes)
            //                        {
            //                            Debug.WriteLine(string.Format("Type: {0}", node.Type));
            //                            foreach (var field in node.Fields)
            //                            {
            //                                Debug.WriteLine(string.Format("  Field: {0} | Value: {1}", field.Key, field.Value));
            //                            }
            //                            Debug.WriteLine(new string('=', 120));
            //                        }

            #endregion

            return result;
        }

        private void LogFile_Click(object sender, EventArgs e)
        {
            var label = sender as LinkLabel;

            bool fileExists = !string.IsNullOrEmpty(label.Text) && File.Exists(label.Text);

            if (fileExists)
            {
                Process.Start("notepad", label.Text);
            }
            else
            {
                MessageBox.Show(string.Format("Specified log file '{0}' does not exists!", label.Text), "Show log file",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void BuildName_Click(object sender, EventArgs args)
        {
            var label = sender as LinkLabel;
            var dropLocation = label.Tag as string;

            bool exists = !string.IsNullOrEmpty(dropLocation) && Directory.Exists(dropLocation);

            if (exists)
            {
                Process.Start(dropLocation, "open");
            }
            else
            {
                MessageBox.Show(string.Format("Specified directory '{0}' does not exists!", dropLocation), "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}