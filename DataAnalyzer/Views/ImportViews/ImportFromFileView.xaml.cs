using DataAnalyzer.ViewModels.ImportViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ImportViews
{
    public partial class ImportFromFileView : UserControl
    {
        private ImportFromFileViewModel viewModel = new();
        
        public ImportFromFileView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }
    }
}
