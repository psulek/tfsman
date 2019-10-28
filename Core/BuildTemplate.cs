using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using Microsoft.TeamFoundation.Build.Client;

using TFSManager.Core.WinForms;

namespace TFSManager.Core
{
    [Serializable]
    [XmlType("BuildTemplate")]
    public class BuildTemplate
    {
        public BuildTemplate() {}

        public BuildTemplate(IBuildDefinition definition)
        {
            this.DefinitionName = definition.Name;
            this.TeamProject = definition.TeamProject;
            //this.BuildAgentName = definition.DefaultBuildAgent.Name;
            //this.BuildAgentUri = definition.DefaultBuildAgent.Uri.ToString();
            this.DefaultDropLocation = definition.DefaultDropLocation;
            this.RunPriority = QueuePriority.Normal;
        }

        public string TemplateName { get; set; }
        public string Description { get; set; }
        public string DefinitionName { get; set; }
        public string TeamProject { get; set; }
        public string BuildControllerName { get; set; }
        public string BuildControllerUri { get; set; }
        public string DefaultDropLocation { get; set; }
        public string CommandLineArguments { get; set; }
        public bool Postponed { get; set; }
        public QueuePriority RunPriority { get; set; }

        [XmlAttribute("timestamp")]
        public long Timestamp { get; set; }

        public BuildTemplate Clone()
        {
            var result = new BuildTemplate();
            result.TemplateName = this.TemplateName;
            result.Description = this.Description;
            result.DefinitionName = this.DefinitionName;
            result.TeamProject = this.TeamProject;
            result.BuildControllerName = this.BuildControllerName;
            result.BuildControllerUri = this.BuildControllerUri;
            result.DefaultDropLocation = this.DefaultDropLocation;
            result.CommandLineArguments = this.CommandLineArguments;
            result.Postponed = this.Postponed;
            result.RunPriority = this.RunPriority;

            return result;
        }
    }

    [Serializable]
    [XmlType("BuildTemplates")]
    public class BuildTemplateCollection
    {
        private static readonly Type[] types = new[] {typeof(BuildTemplateCollection), typeof(BuildTemplate)};
        private string filename;

        public BuildTemplateCollection()
        {
            this.Templates = new List<BuildTemplate>();
            this.TeamFoundationServerName = Context.TfsServer.Name;
            this.TeamFoundationServerInstanceId = Context.TfsServer.InstanceId;
        }

        [XmlIgnore]
        public string Filename
        {
            get
            {
                return this.filename;
            }
        }

        public string TeamFoundationServerName { get; set; }

        public Guid TeamFoundationServerInstanceId { get; set; }

        public List<BuildTemplate> Templates { get; set; }

        public bool CheckCurrentTFSServer()
        {
            return (this.TeamFoundationServerName == Context.TfsServer.Name &&
                this.TeamFoundationServerInstanceId == Context.TfsServer.InstanceId);
        }

        public static BuildTemplateCollection LoadFrom(string fileName)
        {
            string allText = File.ReadAllText(fileName);
            var collection = Util.DeserializeObjectFromXml(typeof(BuildTemplateCollection), types, allText) as
                BuildTemplateCollection;
            if (collection != null)
            {
                collection.filename = fileName;
            }

            return collection;
        }

        public void SaveToFile(string fileName)
        {
            string xml = Util.SerializeObjectToXml(typeof(BuildTemplateCollection), types, this);
            File.WriteAllText(fileName, xml);
        }

        public void Sort(ListViewSortInfo sortInfo)
        {
            this.Templates.Sort((x, y) =>
            {
                int compared = 0;

                if (sortInfo.Index == 0) // Template Name
                {
                    compared = string.CompareOrdinal(x.TemplateName, y.TemplateName);
                }
                else if (sortInfo.Index == 1) // Definition Name
                {
                    compared = string.CompareOrdinal(x.DefinitionName, y.DefinitionName);
                }
                else if (sortInfo.Index == 2) // Definition Name
                {
                    compared = 0; // string.CompareOrdinal(x.BuildAgent.MachineName, y.BuildAgent.MachineName);
                }
                else if (sortInfo.Index == 3) // computer name
                {
                    //buildAgent != null ? buildAgent.MachineName : string.Empty
                    compared = 0;
                }
                else if (sortInfo.Index == 4) // default drop location
                {
                    compared = string.CompareOrdinal(x.DefaultDropLocation, y.DefaultDropLocation);
                }
                else // CommandLineArguments
                {
                    compared = string.CompareOrdinal(x.CommandLineArguments, y.CommandLineArguments);
                }

                if (sortInfo.Order == SortOrder.Descending)
                {
                    compared = compared * -1;
                }

                if (compared == 0)
                {
                    compared = Comparer<long>.Default.Compare(x.Timestamp, y.Timestamp);
                }

                return compared;
            });
        }
    }
}