using Autofac;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;
using DataAnalyzer.Models.ImportModels;
using DataAnalyzer.Models.LoadedConfigurations;
using DataScraper;
using DependencyInjectionUtilities;

namespace DataAnalyzer.Models
{
    internal class ModelsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // Models.DataStructureSetupModels
            builder.RegisterType<ICsvCSharpStringClassSetupModel, CsvCSharpStringClassSetupModel>();
            builder.RegisterType<IGroupingSetupModel, GroupingSetupModel>();
            builder.RegisterType<INotSupportedSetupModel, NotSupportedSetupModel>();

            // Models.ExcelSetupModels.ExcelActionModels.Application
            builder.RegisterTypeAncestors<IExcelActionModel, IActionApplicationModel, ICellActionApplicationModel, CellActionApplicationModel>();
            builder.RegisterTypeAncestors<IExcelActionModel, IActionApplicationModel, IDataClusterActionApplicationModel, DataClusterActionApplicationModel>();
            builder.RegisterTypeAncestors<IExcelActionModel, IActionApplicationModel, IRowActionApplicationModel, RowActionApplicationModel>();
            builder.RegisterTypeAncestors<IExcelActionModel, IActionApplicationModel, IWorkbookActionApplicationModel, WorkbookActionApplicationModel>();
            builder.RegisterTypeAncestors<IExcelActionModel, IActionApplicationModel, IWorksheetActionApplicationModel, WorksheetActionApplicationModel>();

            // Models.ExcelSetupModels.ExcelActionModels.Creation
            builder.RegisterTypeAncestors<IExcelActionModel, IActionCreationModel, ICellActionCreationModel, CellActionCreationModel>();
            builder.RegisterTypeAncestors<IExcelActionModel, IActionCreationModel, IDataClusterActionCreationModel, DataClusterActionCreationModel>();
            builder.RegisterTypeAncestors<IExcelActionModel, IActionCreationModel, IRowActionCreationModel, RowActionCreationModel>();
            builder.RegisterTypeAncestors<IExcelActionModel, IActionCreationModel, IWorkbookActionCreationModel, WorkbookActionCreationModel>();
            builder.RegisterTypeAncestors<IExcelActionModel, IActionCreationModel, IWorksheetActionCreationModel, WorksheetActionCreationModel>();

            // Models.ExcelSetupModels.ExcelActionModels.Summary.Items
            builder.RegisterTypeAncestors<ISummaryItem, IAlignmentSummaryItem, AlignmentSummaryItem>();
            builder.RegisterTypeAncestors<ISummaryItem, IBackgroundSummaryItem, BackgroundSummaryItem>();
            builder.RegisterTypeAncestors<ISummaryItem, IBooleanOperationSummaryItem, BooleanOperationSummaryItem>();
            builder.RegisterTypeAncestors<ISummaryItem, IBorderSummaryItem, BorderSummaryItem>();

            // Models.ExcelSetupModels.ExcelActionModels.Summary
            builder.RegisterTypeAncestors<IActionsSummaryModel, ICellActionsSummaryModel, CellActionsSummaryModel>();
            builder.RegisterTypeAncestors<IActionsSummaryModel, IDataClusterActionsSummaryModel, DataClusterActionsSummaryModel>();
            builder.RegisterTypeAncestors<IActionsSummaryModel, IRowActionsSummaryModel, RowActionsSummaryModel>();
            builder.RegisterTypeAncestors<IActionsSummaryModel, IWorkbookActionsSummaryModel, WorkbookActionsSummaryModel>();
            builder.RegisterTypeAncestors<IActionsSummaryModel, IWorksheetActionsSummaryModel, WorksheetActionsSummaryModel>();

            // Models.ExcelSetupModels.ExcelActionParameters
            builder.RegisterTypeAncestors<IActionParameters, IAlignmentParameters, AlignmentParameters>();
            builder.RegisterTypeAncestors<IActionParameters, IBackgroundParameters, BackgroundParameters>();
            builder.RegisterTypeAncestors<IActionParameters, IBooleanOperationParameters, BooleanOperationParameters>();
            builder.RegisterTypeAncestors<IActionParameters, IBorderParameters, BorderParameters>();
            builder.RegisterType<IColumnSpecificationParameters, ColumnSpecificationParameters>();
            builder.RegisterTypeAncestors<IActionParameters, IEmptyParameters, EmptyParameters>();
            builder.RegisterType<IRowSpecificationParameters, RowSpecificationParameters>();

            // Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
            builder.RegisterTypeAncestors<ITypeParameter, IIntegerTypeParameter, IIntegerBooleanTypeParameter, IntegerBooleanTypeParameter>();
            builder.RegisterTypeAncestors<ITypeParameter, IIntegerIntegerTypeParameter, IntegerIntegerTypeParameter>();
            builder.RegisterTypeAncestors<ITypeParameter, IIntegerTypeParameter, IntegerTypeParameter>();
            builder.RegisterTypeAncestors<ITypeParameter, INoTypeParameter, NoTypeParameter>();

            // Models.ExcelSetupModels.ExcelDataTypeModels
            builder.RegisterType<IExcelDataTypeLibrary, ExcelDataTypeLibrary>();

            // Models.ExcelSetupModels.ExcelServiceConfigurations
            builder.RegisterType<ICellModel, CellModel>();
            builder.RegisterType<IDataClusterModel, DataClusterModel>();
            builder.RegisterType<IWorkbookModel, WorkbookModel>();
            builder.RegisterType<IWorksheetModel, WorksheetModel>();

            // Models.ExcelSetupModels
            builder.RegisterType<IExcelConfigurationModel, ExcelConfigurationModel>();
            builder.RegisterType<IExcelSetupModel, ExcelSetupModel>();
            builder.RegisterType<ILastSavedConfiguration, LastSavedConfiguration>();

            // Models.ExecutionModels.ClassCretionModels.SerializationModels
            builder.RegisterType<IClassProperties, ClassProperties>();
            builder.RegisterType<IClassPropertyData, ClassPropertyData>();

            // Models.ExecutionModels.ClassCretionModels
            builder.RegisterType<IClassCreationConfigurationModel, ClassCreationConfigurationModel>();
            builder.RegisterType<IClassCreationSetupModel, ClassCreationSetupModel>();

            // Models.ImportModels
            builder.RegisterTypeAncestors<IFlavoredCategorizedDataLibrary<string>, IFileMap, FileMap>();
            builder.RegisterTypeAncestors<IImportModel, IImportFromFileModel, ImportFromFileModel>();
            builder.RegisterType<IImportModel, ImportModel>();

            // Models.LoadedConfigurations
            builder.RegisterType<ILoadedDataContent, LoadedDataContent>();
            builder.RegisterType<ILoadedDataStructure, LoadedDataStructure>();
            builder.RegisterType<ILoadedInputFiles, LoadedInputFiles>();

            // Models
            builder.RegisterTypeInstance<IConfigurationModel, ConfigurationModel>();
            builder.RegisterTypeInstance<IMainModel, MainModel>();
            builder.RegisterTypeInstance<IStatsModel, StatsModel>();
        }
    }
}
