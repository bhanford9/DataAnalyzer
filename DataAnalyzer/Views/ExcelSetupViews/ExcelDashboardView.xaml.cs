using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExcelSetupViews
{
  public partial class ExcelDashboardView : UserControl
  {
    private readonly ExcelDashboardViewModel viewModel = new ExcelDashboardViewModel();

    public ExcelDashboardView()
    {
      this.InitializeComponent();
      this.DataContext = this.viewModel;
    }
  }
}
