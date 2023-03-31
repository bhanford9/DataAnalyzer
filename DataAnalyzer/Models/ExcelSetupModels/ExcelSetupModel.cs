using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.Services.Enums;
using ExcelService.DataActions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal class ExcelSetupModel : BasePropertyChanged, IExcelSetupModel
    {
        private readonly IExcelDataTypeLibrary excelDataTypeLibrary;
        private readonly IStatsModel statsModel;

        public const string DATA_TYPE_UPDATE_KEY = "DATA_TYPE_UPDATE-";

        private IList<ITypeParameter> workingParameterTypes = new List<ITypeParameter>();

        public ExcelSetupModel(
            IStatsModel statsModel,
            IExcelConfigurationModel excelConfigModel,
            IExcelDataTypeLibrary excelDataTypeLibrary)
        {
            this.statsModel = statsModel;
            this.ExcelConfiguration = excelConfigModel;
            this.excelDataTypeLibrary = excelDataTypeLibrary;

            ActionLibrary actionLibrary = new ActionLibrary();

            actionLibrary.GetWorkbookActionInfo()
              .Select(x => ExcelActionConverter.FromExcelActionInfo(x, ExcelEntityType.Workbook))
              .ToList()
              .ForEach(x => this.AvailableWorkbookActions.Add(x));

            actionLibrary.GetWorksheetActionInfo()
              .Select(x => ExcelActionConverter.FromExcelActionInfo(x, ExcelEntityType.Worksheet))
              .ToList()
              .ForEach(x => this.AvailableWorksheetActions.Add(x));

            actionLibrary.GetDataClusterActionInfo()
              .Select(x => ExcelActionConverter.FromExcelActionInfo(x, ExcelEntityType.DataCluster))
              .ToList()
              .ForEach(x => this.AvailableDataClusterActions.Add(x));

            actionLibrary.GetRowActionInfo()
              .Select(x => ExcelActionConverter.FromExcelActionInfo(x, ExcelEntityType.Row))
              .ToList()
              .ForEach(x => this.AvailableRowActions.Add(x));

            actionLibrary.GetCellActionInfo()
              .Select(x => ExcelActionConverter.FromExcelActionInfo(x, ExcelEntityType.Cell))
              .ToList()
              .ForEach(x => this.AvailableCellActions.Add(x));

            // TODO --> add custom saved configuration actions

            this.ExcelConfiguration.PropertyChanged += this.ExcelConfigurationPropertyChanged;
        }

        public IExcelConfigurationModel ExcelConfiguration { get; }

        public ObservableCollection<IExcelAction> AvailableWorkbookActions { get; } = new();

        public ObservableCollection<IExcelAction> AvailableWorksheetActions { get; } = new();

        public ObservableCollection<IExcelAction> AvailableDataClusterActions { get; } = new();

        public ObservableCollection<IExcelAction> AvailableRowActions { get; } = new();

        public ObservableCollection<IExcelAction> AvailableCellActions { get; } = new();

        public IList<ITypeParameter> WorkingParameterTypes
        {
            get => this.workingParameterTypes;
            set => this.NotifyPropertyChanged(ref this.workingParameterTypes, value);
        }

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
                                // TODO --> change this to import/category/flavor (this might help bypass the switch ugliness)
                                // TODO --> create dictionary of potential implementations with ImportExportKey
                                //switch (this.configurationModel.SelectedDataType)
                                //{
                                //    case StatType.Queryable:
                                //        QueryableTimeStats queryableTimeStats = rowStats as QueryableTimeStats;
                                //        rowModel.Cells = new List<CellModel>
                                //        {
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.AverageTimeMillis,
                                //                DataMemberName = nameof(queryableTimeStats.AverageTimeMillis),
                                //                DataType = defaultType,
                                //                ColumnIndex = 0
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.CategoryType,
                                //                DataMemberName = nameof(queryableTimeStats.CategoryType),
                                //                DataType = defaultType,
                                //                ColumnIndex = 1
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.ContainerSize,
                                //                DataMemberName = nameof(queryableTimeStats.ContainerSize),
                                //                DataType = defaultType,
                                //                ColumnIndex = 2
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.ContainerType,
                                //                DataMemberName = nameof(queryableTimeStats.ContainerType),
                                //                DataType = defaultType,
                                //                ColumnIndex = 3
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.ExecuterName,
                                //                DataMemberName = nameof(queryableTimeStats.ExecuterName),
                                //                DataType = defaultType,
                                //                ColumnIndex = 4
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.FastestTimeMillis,
                                //                DataMemberName = nameof(queryableTimeStats.FastestTimeMillis),
                                //                DataType = defaultType,
                                //                ColumnIndex = 5
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.Iterations,
                                //                DataMemberName = nameof(queryableTimeStats.Iterations),
                                //                DataType = defaultType,
                                //                ColumnIndex = 6
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.MethodName,
                                //                DataMemberName = nameof(queryableTimeStats.MethodName),
                                //                DataType = defaultType,
                                //                ColumnIndex = 7
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.RangeTimeMillis,
                                //                DataMemberName = nameof(queryableTimeStats.RangeTimeMillis),
                                //                DataType = defaultType,
                                //                ColumnIndex = 8
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.SlowestTimeMillis,
                                //                DataMemberName = nameof(queryableTimeStats.SlowestTimeMillis),
                                //                DataType = defaultType,
                                //                ColumnIndex = 9
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.TotalTimeMillis,
                                //                DataMemberName = nameof(queryableTimeStats.TotalTimeMillis),
                                //                DataType = defaultType,
                                //                ColumnIndex = 10
                                //            },
                                //            new()
                                //            {
                                //                Value = queryableTimeStats.TriggerType,
                                //                DataMemberName = nameof(queryableTimeStats.TriggerType),
                                //                DataType = defaultType,
                                //                ColumnIndex = 11
                                //            }
                                //        };
                                //        break;
                                //}

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

        public void ApplyTypeParametersToConfig()
        {
            this.WorkingParameterTypes.ToList().ForEach(x => UpdateDataTypeForMember(x.DataName, x));
            this.ExcelConfiguration.ApplyTypeParametersToConfig(this.WorkingParameterTypes);
        }

        public void SaveWorkbookConfiguration(string configName) => this.ExcelConfiguration.SaveWorkbookConfiguration(configName);

        public void BroadcastExcelActionApplied(string actionAppliedKey) => this.NotifyPropertyChanged(actionAppliedKey);

        public void BroadcastExcelDataTypeUpdated(string dataName) => this.NotifyPropertyChanged($"{DATA_TYPE_UPDATE_KEY}{dataName}");

        private void ExcelConfigurationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.ExcelConfiguration.WorkbookModels):
                    this.NotifyPropertyChanged(nameof(this.ExcelConfiguration));
                    break;
                case nameof(this.ExcelConfiguration.LoadedParameterTypes):

                    this.WorkingParameterTypes.Clear();

                    foreach (ITypeParameter param in this.ExcelConfiguration.LoadedParameterTypes)
                    {
                        this.WorkingParameterTypes.Add(this.excelDataTypeLibrary.GetInstanceByName(param.ExcelTypeName));
                        this.WorkingParameterTypes[^1].CloneParameters(param);
                    }

                    this.NotifyPropertyChanged(nameof(this.WorkingParameterTypes));
                    break;
            }
        }
    }
}
