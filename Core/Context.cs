using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

using TFSManager.Core.WinForms;
using System.Linq;

namespace TFSManager.Core
{
    /// <summary>
    /// Context
    /// </summary>
    public class Context
    {
        public const string BUILD_NONE = "None";
        public const string BUILD_FILE = "TFSBuild.proj";

        private static IBuildServer buildServer;
        private static BuildTemplateCollection buildTemplates;
        private static VersionControlServer controlServer;
        private static ICommonStructureService cSSproxy;
        private static IEventService eventService;
        private static XmlDocument globalLists;
        private static bool isConnected;
        private static WorkItemStore itemStore;
        private static LoginInfo loginInfo = new LoginInfo(string.Empty);
        private static IGroupSecurityService securityService;
        private static TeamFoundationServer tfsServer;


        /// <summary>
        /// BuildTemplates
        /// </summary>
        /// <value></value>
        public static BuildTemplateCollection BuildTemplates
        {
            get
            {
                return buildTemplates;
            }
            set
            {
                buildTemplates = value;
            }
        }

        /// <summary>
        /// Gets or sets the tfsServer.
        /// </summary>
        /// <value>The tfsServer.</value>
        public static TeamFoundationServer TfsServer
        {
            get
            {
                return tfsServer;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public static XmlDocument GlobalLists
        {
            get
            {
                return globalLists;
            }
        }

        /// <summary>
        /// Gets or sets the CS sproxy.
        /// </summary>
        /// <value>The CS sproxy.</value>
        public static ICommonStructureService CSSproxy
        {
            get
            {
                return cSSproxy;
            }
        }

        /// <summary>
        /// Gets or sets the event service.
        /// </summary>
        /// <value>The event service.</value>
        public static IEventService EventService
        {
            get
            {
                return eventService;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public static WorkItemStore ItemStore
        {
            get
            {
                return itemStore;
            }
        }

        public static IGroupSecurityService SecurityService
        {
            get
            {
                return securityService;
            }
        }

        public static IBuildServer BuildServer
        {
            get
            {
                return buildServer;
            }
        }

        public static VersionControlServer ControlServer
        {
            get
            {
                return controlServer;
            }
        }

        /// <summary>
        /// Gets or sets the name of the tfsServer.
        /// </summary>
        /// <value>The name of the tfsServer.</value>
        public static string ServerName
        {
            get
            {
                return loginInfo.ServerName;
            }
        }

        /// <summary>
        /// Gets the logged user.
        /// </summary>
        /// <value>The logged user.</value>
        public static string LoggedUser
        {
            get
            {
                return (tfsServer != null ? tfsServer.AuthenticatedUserName : "-");
            }
        }

        /// <summary>
        /// Gets the logged user.
        /// </summary>
        /// <value>The logged user.</value>
        public static string LoggedDisplayUser
        {
            get
            {
                return (tfsServer != null ? tfsServer.AuthenticatedUserDisplayName : "-");
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public static bool IsConnected
        {
            get
            {
                return isConnected;
            }
        }


        /// <summary>
        /// Gets the login info.
        /// </summary>
        /// <value>The login info.</value>
        public static LoginInfo LoginInfo
        {
            get
            {
                return loginInfo;
            }
        }

        /// <summary>
        /// Startups the connect.
        /// </summary>
        /// <returns>False if we're not connected to any server or true if we are connected.</returns>
        public static bool StartupConnect()
        {
            bool result = false;

            UIContext.Instance.LogMessage(new IconListEntry
                {
                    Icon = UIContext.Instance.GetLogImage(LogImage.Info),
                    Text = "Startup connect..."
                });


            string serverName = Config.Instance.TeamFoundationServerName;

            if (string.IsNullOrEmpty(serverName))
            {
                TeamFoundationServer[] servers = RegisteredServers.GetServers();

                if (servers.Length > 0)
                {
                    foreach (var srv in servers)
                    {
                        try
                        {
                            IBuildServer buildServer = srv.GetService<IBuildServer>();
                            BuildServerVersion buildServerVersion = buildServer.BuildServerVersion;
                            if (buildServerVersion.ToString() == "V3")
                            {
                                serverName = srv.Name;
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }


            if (serverName != null)
            {
                UIContext.Instance.LogMessage(new IconListEntry
                {
                    Icon = UIContext.Instance.GetLogImage(LogImage.Info),
                    Text = string.Format("Connecting to server: ", serverName)
                });

                result = Connect(LoginInfo.CreateUsingLoggedUser(serverName));

                if (result)
                {
                    Config.Instance.TeamFoundationServerName = serverName;
                    Config.Instance.SaveToFile();
                }
            }
            else
            {
                UIContext.Instance.LogMessage(new IconListEntry
                {
                    Icon = UIContext.Instance.GetLogImage(LogImage.Error),
                    Text = "Could not found any available servers!"
                });
            }

            UIContext.Instance.LogMessage(new IconListEntry
            {
                Icon = UIContext.Instance.GetLogImage(result ? LogImage.Info : LogImage.Error),
                Text = string.Format("Startup connect {0}", result ? "was successfull" : "failed")
            });

            UIContext.Instance.LogMessageNewLine();

            return result;
        }

        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, ProjectInfo> GetSortedProjects()
        {
            var projects = new List<ProjectInfo>(CSSproxy != null ? CSSproxy.ListProjects() : new ProjectInfo[0]);
            projects.Sort((x, y) => string.Compare(x.Name, y.Name));

            var result = new Dictionary<string, ProjectInfo>();
            projects.ForEach(info =>
                {
                    result.Add(info.Name, info);
                    BuildServerEvents.Instance.ConnectForEvents(info.Name);
                });
            return result;
        }

        /// <summary>
        /// Exports the global lists.
        /// </summary>
        public static void ExportGlobalLists()
        {
            globalLists = itemStore.ExportGlobalLists();
        }

        /// <summary>
        /// Connects the specified tfsServer name.
        /// </summary>
        /// <returns></returns>
        public static bool Connect(LoginInfo info)
        {
            Disconnect();

            bool loginByLoggedUser = info.UserName == null;

            UIContext.Instance.LogMessage(new IconListEntry
                {
                    Icon = UIContext.Instance.GetLogImage(LogImage.Info),
                    Text = string.Format("Connecting to server '{0}' using '{1}'...",
                        info.ServerName,
                        loginByLoggedUser
                            ? "current windows logged user credentials"
                            : string.Format("credentials with user name '{0}' and domain: '{1}'", info.UserName, info.Domain))
                });

            loginInfo = info;
            bool result = TFSUtils.TestConnection(info);
            if (result)
            {
                tfsServer = TFSUtils.LastConnectedServer;
                result = (tfsServer != null);
                if (result)
                {
                    eventService = (IEventService) tfsServer.GetService(typeof(IEventService));
                    cSSproxy = (ICommonStructureService) tfsServer.GetService(typeof(ICommonStructureService));
                    itemStore = (WorkItemStore) tfsServer.GetService(typeof(WorkItemStore));
                    securityService = (IGroupSecurityService) tfsServer.GetService(typeof(IGroupSecurityService));
                    buildServer = (IBuildServer) tfsServer.GetService(typeof(IBuildServer));
                    controlServer = (VersionControlServer) tfsServer.GetService(typeof(VersionControlServer));
                }
            }
            
            isConnected = result;

            if (result)
            {
                UIContext.Instance.LogMessage(new IconListEntry
                    {
                        Icon = UIContext.Instance.GetLogImage(LogImage.Info),
                        Text = string.Format("Connected successfully as: {0} ({1})", Context.LoggedDisplayUser, Context.LoggedUser)
                    });
                
            }

            UIContext.Instance.LogMessage(new IconListEntry
            {
                Icon = UIContext.Instance.GetLogImage(result ? LogImage.Info : LogImage.Error),
                Text = string.Format("Connecting to server '{0}' {1}", info.ServerName, result ? "was successfull" : "failed")
            });

            return result;
        }

        public static void Disconnect()
        {
            if (!string.IsNullOrEmpty(temporaryWorkspaceName))
            {
                try
                {
                    Workspace workspace = controlServer.GetWorkspace(temporaryWorkspaceName, ControlServer.AuthenticatedUser);
                    List<string> foldersToDelete = new List<string>();
                    foreach (var workingFolder in workspace.Folders)
                    {
                        foldersToDelete.Add(workingFolder.LocalItem);
                    }

                    controlServer.DeleteWorkspace(temporaryWorkspaceName, controlServer.AuthenticatedUser);
                    temporaryWorkspaceName = null;

                    foreach (var folder in foldersToDelete)
                    {
                        try
                        {
                            Util.RecursiveFolderDelete(folder);
                        }
                        catch {}
                    }
                }
                catch { }
            }

            if (tfsServer != null)
            {
                BuildServerEvents.Instance.DisconnectAll();

                tfsServer.Dispose();
            }
        }

        public static IBuildDetail GetBuild(string teamProject, string buildNumber)
        {
            IBuildDetailSpec buildDetailSpec = BuildServer.CreateBuildDetailSpec(teamProject);
            buildDetailSpec.BuildNumber = buildNumber;
            IBuildQueryResult buildQueryResult = BuildServer.QueryBuilds(buildDetailSpec);
            return buildQueryResult.Builds.Length == 1 ? buildQueryResult.Builds[0] : null;
        }

//        public static string GetProjectBuildFileName(IBuildDefinition definition)
//        {
//            return string.Format("{0}/{1}", definition.ConfigurationFolderPath, BUILD_FILE);
//        }

        public static Item GetProjectBuildFileItem(IBuildDefinition definition)
        {
            //string query = definition.ConfigurationFolderPath + "/" + BUILD_FILE;
            string configurationFolderPath = definition.GetConfigurationFolderPath();
            string query = configurationFolderPath + "/" + BUILD_FILE;
            ItemSet items = ControlServer.GetItems(query, VersionSpec.Latest,
                            RecursionType.Full, DeletedState.NonDeleted, ItemType.File);
            if (items.Items.Length == 1)
            {
                return items.Items[0];
            }

            return null;
        }

        private static string temporaryWorkspaceName = null;

        public static Workspace GetTemporaryWorkspace()
        {
            Workspace workspace = null;
            if (!string.IsNullOrEmpty(temporaryWorkspaceName))
            {
                workspace = ControlServer.GetWorkspace(temporaryWorkspaceName, ControlServer.AuthenticatedUser);
            }

            if (string.IsNullOrEmpty(temporaryWorkspaceName))
            {
                temporaryWorkspaceName = string.Format("tfsman_{0}", DateTime.Now.Ticks);
            }

            if (workspace == null)
            {
                workspace = ControlServer.CreateWorkspace(temporaryWorkspaceName, ControlServer.AuthenticatedUser);
            }

            return workspace;
        }

        public static Workspace GetTemporaryWorkspaceAndMap(string serverPath, string localPath)
        {
            Workspace workspace = GetTemporaryWorkspace();
            if (workspace != null)
            {
                //if (!workspace.IsServerPathMapped(serverPath))
                {
                    workspace.Map(serverPath, localPath);
                }
            }

            return workspace;
        }
    }
}