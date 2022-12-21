using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ExcelConfigurationSetupView : UserControl
    {
        private readonly ExcelSetupViewModel excelSetupViewModel = new();

        public ExcelConfigurationSetupView()
        {
            this.InitializeComponent();
            this.DataContext = this.excelSetupViewModel;
        }
    }
}
