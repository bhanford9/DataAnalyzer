using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.DataConfigurations.ExcelConfiguration;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
  public class ExcelSetupViewModel : BasePropertyChanged
  {
    private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
    private readonly ExcelSetupModel excelSetupModel = BaseSingleton<ExcelSetupModel>.Instance;
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;

    private readonly BaseCommand loadDataIntoStructure;

    private DataLoadingState dataLoadingState = DataLoadingState.NoDataLoaded;
    private double loadingProgress = 0.0;

    public ExcelSetupViewModel()
    {
      this.loadDataIntoStructure = new BaseCommand((obj) => this.DoLoadDataIntoStructure());

      this.excelSetupModel.WorkbookActions.ToList().ForEach(x => this.WorkbookActions.Add(x));
      this.excelSetupModel.WorksheetActions.ToList().ForEach(x => this.WorksheetActions.Add(x));
      this.excelSetupModel.DataClusterActions.ToList().ForEach(x => this.DataClusterActions.Add(x));
      this.excelSetupModel.RowActions.ToList().ForEach(x => this.RowActions.Add(x));
      this.excelSetupModel.CellActions.ToList().ForEach(x => this.CellActions.Add(x));

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

      // TODO --> move this down to the stats model
      ExcelConfiguration configuration = new ExcelConfiguration();
      IDataParameterCollection parameters = this.configurationModel.DataParameterCollection;
      ICollection<GroupingConfiguration> groupings = this.configurationModel.DataConfiguration.GroupingConfiguration;

      for (int i = 0; i < groupings.Count; i++)
      {
        configuration.AddGroupingRule(i, parameters.GetStatAccessor(groupings.ElementAt(i).SelectedParameter));
      }

      DataOrganizer organizer = new DataOrganizer();
      HeirarchalStats heirarchalStats = organizer.Organize(configuration, this.statsModel.Stats);

      // might want to organzieinto other structures, not sure what will be desireable yet

      this.CurrentState = DataLoadingState.DataLoaded.ToString();
    }
  }
}
