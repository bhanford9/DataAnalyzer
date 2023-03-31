using System.Windows.Controls;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.Views
{
    public partial class CheckableTreeView : UserControl
    {
        public CheckableTreeView() : this(Resolver.Resolve<ICheckableTreeViewItem>()) { }

        internal CheckableTreeView(ICheckableTreeViewItem viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
