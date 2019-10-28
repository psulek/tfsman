using System;
using System.Collections.Generic;

using Microsoft.TeamFoundation.Build.Client;

namespace TFSManager.Core
{
    public class TempBuildDefinition: IBuildDefinition
    {
        public TempBuildDefinition() {}

        public TempBuildDefinition(IBuildDefinition source)
        {
            AssingTo(source, this);
        }

        #region Implementation of IBuildGroupItem

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public Uri Uri { get; private set; }
        public string Name { get; set; }
        public string TeamProject { get; internal set; }
        public string FullPath { get; private set; }

        #endregion

        #region Implementation of IBuildDefinition

        public IRetentionPolicy AddRetentionPolicy(BuildReason reason, BuildStatus status, int numberToKeep,
                                                   DeleteOptions deleteOptions)
        {
            throw new NotImplementedException();
        }

        public ISchedule AddSchedule()
        {
            throw new NotImplementedException();
        }

        public IBuildRequest CreateBuildRequest()
        {
            throw new NotImplementedException();
        }

        public IBuildDetail CreateManualBuild(string buildNumber)
        {
            throw new NotImplementedException();
        }

        public IBuildDetail CreateManualBuild(string buildNumber, string dropLocation)
        {
            throw new NotImplementedException();
        }

        public IBuildDetail CreateManualBuild(string buildNumber, string dropLocation, BuildStatus buildStatus,
                                              IBuildController controller, string requestedFor)
        {
            throw new NotImplementedException();
        }

        [Obsolete("This method has been deprecated. Please remove all references.", true)]
        public IProjectFile CreateProjectFile()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IBuildDefinitionSpec CreateSpec()
        {
            throw new NotImplementedException();
        }

        public IBuildDetail[] QueryBuilds()
        {
            throw new NotImplementedException();
        }

        public IBuildController BuildController { get; set; }
        public Uri BuildControllerUri { get; private set; }
        public string ConfigurationFolderPath { get; set; }
        public string Description { get; set; }
        public string DefaultDropLocation { get; set; }
        public IBuildAgent DefaultBuildAgent { get; set; }
        public Uri DefaultBuildAgentUri { get; private set; }
        public bool Enabled { get; set; }
        public string Id { get; private set; }
        public Dictionary<BuildStatus, IRetentionPolicy> RetentionPolicies { get; private set; }
        public List<IRetentionPolicy> RetentionPolicyList { get; private set; }
        public List<ISchedule> Schedules { get; private set; }
        public IWorkspaceTemplate Workspace { get; private set; }
        public Uri LastBuildUri { get; private set; }
        public Uri LastGoodBuildUri { get; private set; }
        public string LastGoodBuildLabel { get; private set; }
        public IProcessTemplate Process { get; set; }
        public string ProcessParameters { get; set; }
        public ContinuousIntegrationType ContinuousIntegrationType { get; set; }
        public int ContinuousIntegrationQuietPeriod { get; set; }
        public IBuildServer BuildServer { get; private set; }

        #endregion

        public void AssingTo(IBuildDefinition targetDefinition)
        {
            AssingTo(this, targetDefinition);
        }

        public static void AssingTo(IBuildDefinition sourceDefinition, IBuildDefinition targetDefinition)
        {
            //targetDefinition.ConfigurationFolderPath = sourceDefinition.ConfigurationFolderPath;
            targetDefinition.ContinuousIntegrationQuietPeriod = sourceDefinition.ContinuousIntegrationQuietPeriod;
            targetDefinition.ContinuousIntegrationType = sourceDefinition.ContinuousIntegrationType;
            //targetDefinition.DefaultBuildAgent = sourceDefinition.DefaultBuildAgent;
            targetDefinition.DefaultDropLocation = sourceDefinition.DefaultDropLocation;
            targetDefinition.Description = sourceDefinition.Description;
            targetDefinition.Enabled = sourceDefinition.Enabled;
            targetDefinition.Name = sourceDefinition.Name;

//            targetDefinition.RetentionPolicies.Clear();
//            foreach (var policy in sourceDefinition.RetentionPolicies)
//            {
//                targetDefinition.RetentionPolicies.Add(policy.Key, policy.Value);
//            }

            targetDefinition.Schedules.Clear();
            sourceDefinition.Schedules.ForEach(schedule => targetDefinition.Schedules.Add(schedule));

            targetDefinition.Workspace.Mappings.Clear();
            sourceDefinition.Workspace.Mappings.ForEach(mapping => targetDefinition.Workspace.Mappings.Add(mapping));
        }

