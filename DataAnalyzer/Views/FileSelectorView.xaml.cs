using System.Windows.Controls;
using DataAnalyzer.ViewModels;

namespace DataAnalyzer.Views
{
    public partial class FileSelectorView : UserControl
    {
        private readonly FileSelectorViewModel viewModel = new FileSelectorViewModel();

        public FileSelectorView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }
    }
}
