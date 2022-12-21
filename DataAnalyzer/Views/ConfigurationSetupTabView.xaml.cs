using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ConfigurationSetupTabView : UserControl
    {
        private readonly ConfigurationSetupViewModel viewModel = new();
        public ConfigurationSetupTabView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }
    }
}
