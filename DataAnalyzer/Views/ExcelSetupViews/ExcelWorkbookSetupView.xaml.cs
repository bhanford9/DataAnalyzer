using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExcelSetupViews
{
  public partial class ExcelWorkbookSetupView : UserControl
  {
    private ExcelSetupViewModel excelSetupViewModel = new ExcelSetupViewModel();

    public ExcelWorkbookSetupView()
    {
      this.InitializeComponent();
      this.DataContext = this.excelSetupViewModel;
    }
  }
}
