namespace TFSManager.Core.WinForms
{
    public interface IControlWorkItems
    {
        void FindRelatedWorkItems(string teamProject, string query, HighlightFilter highlightings);
    }
}