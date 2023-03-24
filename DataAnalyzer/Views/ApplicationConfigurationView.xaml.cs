using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ApplicationConfigurationView : UserControl
    {
        private ApplicationConfigurationViewModel viewModel = new(BaseSingleton<ConfigurationModel>.Instance);

        public ApplicationConfigurationView()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
