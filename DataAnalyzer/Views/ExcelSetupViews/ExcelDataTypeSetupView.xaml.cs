using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExcelSetupViews;

public partial class ExcelDataTypeSetupView : UserControl
{
    public ExcelDataTypeSetupView() : this(Resolver.Resolve<IExcelDataTypesViewModel>()) { }
    internal ExcelDataTypeSetupView(IExcelDataTypesViewModel viewModel)
    {
        this.InitializeComponent();
        this.DataContext = viewModel;
    }
}
