using System.Windows.Forms;

using Microsoft.TeamFoundation.Build.Client;

namespace TFSManager.Forms
{
    public partial class FormBuildDetail: Form
    {
        public FormBuildDetail()
        {
            InitializeComponent();
        }

        public static void DialogShow(IBuildDetail buildDetail)
        {
            var form = new FormBuildDetail();
            form.detailPanel.Initialize(buildDetail);
            form.ShowDialog();
        }
    }
}