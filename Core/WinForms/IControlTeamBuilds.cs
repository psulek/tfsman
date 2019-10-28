using Microsoft.TeamFoundation.Build.Client;

namespace TFSManager.Core.WinForms
{
    public interface IControlTeamBuilds
    {
        IControlTeamBuildFilter ControlTeamBuildFilter { get; }
        
        IControlTeamBuildList ControlTeamBuildList { get; }

        void FocusAndSelectTeamBuild(IQueuedBuild queuedBuild);

        void FocusAndSelectTeamBuild(string teamProject, string buildNumber);

        void FocusAndSelectBuildTemplate(IBuildDefinition definition);

        void FocusAndSelectBuildTemplate(BuildTemplate buildTemplate);
    }
}