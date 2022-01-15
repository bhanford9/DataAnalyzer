using DataAnalyzer.Common.DataConverters.ExcelConverters;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using ExcelService.DataActions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels
{
  public class ExcelSetupModel : BasePropertyChanged
  {
    private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;

    public ExcelSetupModel()
    {
      ActionLibrary actionLibrary = new ActionLibrary();

      actionLibrary.GetWorkbookActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.AvailableWorkbookActions.Add(x));

      actionLibrary.GetWorksheetActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.AvailableWorksheetActions.Add(x));

      actionLibrary.GetDataClusterActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.AvailableDataClusterActions.Add(x));

      actionLibrary.GetRowActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.AvailableRowActions.Add(x));

      actionLibrary.GetCellActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.AvailableCellActions.Add(x));

      // TODO --> add custom saved configuration actions

      this.ExcelConfiguration.PropertyChanged += this.ExcelConfigurationPropertyChanged;
    }

    public ExcelConfigurationModel ExcelConfiguration => BaseSingleton<ExcelConfigurationModel>.Instance;

    public ObservableCollection<ExcelAction> AvailableWorkbookActions { get; }
      = new ObservableCollection<ExcelAction>();

    public ObservableCollection<ExcelAction> AvailableWorksheetActions { get; }
      = new ObservableCollection<ExcelAction>();

    public ObservableCollection<ExcelAction> AvailableDataClusterActions { get; }
      = new ObservableCollection<ExcelAction>();

    public ObservableCollection<ExcelAction> AvailableRowActions { get; }
      = new ObservableCollection<ExcelAction>();

    public ObservableCollection<ExcelAction> AvailableCellActions { get; }
      = new ObservableCollection<ExcelAction>();

    public void LoadWorkbookConfiguration()
    {
      // if its not empty, then the previous configuration was already loaded in
      if (this.ExcelConfiguration.WorkbookModels.Count == 0)
      {
        foreach (HeirarchalStats workbookStats in this.statsModel.HeirarchalStats.Children)
        {
          WorkbookModel workbookModel = new WorkbookModel { Name = workbookStats.Key.ToString() };
          foreach (HeirarchalStats worksheetStats in workbookStats.Children)
          {
            WorksheetModel worksheetModel = new WorksheetModel { WorksheetName = worksheetStats.Key.ToString() };
            foreach (HeirarchalStats dataclusterStats in worksheetStats.Children)
            {
              DataClusterModel dataClusterModel = new DataClusterModel { Name = dataclusterStats.Key.ToString() };
              worksheetModel.DataClusters.Add(dataClusterModel);
            }

            workbookModel.Worksheets.Add(worksheetModel);
          }

          this.ExcelConfiguration.WorkbookModels.Add(workbookModel);
        }
      }
    }

    public void SaveWorkbookConfiguration(string configName)  
    {
      this.ExcelConfiguration.SaveWorkbookConfiguration(configName);
    }

    public void NotiyExcelActionApplied(string actionAppliedKey)
    {
      this.NotifyPropertyChanged(actionAppliedKey);
    }

    private void ExcelConfigurationPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.ExcelConfiguration.WorkbookModels):
          this.NotifyPropertyChanged(nameof(this.ExcelConfiguration));
          break;
      }
    }
  }
}
