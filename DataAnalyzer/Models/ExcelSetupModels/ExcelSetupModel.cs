using DataAnalyzer.Common.DataConverters.ExcelConverters;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataObjects.TimeStats.QueryableTimeStats;
using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using ExcelService.DataActions;
using System.Collections.Generic;
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
              foreach (IStats rowStats in dataclusterStats.Values)
              {
                RowModel rowModel = new RowModel();
                ITypeParameter defaultType = BaseSingleton<ExcelDataTypeLibrary>.Instance.GetParameterTypes().First();

                // don't like this, should find a better way to handle it
                switch (this.configurationModel.SelectedDataType)
                {
                  case Services.StatType.Queryable:
                    QueryableTimeStats queryableTimeStats = rowStats as QueryableTimeStats;
                    rowModel.Cells = new List<CellModel>();
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.AverageTimeMillis,
                      DataMemberName = nameof(queryableTimeStats.AverageTimeMillis),
                      DataType = defaultType,
                      ColumnIndex = 0
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.CategoryType,
                      DataMemberName = nameof(queryableTimeStats.CategoryType),
                      DataType = defaultType,
                      ColumnIndex = 1
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.ContainerSize,
                      DataMemberName = nameof(queryableTimeStats.ContainerSize),
                      DataType = defaultType,
                      ColumnIndex = 2
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.ContainerType,
                      DataMemberName = nameof(queryableTimeStats.ContainerType),
                      DataType = defaultType,
                      ColumnIndex = 3
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.ExecuterName,
                      DataMemberName = nameof(queryableTimeStats.ExecuterName),
                      DataType = defaultType,
                      ColumnIndex = 4
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.FastestTimeMillis,
                      DataMemberName = nameof(queryableTimeStats.FastestTimeMillis),
                      DataType = defaultType,
                      ColumnIndex = 5
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.Iterations,
                      DataMemberName = nameof(queryableTimeStats.Iterations),
                      DataType = defaultType,
                      ColumnIndex = 6
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.MethodName,
                      DataMemberName = nameof(queryableTimeStats.MethodName),
                      DataType = defaultType,
                      ColumnIndex = 7
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.RangeTimeMillis,
                      DataMemberName = nameof(queryableTimeStats.RangeTimeMillis),
                      DataType = defaultType,
                      ColumnIndex = 8
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.SlowestTimeMillis,
                      DataMemberName = nameof(queryableTimeStats.SlowestTimeMillis),
                      DataType = defaultType,
                      ColumnIndex = 9
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.TotalTimeMillis,
                      DataMemberName = nameof(queryableTimeStats.TotalTimeMillis),
                      DataType = defaultType,
                      ColumnIndex = 10
                    });
                    rowModel.Cells.Add(new CellModel()
                    {
                      Value = queryableTimeStats.TriggerType,
                      DataMemberName = nameof(queryableTimeStats.TriggerType),
                      DataType = defaultType,
                      ColumnIndex = 11
                    });
                    break;
                }

                dataClusterModel.Rows.Add(rowModel);
              }

              worksheetModel.DataClusters.Add(dataClusterModel);
            }

            workbookModel.Worksheets.Add(worksheetModel);
          }

          this.ExcelConfiguration.WorkbookModels.Add(workbookModel);
        }
      }
    }

    public void UpdateDataTypeForMember(string memberName, ITypeParameter dataType)
    {
      foreach (WorkbookModel workbook in this.ExcelConfiguration.WorkbookModels)
      {
        foreach (WorksheetModel worksheet in workbook.Worksheets)
        {
          foreach (DataClusterModel dataCluster in worksheet.DataClusters)
          {
            foreach (RowModel row in dataCluster.Rows)
            {
              row.Cells.First(cell => cell.DataMemberName.Equals(memberName)).DataType = dataType;
            }
          }
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
