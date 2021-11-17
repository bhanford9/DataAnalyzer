using DataAnalyzer.Common.DataConverters.ExcelConverters;
using DataAnalyzer.Common.Mvvm;
using ExcelService.DataActions;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels
{
  public class ExcelSetupModel : BasePropertyChanged
  {
    private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;

    public ExcelSetupModel()
    {
      ActionLibrary actionLibrary = new ActionLibrary();

      actionLibrary.GetWorkbookActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.WorkbookActions.Add(x));

      actionLibrary.GetWorksheetActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.WorksheetActions.Add(x));

      actionLibrary.GetDataClusterActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.DataClusterActions.Add(x));

      actionLibrary.GetRowActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.RowActions.Add(x));

      actionLibrary.GetCellActionInfo()
        .Select(x => ExcelActionConverter.FromExcelActionInfo(x))
        .ToList()
        .ForEach(x => this.CellActions.Add(x));

      // TODO --> add custom saved configuration actions
    }

    public ObservableCollection<ExcelAction> WorkbookActions { get; }
      = new ObservableCollection<ExcelAction>();

    public ObservableCollection<ExcelAction> WorksheetActions { get; }
      = new ObservableCollection<ExcelAction>();

    public ObservableCollection<ExcelAction> DataClusterActions { get; }
      = new ObservableCollection<ExcelAction>();

    public ObservableCollection<ExcelAction> RowActions { get; }
      = new ObservableCollection<ExcelAction>();

    public ObservableCollection<ExcelAction> CellActions { get; }
      = new ObservableCollection<ExcelAction>();
  }
}
