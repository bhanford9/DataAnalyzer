using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExcelSetupViews
{
  public partial class ExcelDataClusterSetupView : UserControl
  {
    private ExcelSetupViewModel excelSetupViewModel = new ExcelSetupViewModel();

    public ExcelDataClusterSetupView()
    {
      this.InitializeComponent();
      this.DataContext = this.excelSetupViewModel;
    }
  }
}
