﻿using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
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

      this.WorkbookActionCreationViewModel = new ActionCreationViewModel(this.WorkbookActions);
      this.DataClusterActionCreationViewModel = new ActionCreationViewModel(this.DataClusterActions);
    }

    /// <summary>
    /// Design Decisions:
    ///   1. Make this view model a singleton so the data is not copied everywhere
    ///   2. Split out the view models to indiviudal views instead of having them use this viewmodel
    ///   
    /// Pretty sure I want option (2). I was probably trying to move to quickly and overlooked the fact
    ///   that I was using this view model within the child views and therefore have some weird dependencies
    ///   and copied data structures
    /// </summary>

    public ActionCreationViewModel WorkbookActionCreationViewModel { get; set; }

    public ActionCreationViewModel DataClusterActionCreationViewModel { get; set; }

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
