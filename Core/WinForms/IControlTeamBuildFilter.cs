namespace TFSManager.Core.WinForms
{
    public interface IControlTeamBuildFilter
    {
        string[] CheckedProjects { get; }

        string LastAppliedFilterHashCode { get; }

        void CheckProject(string teamProject, bool @checked);

        void CheckAllProjects();

        void ClearFilter();

        void ApplyFilter();

        bool IsCheckedProject(string teamProject);
    }
}