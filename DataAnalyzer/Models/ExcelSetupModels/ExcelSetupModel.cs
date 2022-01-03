using DataAnalyzer.Common.DataConverters.ExcelConverters;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using ExcelService.DataActions;
using System.Collections.ObjectModel;
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
    }

    public ExcelConfigurationModel ExcelConfiguration { get; } = new ExcelConfigurationModel();

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
      this.ExcelConfiguration.WorkbookModels.Clear();
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

    public void NotiyExcelActionApplied(string actionAppliedKey)
    {
      this.NotifyPropertyChanged(actionAppliedKey);
    }
  }
}
