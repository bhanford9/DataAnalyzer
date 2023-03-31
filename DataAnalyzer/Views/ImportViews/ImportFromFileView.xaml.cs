using DataAnalyzer.ViewModels.ImportViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views.ImportViews
{
    public partial class ImportFromFileView : UserControl
    {        
        internal ImportFromFileView(IImportFromFileViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
