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
        private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

        private ExecutiveType executiveType = ExecutiveType.NotSupported;
        private string selectedExportType = string.Empty;

        public ConfigurationExecutionViewModel()
        {
            this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;

            this.mainModel.PropertyChanged += this.MainModelPropertyChanged;
        }

        public string SelectedExportType
        {
            get => this.selectedExportType;
            set => this.NotifyPropertyChanged(ref this.selectedExportType, value);
        }

        public ExecutiveType ExecutiveType
        {
            get => this.executiveType;
            set => this.NotifyPropertyChanged(ref this.executiveType, value);
        }

        public ExecutionExecutiveCommissioner ExecutiveCommissioner { get; }
            = BaseSingleton<ExecutionExecutiveCommissioner>.Instance;

        private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.configurationModel.SelectedExportType):
                    this.SelectedExportType = Enum.GetName(typeof(ExportType), this.configurationModel.SelectedExportType);
                    break;
                default:
                    break;
            }
        }

        private void MainModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.mainModel.ExecutiveType):
                    this.ExecutiveType = this.mainModel.ExecutiveType;
                    this.ExecutiveCommissioner.SetDisplay(this.ExecutiveType);
                    break;
            }
        }

        //private void ExecutiveCommissionerPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    switch (e.propertyName)
        //    {
        //        case nameof(this.ExecutiveCommissioner.ExecutiveType):
        //            //if (this.ExecutiveType != ExecutiveType.NotSupported)
        //            //{
        //            //    this.ActiveViewModel = this.ExecutiveCommissioner.GetInitializedViewModel();
        //            //    this.ApplyConfigurationDirectory(this.ExecutiveCommissioner.GetConfigurationDirectory());
        //            //}

        //            this.ExecutiveCommissioner.SetDisplay(this.ExecutiveType);
        //            break;
        //    }
        //}
    }
}
