using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels
{
    internal class ConfigurationExecutionViewModel : BasePropertyChanged
    {
        private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
        private string selectedExportType = string.Empty;

        public ConfigurationExecutionViewModel()
        {
            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
        }

        public string SelectedExportType
        {
            get => this.selectedExportType;
            set => this.NotifyPropertyChanged(ref this.selectedExportType, value);
        }

        public ExecutionExecutiveCommissioner ExecutiveCommissioner { get; }
            = BaseSingleton<ExecutionExecutiveCommissioner>.Instance;

        private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.ImportExportKey):
                    this.ExecutiveCommissioner.SetDisplay();
                    this.SelectedExportType = Enum.GetName(typeof(ExportType), this.configurationModel.SelectedExportType);
                    break;
                default:
                    break;
            }
        }
    }
}
