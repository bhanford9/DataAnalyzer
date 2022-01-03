using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    //   implementations or data structures, understanding that this will mean 15+ different models
    private readonly IActionCreationModel workbookActionCreationModel = new WorkbookActionCreationModel();
    private readonly IActionCreationModel worksheetActionCreationModel = new WorksheetActionCreationModel();
    private readonly IActionCreationModel dataClusterActionCreationModel = new DataClusterActionCreationModel();

    private readonly IActionApplicationModel workbookActionApplicationModel = new WorkbookActionApplicationModel();
    private readonly IActionApplicationModel worksheetActionApplicationModel = new WorksheetActionApplicationModel();
    private readonly IActionApplicationModel dataClusterActionApplicationModel = new DataClusterActionApplicationModel();

    private readonly IActionsSummaryModel workbookActionsSummaryModel = new WorkbookActionsSummaryModel();
    private readonly IActionsSummaryModel worksheetActionsSummaryModel = new WorksheetActionsSummaryModel();
    private readonly IActionsSummaryModel dataClusterActionsSummaryModel = new DataClusterActionsSummaryModel();

    private readonly BaseCommand loadDataIntoStructure;

    private DataLoadingState dataLoadingState = DataLoadingState.NoDataLoaded;
    private double loadingProgress = 0.0;

    public ExcelSetupViewModel()
    {
      this.loadDataIntoStructure = new BaseCommand((obj) => this.DoLoadDataIntoStructure());

      this.WorkbookActionViewModel = new ExcelActionViewModel(
        this.WorkbookActions,
        this.workbookActionCreationModel,
        this.workbookActionApplicationModel,
        this.workbookActionsSummaryModel);

      this.WorksheetActionViewModel = new ExcelActionViewModel(
        this.WorksheetActions,
        this.worksheetActionCreationModel,
        this.worksheetActionApplicationModel,
        this.worksheetActionsSummaryModel);

      this.DataClusterActionViewModel = new ExcelActionViewModel(
        this.DataClusterActions,
        this.dataClusterActionCreationModel,
        this.dataClusterActionApplicationModel,
        this.dataClusterActionsSummaryModel);

      this.configurationModel.PropertyChanged += this.ConfigurationModelPropertyChanged;
      this.excelSetupModel.PropertyChanged += this.ExcelSetupModelPropertyChanged;
    }

    public ExcelActionViewModel WorkbookActionViewModel { get; set; }

    public ExcelActionViewModel WorksheetActionViewModel { get; set; }

    public ExcelActionViewModel DataClusterActionViewModel { get; set; }

    public ObservableCollection<ExcelAction> WorkbookActions => this.excelSetupModel.AvailableWorkbookActions;

    public ObservableCollection<ExcelAction> WorksheetActions => this.excelSetupModel.AvailableWorksheetActions;

    public ObservableCollection<ExcelAction> DataClusterActions => this.excelSetupModel.AvailableDataClusterActions;

    public ObservableCollection<ExcelAction> RowActions => this.excelSetupModel.AvailableRowActions;

    public ObservableCollection<ExcelAction> CellActions => this.excelSetupModel.AvailableCellActions;

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
      this.excelSetupModel.LoadWorkbookConfiguration();

      this.CurrentState = DataLoadingState.DataLoaded.ToString();
    }

    private void ConfigurationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.configurationModel.DataConfiguration):
          if (this.configurationModel.SelectedExportType.Equals(ExportType.Excel))
          {
          }
          break;
      }
    }

    private void ExcelSetupModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case WorkbookActionApplicationModel.ACTION_APPLIED_KEY:
          this.WorkbookActionViewModel.ActionsSummaryViewModel.LoadActionsFromModel();
          break;
        case WorksheetActionApplicationModel.ACTION_APPLIED_KEY:
          this.WorksheetActionViewModel.ActionsSummaryViewModel.LoadActionsFromModel();
          break;
        case DataClusterActionApplicationModel.ACTION_APPLIED_KEY:
          this.DataClusterActionViewModel.ActionsSummaryViewModel.LoadActionsFromModel();
          break;
      }
    }
  }
}