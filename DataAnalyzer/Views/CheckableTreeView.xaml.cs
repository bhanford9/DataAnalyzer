using System.Windows.Controls;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.Views
{
    public partial class CheckableTreeView : UserControl
    {
        private readonly CheckableTreeViewItem viewModel = new();

        public CheckableTreeView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }
    }
}
