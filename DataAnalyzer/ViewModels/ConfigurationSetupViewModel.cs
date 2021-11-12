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

    private void HeirarchyData()
    {
      //ExcelConfiguration configuration = new ExcelConfiguration();
      //configuration.AddGroupingRule(0, (stats) => (stats as QueryableTimeStats).MethodName);
      //configuration.AddGroupingRule(1, (stats) => (stats as QueryableTimeStats).ContainerType);
      //configuration.AddGroupingRule(2, (stats) => (stats as QueryableTimeStats).CategoryType);

      //DataOrganizer organizer = new DataOrganizer();
      //organizer.Organize(configuration, this.statsModel.Stats);
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
