using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExecutionViews
{
    public partial class ExcelConfigurationSetupView : UserControl
    {
        internal ExcelConfigurationSetupView(IExcelSetupViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
