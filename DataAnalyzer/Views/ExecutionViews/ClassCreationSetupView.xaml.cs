using DataAnalyzer.ViewModels.ExecutionViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExecutionViews
{
    public partial class ClassCreationSetupView : UserControl
    {
        public ClassCreationSetupView() : this(Resolver.Resolve<IClassCreationSetupViewModel>()) { }
        internal ClassCreationSetupView(IClassCreationSetupViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
