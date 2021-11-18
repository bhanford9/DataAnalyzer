using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
  public class ExcelSetupViewModel : BasePropertyChanged
  {
    private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
    private readonly ExcelSetupModel excelSetupModel = BaseSingleton<ExcelSetupModel>.Instance;
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;


    // If these never get used in this class, then they can be removed as private members
    //
    // If the only way these all differ is by the way they extract their action collections,
    //   then it may be better to have a single class and set a function parameter to the means 
    //   by which it can extract the action collection
    // 
    // For now... going with this route in case each model instance needs further independent
    //   implementations or data structures, understanding that this will mean 15 different models
    private readonly IActionCreationModel workbookActionCreationModel = new WorkbookActionCreationModel();
    private readonly IActionCreationModel worksheetActionCreationModel = new WorksheetActionCreationModel();
    private readonly IActionCreationModel dataClusterActionCreationModel = new DataClusterActionCreationModel();
    private readonly IActionApplicationModel workbookActionApplicationModel = new WorkbookActionApplicationModel();
    private readonly IActionApplicationModel worksheetActionApplicationModel = new WorksheetActionApplicationModel();
    private readonly IActionApplicationModel dataClusterActionApplicationModel = new DataClusterActionApplicationModel();

    private readonly BaseCommand loadDataIntoStructure;

    private DataLoadingState dataLoadingState = DataLoadingState.NoDataLoaded;
    private double loadingProgress = 0.0;

    public ExcelSetupViewModel()
    {
      this.loadDataIntoStructure = new BaseCommand((obj) => this.DoLoadDataIntoStructure());

      this.WorkbookActionViewModel = new ExcelActionViewModel(
        this.WorkbookActions,
        this.workbookActionCreationModel,
        this.workbookActionApplicationModel);

      this.WorksheetActionViewModel = new ExcelActionViewModel(
        this.WorksheetActions,
        this.worksheetActionCreationModel,
        this.worksheetActionApplicationModel);

      this.DataClusterActionViewModel = new ExcelActionViewModel(
        this.DataClusterActions,
        this.dataClusterActionCreationModel,
        this.dataClusterActionApplicationModel);
    }

    public ExcelActionViewModel WorkbookActionViewModel { get; set; }

    public ExcelActionViewModel WorksheetActionViewModel { get; set; }

    public ExcelActionViewModel DataClusterActionViewModel { get; set; }

    public ObservableCollection<ExcelAction> WorkbookActions => this.excelSetupModel.WorkbookActions;

    public ObservableCollection<ExcelAction> WorksheetActions => this.excelSetupModel.WorksheetActions;

    public ObservableCollection<ExcelAction> DataClusterActions => this.excelSetupModel.DataClusterActions;

    public ObservableCollection<ExcelAction> RowActions => this.excelSetupModel.RowActions;

    public ObservableCollection<ExcelAction> CellActions => this.excelSetupModel.CellActions;

    public ICommand LoadDataIntoStructure => this.loadDataIntoStructure;

    public string CurrentState
    {
      get => this.dataLoadingState.ToString();
      set
      {
        if (this.CurrentState != value)
        {
          this.dataLoadingState = Enum.Parse<DataLoadingState>(value);
          this.NotifyPropertyChanged(nameof(this.CurrentState));
        }
      }
    }

    public double LoadingProgress
    {
      get => this.loadingProgress;
      set => this.NotifyPropertyChanged(nameof(this.LoadingProgress), ref this.loadingProgress, value);
    }

    private void DoLoadDataIntoStructure()
    {
      this.CurrentState = DataLoadingState.LoadingData.ToString();

      this.statsModel.StructureStats();

      this.CurrentState = DataLoadingState.DataLoaded.ToString();
    }
  }
}