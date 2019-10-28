using System.Windows.Forms;

namespace TFSManager.Core.WinForms
{
    public class ListViewSortInfo
    {
        public ListViewSortInfo()
        {
            this.Index = -1;
            this.Order = SortOrder.None;
        }

        public ListViewSortInfo(int index, SortOrder order)
        {
            this.Index = index;
            this.Order = order;
        }

        public int Index { get; set; }
        public SortOrder Order { get; set; }
    }
}