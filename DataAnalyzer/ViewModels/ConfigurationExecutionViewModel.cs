using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels
{
    internal class ConfigurationExecutionViewModel : BasePropertyChanged, IConfigurationExecutionViewModel
    {
        private readonly IConfigurationModel configurationModel;
        private string selectedExportType = string.Empty;

        public ConfigurationExecutionViewModel(
            IConfigurationModel configModel,
            IExecutionExecutiveCommissioner executiveCommissioner)
        {
            this.configurationModel = configModel;
            this.ExecutiveCommissioner = executiveCommissioner;
            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
        }

        public string SelectedExportType
        {
            get => this.selectedExportType;
            set => this.NotifyPropertyChanged(ref this.selectedExportType, value);
        }

        public IExecutionExecutiveCommissioner ExecutiveCommissioner { get; }

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
