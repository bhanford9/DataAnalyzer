using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ConfigurationSetupTabView : UserControl
    {
        private readonly ConfigurationExecutionViewModel viewModel = new(
            BaseSingleton<ConfigurationModel>.Instance,
            BaseSingleton<ExecutionExecutiveCommissioner>.Instance);

        public ConfigurationSetupTabView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }
    }
}
