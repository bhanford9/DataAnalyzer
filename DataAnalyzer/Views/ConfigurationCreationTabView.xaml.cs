using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ConfigurationCreationTabView : UserControl
    {
        private readonly ConfigurationCreationViewModel viewModel = new(
            BaseSingleton<ConfigurationModel>.Instance,
            BaseSingleton<StructureExecutiveCommissioner>.Instance);

        public ConfigurationCreationTabView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }
    }
}
