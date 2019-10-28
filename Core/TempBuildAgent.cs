using System;
using System.Collections.Generic;
using Microsoft.TeamFoundation.Build.Client;

namespace TFSManager.Core
{
    public class TempBuildAgent: IBuildAgent
    {
        public TempBuildAgent() {}

        public TempBuildAgent(IBuildAgent source)
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
        public string TeamProject { get; set; }
        public string FullPath { get; private set; }

        #endregion

        #region Implementation of IBuildAgent

        public string GetExpandedBuildDirectory(IBuildDefinition buildDefinition)
        {
            throw new NotImplementedException();
        }

        public IBuildAgent CopyTo(string teamProject)
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

        public IBuildAgentSpec CreateSpec()
        {
            throw new NotImplementedException();
        }

        public string BuildDirectory { get; set; }
        public string Description { get; set; }
        public AgentStatus Status { get; set; }
        public string StatusMessage { get; set; }
        public string MachineName { get; set; }
        public int MaxProcesses { get; set; }
        public int Port { get; set; }
        public bool RequireSecureChannel { get; set; }
        public int QueueCount { get; private set; }
        public IBuildServer BuildServer { get; private set; }

        public IBuildServiceHost ServiceHost { get; private set; }
        public IBuildController Controller { get; set; }
        public bool Enabled { get; set; }
        public Uri Url { get; private set; }
        public List<string> Tags { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }
        public bool IsReserved { get; private set; }
        public Uri ReservedForBuild { get; private set; }

        #endregion

        public void AssingTo(IBuildAgent targetAgent)
        {
            AssingTo(this, targetAgent);
        }

        public static void AssingTo(IBuildAgent sourceAgent, IBuildAgent targetAgent)
        {
            targetAgent.Name = sourceAgent.Name;
            targetAgent.Description = sourceAgent.Description;
            targetAgent.MachineName = sourceAgent.MachineName;
            //targetAgent.Port = sourceAgent.Port;
            targetAgent.RequireSecureChannel = sourceAgent.RequireSecureChannel;
            targetAgent.BuildDirectory = sourceAgent.BuildDirectory;
            targetAgent.Status = sourceAgent.Status;
            //targetAgent.MaxProcesses = sourceAgent.MaxProcesses;
        }

        public static bool IsEqual(IBuildAgent agent1, IBuildAgent agent2)
        {
            return ((agent1.BuildDirectory == agent2.BuildDirectory) &&
                (agent1.BuildServer.TeamFoundationServer == agent2.BuildServer.TeamFoundationServer) &&
                    (agent1.BuildServer.BuildServerVersion == agent2.BuildServer.BuildServerVersion) &&
                        (agent1.Description == agent2.Description
                            || (string.IsNullOrEmpty(agent1.Description) && string.IsNullOrEmpty(agent2.Description))) &&
                                (agent1.FullPath == agent2.FullPath) &&
                                    (agent1.MachineName == agent2.MachineName) &&
                                        //(agent1.MaxProcesses == agent2.MaxProcesses) &&
                                            (agent1.Name == agent2.Name) &&
                                                //(agent1.Port == agent2.Port) &&
                                                    (agent1.QueueCount == agent2.QueueCount) &&
                                                        (agent1.RequireSecureChannel == agent2.RequireSecureChannel) &&
                                                            (agent1.Status == agent2.Status) &&
                                                                (agent1.TeamProject == agent2.TeamProject) &&
                                                                    (agent1.Uri == agent2.Uri));
        }
    }
}