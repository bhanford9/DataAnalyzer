using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ImportConfigurationView : UserControl
    {
        private ImportConfigurationViewModel viewModel = new();

        public ImportConfigurationView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }
    }
}
