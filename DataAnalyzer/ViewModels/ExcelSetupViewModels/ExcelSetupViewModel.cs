using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Common.DataConfigurations.ExcelConfiguration;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataObjects.TimeStats.QueryableTimeStats;
using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels
{
  public class ExcelSetupViewModel : BasePropertyChanged
  {
    private readonly ConfigurationModel configurationModel = BaseSingleton<ConfigurationModel>.Instance;
    private readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;

    private readonly BaseCommand loadDataIntoStructure;

    private DataLoadingState dataLoadingState = DataLoadingState.NoDataLoaded;
    private double loadingProgress = 0.0;

    public ExcelSetupViewModel()
    {
      this.loadDataIntoStructure = new BaseCommand((obj) => this.DoLoadDataIntoStructure());
    }

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
