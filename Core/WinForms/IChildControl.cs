namespace TFSManager.Core.WinForms
{
    public interface IMasterForm
    {
        void Notify(IChildControl child, params object[] args);
    }

    public interface IChildControl
    {
        IMasterForm OwnerForm { get; }
        void InitializeControl(IMasterForm ownerForm);
    }
}