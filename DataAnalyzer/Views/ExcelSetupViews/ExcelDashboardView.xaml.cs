using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ExcelSetupViews
{
    public partial class ExcelDashboardView : UserControl
    {
        public ExcelDashboardView() : this(Resolver.Resolve<IExcelDashboardViewModel>()) { }

        internal ExcelDashboardView(IExcelDashboardViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
