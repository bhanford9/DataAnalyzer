using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExcelSetupViews
{
  public partial class ExcelDataTypeSetupView : UserControl
  {
    private readonly ExcelDataTypesViewModel excelDataTypesViewModel = new ExcelDataTypesViewModel();

    public ExcelDataTypeSetupView()
    {
      this.InitializeComponent();
      this.DataContext = this.excelDataTypesViewModel;
    }
  }
}