        public static bool IsEqual(IBuildDefinition def1, IBuildDefinition def2)
        {
            return ((def1.BuildServer.TeamFoundationServer == def2.BuildServer.TeamFoundationServer) &&
                (def1.BuildServer.BuildServerVersion == def2.BuildServer.BuildServerVersion) &&
                    //(def1.ConfigurationFolderPath == def2.ConfigurationFolderPath) &&
                        (def1.ContinuousIntegrationQuietPeriod == def2.ContinuousIntegrationQuietPeriod) &&
                            (def1.ContinuousIntegrationType == def2.ContinuousIntegrationType) &&
                                //TempBuildAgent.IsEqual(def1.DefaultBuildAgent, def2.DefaultBuildAgent) &&
                                    (def1.DefaultDropLocation == def2.DefaultDropLocation) &&
                                        (def1.Description == def2.Description) &&
                                            (def1.Enabled == def2.Enabled) &&
                                                (def1.FullPath == def2.FullPath) &&
                                                    (def1.Name == def2.Name) &&
                                                        //IsEqualRetentionPolicies(def1.RetentionPolicies, def2.RetentionPolicies) &&
                                                                IsEqualSchedules(def1.Schedules, def2.Schedules) &&
                                                                    (def1.TeamProject == def2.TeamProject) &&
                                                                        IsEqualWorkspace(def1.Workspace, def2.Workspace));
        }

        private static bool IsEqualWorkspace(IWorkspaceTemplate workspace1, IWorkspaceTemplate workspace2)
        {
            if (workspace1.Mappings.Count != workspace2.Mappings.Count)
            {
                return false;
            }

            bool result = true;

            foreach (IWorkspaceMapping workspaceMapping1 in workspace1.Mappings)
            {
                result = workspace2.Mappings.Find(workspaceMapping2 =>
                {
                    return ((workspaceMapping2.Depth == workspaceMapping1.Depth) &&
                        (workspaceMapping2.LocalItem == workspaceMapping1.LocalItem) &&
                            (workspaceMapping2.MappingType == workspaceMapping1.MappingType) &&
                                (workspaceMapping2.ServerItem == workspaceMapping1.ServerItem));
                }) != null;

                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        private static bool IsEqualSchedules(List<ISchedule> schedules1, List<ISchedule> schedules2)
        {
            if (schedules1.Count != schedules2.Count)
            {
                return false;
            }

            bool result = true;

            foreach (ISchedule schedule1 in schedules1)
            {
                result = schedules2.Find(schedule2 =>
                {
                    return ((schedule2.DaysToBuild == schedule1.DaysToBuild) &&
                        (schedule2.StartTime == schedule1.StartTime) &&
                            (schedule2.Type == schedule1.Type));
                }) != null;

                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        private static bool IsEqualRetentionPolicies(Dictionary<BuildStatus, IRetentionPolicy> policies1,
            Dictionary<BuildStatus, IRetentionPolicy> policies2)
        {
            if (policies1.Count != policies2.Count)
            {
                return false;
            }

            bool result = true;

            foreach (var policy1 in policies1)
            {
                foreach (var policy2 in policies2)
                {
                    result = ((policy1.Key == policy2.Key) &&
                        (policy1.Value.NumberToKeep == policy2.Value.NumberToKeep));

                    if (result)
                    {
                        break;
                    }
                }

                if (!result)
                {
                    break;
                }
            }

            return result;
        }
    }
}