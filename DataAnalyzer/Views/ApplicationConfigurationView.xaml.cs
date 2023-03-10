using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ApplicationConfigurationView : UserControl
    {
        private ApplicationConfigurationViewModel viewModel = new();

        public ApplicationConfigurationView()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
