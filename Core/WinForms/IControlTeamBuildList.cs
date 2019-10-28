using Microsoft.TeamFoundation.Build.Client;

namespace TFSManager.Core.WinForms
{
    public interface IControlTeamBuildList
    {
        void FocusAndSelectTeamBuild(IQueuedBuild queuedBuild);

        void FocusAndSelectTeamBuild(string buildNumber);

        void ChangeFilterBuilds(bool queued);
    }
}