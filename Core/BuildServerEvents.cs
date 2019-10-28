using System;
using System.Collections.Generic;

using Microsoft.TeamFoundation.Build.Client;

namespace TFSManager.Core
{
    public class BuildServerEvents
    {
        #region singleton

        private static BuildServerEvents instance;

        public static BuildServerEvents Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BuildServerEvents();
                }
                return instance;
            }
        }

        #endregion singleton

        #region fields

        private readonly object sync = new object();
        private readonly Dictionary<string, IQueuedBuildsView> buildsViews = new Dictionary<string, IQueuedBuildsView>();

        #endregion fields

        public event Action<BuildStatusChangedEventArgs> OnBuildStatusChanged;

        private void InvokeOnBuildStatusChanged(IQueuedBuildsView buildsView, StatusChangedEventArgs args)
        {
            Action<BuildStatusChangedEventArgs> handler = this.OnBuildStatusChanged;
            if (handler != null)
            {
                handler(new BuildStatusChangedEventArgs(args, buildsView));
            }
        }

        private void BuildsViewOnStatusChanged(object sender, StatusChangedEventArgs statusChangedEventArgs)
        {
            IQueuedBuildsView buildsView = sender as IQueuedBuildsView;
            InvokeOnBuildStatusChanged(buildsView, statusChangedEventArgs);
        }

        public void ConnectForEvents(string teamProject)
        {
            ConnectForEvents(teamProject, QueueStatus.All);
        }

        public void ConnectForEvents(string teamProject, QueueStatus queueStatus)
        {
            IQueuedBuildsView buildsView = null;

            lock (sync)
            {
                if (buildsViews.ContainsKey(teamProject))
                {
                    return;
                }

                buildsView = Context.BuildServer.CreateQueuedBuildsView(teamProject);
                buildsView.StatusFilter = queueStatus;
                buildsView.StatusChanged += BuildsViewOnStatusChanged;
                this.buildsViews.Add(teamProject, buildsView);
            }
            
            buildsView.Connect();
        }

        public void DisconnectAll()
        {
            IQueuedBuildsView[] tmp;
            lock (sync)
            {
                tmp = new IQueuedBuildsView[this.buildsViews.Count];
                buildsViews.Values.CopyTo(tmp, 0);
                buildsViews.Clear();
            }

            foreach (IQueuedBuildsView buildsView in tmp)
            {
                try
                {
                    buildsView.StatusChanged -= BuildsViewOnStatusChanged;
                    buildsView.Disconnect();
                }
                catch {}
            }
        }
    }

    #region class BuildStatusChangedEventArgs

    public class BuildStatusChangedEventArgs: EventArgs
    {
        public StatusChangedEventArgs Args { get; private set; }
        public IQueuedBuildsView Queue { get; private set; }

        public BuildStatusChangedEventArgs(StatusChangedEventArgs args, IQueuedBuildsView queue)
        {
            this.Args = args;
            this.Queue = queue;
        }
    }

    #endregion class BuildStatusChangedEventArgs
}