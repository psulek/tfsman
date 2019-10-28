using System;
using System.Linq;
using System.Xml.Linq;

namespace TFSManager.Core
{
    public class BuildProcessParameters
    {
        private const string xmlTemplate = @"<Dictionary x:TypeArguments='x:String, x:Object' xmlns='clr-namespace:System.Collections.Generic;assembly=mscorlib' xmlns:mtbw='clr-namespace:Microsoft.TeamFoundation.Build.Workflow;assembly=Microsoft.TeamFoundation.Build.Workflow' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>
  <x:String x:Key='ConfigurationFolderPath'>{0}</x:String>
  <x:String x:Key='MSBuildArguments' xml:space='preserve'>{1}</x:String>
  <x:Boolean x:Key='LogFilePerProject'>{2}</x:Boolean>
  <mtbw:BuildVerbosity x:Key='Verbosity'>{3}</mtbw:BuildVerbosity>
</Dictionary>";

        public string ConfigurationFolderPath { get; set; }
        public string MSBuildArguments { get; set; }

        public bool LogFilePerProject { get; set; }

        public BuildVerbosity Verbosity { get; set; }

        public static BuildProcessParameters FromXml(string xml)
        {
            XDocument document = XDocument.Parse(xml);

//            foreach (var element in document.Elements())
//            {
//                var localName = element.Name.LocalName;
//            }

            
            XElement elDictionary = document.Elements().Single(element => element.Name.LocalName == "Dictionary");
            XElement buildSettings = elDictionary.Elements().Single(element => element.Name.LocalName == "BuildSettings");
            string projectsToBuild = buildSettings.Attribute("ProjectsToBuild").Value;
            XElement elConfigFolder = elDictionary.Elements().Single(element => element.Attributes().Any(attr => attr.Value == "ConfigurationFolderPath"));
            XElement elArgs = elDictionary.Elements().SingleOrDefault(element => element.Attributes().Any(attr => attr.Value == "MSBuildArguments"));
            XElement elLogPerProj = elDictionary.Elements().SingleOrDefault(element => element.Attributes().Any(attr => attr.Value == "LogFilePerProject"));
            XElement elVerbosity = elDictionary.Elements().SingleOrDefault(element => element.Attributes().Any(attr => attr.Value == "Verbosity"));

            BuildProcessParameters result = new BuildProcessParameters();
            result.ConfigurationFolderPath = elConfigFolder.Value;
            result.MSBuildArguments = elArgs != null ? elArgs.Value : string.Empty;
            result.LogFilePerProject = elLogPerProj != null && elLogPerProj.Value.ToString().ToUpper() == "TRUE";
            if (elVerbosity != null)
            {
                result.Verbosity = (BuildVerbosity)Enum.Parse(typeof (BuildVerbosity), elVerbosity.Value, true);
            }

            return result;
        }

        public string SaveToXml()
        {
            return string.Format(xmlTemplate, this.ConfigurationFolderPath, this.MSBuildArguments,
                                 this.LogFilePerProject ? "True" : "False", Verbosity);
        }
    }

    public enum BuildVerbosity
    {
        Minimal,
        Normal,
        Detailed,
        Diagnostic
    }
}