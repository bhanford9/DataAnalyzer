using DataAnalyzer.ViewModels.ExecutionViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExecutionViews
{
    public partial class ClassCreationSetupView : UserControl
    {
        private readonly ClassCreationSetupViewModel viewModel = new();
        public ClassCreationSetupView()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
