using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using System;
using System.ComponentModel;

namespace DataAnalyzer.ViewModels
{
  public class ConfigurationSetupViewModel : BasePropertyChanged
  {
    private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
    private readonly MainModel mainModel = BaseSingleton<MainModel>.Instance;

    private string selectedExportType = string.Empty;

    public ConfigurationSetupViewModel()
    {
      this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
    }

    public string SelectedExportType
    {
      get => this.selectedExportType;
      set => this.NotifyPropertyChanged(nameof(this.SelectedExportType), ref this.selectedExportType, value);
    }

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
  }
}
