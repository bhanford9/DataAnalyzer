using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExcelSetupViews
{
    public partial class ExcelDataTypeSetupView : UserControl
    {
        internal ExcelDataTypeSetupView(IExcelDataTypesViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
