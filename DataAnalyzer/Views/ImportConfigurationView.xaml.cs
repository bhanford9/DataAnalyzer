using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataConverters;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ImportConfigurationView : UserControl
    {
        private readonly ImportConfigurationViewModel viewModel = new(
            BaseSingleton<ConfigurationModel>.Instance,
            BaseSingleton<ImportExecutiveCommissioner>.Instance,
            BaseSingleton<DataConverterLibrary>.Instance);

        public ImportConfigurationView()
        {
            this.InitializeComponent();
            this.DataContext = this.viewModel;
        }
    }
}
