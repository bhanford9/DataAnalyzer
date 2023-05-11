using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels;

internal class ConfigurationExecutionViewModel : BasePropertyChanged, IConfigurationExecutionViewModel
{
    private readonly IConfigurationModel configurationModel;
    private string selectedExecutionType = string.Empty;

    public ConfigurationExecutionViewModel(
        IConfigurationModel configModel,
        IExecutionExecutiveCommissioner executiveCommissioner)
    {
        this.configurationModel = configModel;
        this.ExecutiveCommissioner = executiveCommissioner;
        this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
    }

    public string SelectedExecutionType
    {
        get => this.selectedExecutionType;
        set => this.NotifyPropertyChanged(ref this.selectedExecutionType, value);
    }

    public IExecutionExecutiveCommissioner ExecutiveCommissioner { get; }

    private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(this.configurationModel.ImportExecutionKey):
                this.ExecutiveCommissioner.SetDisplay();
                this.SelectedExecutionType = Enum.GetName(typeof(ExecutionType), this.configurationModel.SelectedExecutionType);
                break;
            default:
                break;
        }
    }
}
