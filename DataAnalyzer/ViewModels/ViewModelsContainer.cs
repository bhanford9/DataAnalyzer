using Autofac;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.ExecutionViewModels;
using DataAnalyzer.ViewModels.ImportViewModels;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System;
using System.Collections.Generic;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels;
using DependencyInjectionUtilities;

namespace DataAnalyzer.ViewModels
{
    internal class ViewModelsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // ViewModels.DataStructureSetupViewModels
            // these are currently single instance due to DataStructureSetupViewModelRepository being a repository
            //   and not a factory. If that needs to change, these will need to move away from being singletons
            builder.RegisterTypeInstance<IConfigurationGroupingViewModel, ConfigurationGroupingViewModel>();
            builder.RegisterTypeInstance<ICsvCSharpStringClassSetupViewModel, CsvCSharpStringClassSetupViewModel>();
            builder.RegisterTypeInstance<IGroupingSetupViewModel, GroupingSetupViewModel>();
            builder.RegisterType<INotSupportedSetupViewModel, NotSupportedSetupViewModel>();
            builder.RegisterTypeInstance<IStringPropertyRowViewModel, StringPropertyRowViewModel>();

            // ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels
            builder.RegisterType<INoParameterDataTypeViewModel, NoParameterDataTypeViewModel>();
            builder.RegisterGeneric(typeof(OneParameterDataTypeViewModel<>)).As(typeof(IOneParameterDataTypeViewModel<>));
            builder.RegisterGeneric(typeof(TwoParameterDataTypeViewModel<,>)).As(typeof(ITwoParameterDataTypeViewModel<,>));

            // ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels
            builder.RegisterType<IActionSummaryExpandableViewModel, ActionSummaryExpandableViewModel>();
            builder.RegisterType<IActionSummaryTreeViewItem, ActionSummaryTreeViewItem>();

            // ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
            builder.RegisterType<IBorderSettingsViewModel, BorderSettingsViewModel>();
            builder.RegisterTypeAncestors<IEditActionViewModel, IAlignmentEditViewModel, AlignmentEditViewModel>();
            builder.RegisterTypeAncestors<IEditActionViewModel, IBackgroundEditViewModel, BackgroundEditViewModel>();
            builder.RegisterTypeAncestors<IEditActionViewModel, IBooleanActionViewModel, BooleanActionViewModel>();
            builder.RegisterTypeAncestors<IEditActionViewModel, IBorderEditViewModel, BorderEditViewModel>();
            builder.RegisterTypeAncestors<IEditActionViewModel, IEmptyEditViewModel, EmptyEditViewModel>();
            // not sure if autofac could do this, so just doing it myself
            builder.RegisterInstance<IEditActionLibrary, EditActionLibrary>(x =>
                new EditActionLibrary(new List<Func<IExcelEntitySpecification, IEditActionViewModel>>
                {
                    x => new EmptyEditViewModel(x),
                    x => new AlignmentEditViewModel(x),
                    x => new BackgroundEditViewModel(x),
                    x => new BorderEditViewModel(x),
                    x => new BooleanActionViewModel(x),
                }));

            // ViewModels.ExcelSetupViewModels.ExcelActionViewModels
            builder.RegisterType<IActionApplicationViewModel, ActionApplicationViewModel>();
            builder.RegisterType<IActionCreationViewModel, ActionCreationViewModel>();
            builder.RegisterType<IActionsSummaryViewModel, ActionsSummaryViewModel>();
            builder.RegisterType<IExcelActionViewModel, ExcelActionViewModel>();

            // ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application
            builder.RegisterTypeAncestors<IActionApplicationViewModel, ICellActionApplicationViewModel, CellActionApplicationViewModel>();
            builder.RegisterTypeAncestors<IActionApplicationViewModel, IDataClusterActionApplicationViewModel, DataClusterActionApplicationViewModel>();
            builder.RegisterTypeAncestors<IActionApplicationViewModel, IRowActionApplicationViewModel, RowActionApplicationViewModel>();
            builder.RegisterTypeAncestors<IActionApplicationViewModel, IWorkbookActionApplicationViewModel, WorkbookActionApplicationViewModel>();
            builder.RegisterTypeAncestors<IActionApplicationViewModel, IWorksheetActionApplicationViewModel, WorksheetActionApplicationViewModel>();

            // ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation
            builder.RegisterTypeAncestors<IActionCreationViewModel, ICellActionCreationViewModel, CellActionCreationViewModel>();
            builder.RegisterTypeAncestors<IActionCreationViewModel, IDataClusterActionCreationViewModel, DataClusterActionCreationViewModel>();
            builder.RegisterTypeAncestors<IActionCreationViewModel, IRowActionCreationViewModel, RowActionCreationViewModel>();
            builder.RegisterTypeAncestors<IActionCreationViewModel, IWorkbookActionCreationViewModel, WorkbookActionCreationViewModel>();
            builder.RegisterTypeAncestors<IActionCreationViewModel, IWorksheetActionCreationViewModel, WorksheetActionCreationViewModel>();

            // ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Summary
            builder.RegisterTypeAncestors<IActionsSummaryViewModel, ICellActionsSummaryViewModel, CellActionsSummaryViewModel>();
            builder.RegisterTypeAncestors<IActionsSummaryViewModel, IDataClusterActionsSummaryViewModel, DataClusterActionsSummaryViewModel>();
            builder.RegisterTypeAncestors<IActionsSummaryViewModel, IRowActionsSummaryViewModel, RowActionsSummaryViewModel>();
            builder.RegisterTypeAncestors<IActionsSummaryViewModel, IWorkbookActionsSummaryViewModel, WorkbookActionsSummaryViewModel>();
            builder.RegisterTypeAncestors<IActionsSummaryViewModel, IWorksheetActionsSummaryViewModel, WorksheetActionsSummaryViewModel>();

            // ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels
            builder.RegisterTypeAncestors<IExcelActionViewModel, ICellActionViewModel, CellActionViewModel>();
            builder.RegisterTypeAncestors<IExcelActionViewModel, IDataClusterActionViewModel, DataClusterActionViewModel>();
            builder.RegisterTypeAncestors<IExcelActionViewModel, IRowActionViewModel, RowActionViewModel>();
            builder.RegisterTypeAncestors<IExcelActionViewModel, IWorkbookActionViewModel, WorkbookActionViewModel>();
            builder.RegisterTypeAncestors<IExcelActionViewModel, IWorksheetActionViewModel, WorksheetActionViewModel>();

            // ViewModels.ExcelSetupViewModels
            builder.RegisterType<IExcelDashboardViewModel, ExcelDashboardViewModel>();
            builder.RegisterType<IExcelDataTypesViewModel, ExcelDataTypesViewModel>();
            builder.RegisterType<IExcelSetupViewModel, ExcelSetupViewModel>();

            // ViewModels.ExecutionViewModels
            builder.RegisterType<IClassCreationSetupViewModel, ClassCreationSetupViewModel>();

            // ViewModels.ImportViewModels
            builder.RegisterType<IImportFromFileViewModel, ImportFromFileViewModel>();

            // ViewModels.Utilities.ExecutiveCommissioners
            builder.RegisterTypeInstance<IExecutionExecutiveCommissioner, ExecutionExecutiveCommissioner>();
            builder.RegisterTypeInstance<IImportExecutiveCommissioner, ImportExecutiveCommissioner>();
            builder.RegisterTypeInstance<IStructureExecutiveCommissioner, StructureExecutiveCommissioner>();
            builder.RegisterInstance<IDataStructureSetupViewModelRepository, DataStructureSetupViewModelRepository>(x =>
            {
                DataStructureSetupViewModelRepository repo = new();
                repo.Initialize();
                return repo;
            });

            // ViewModels.Utilities.LoadableRemovableRows
            builder.RegisterTypeAncestors<IRowViewModel, ILoadableRemovableRowViewModel, IActionApplicationListItemViewModel, ActionApplicationListItemViewModel>();
            builder.RegisterTypeAncestors<IRowViewModel, ILoadableRemovableRowViewModel, IActionCreationListItemViewModel, ActionCreationListItemViewModel>();
            builder.RegisterTypeAncestors<IRowViewModel, ILoadableRemovableRowViewModel, IClassCreationConfigListItemViewModel, ClassCreationConfigListItemViewModel>();
            builder.RegisterTypeAncestors<IRowViewModel, ILoadableRemovableRowViewModel, IConfigurationFileListItemViewModel, ConfigurationFileListItemViewModel>();
            builder.RegisterTypeAncestors<IRowViewModel, ILoadableRemovableRowViewModel, IExcelDataTypeListItemViewModel, ExcelDataTypeListItemViewModel>();
            builder.RegisterTypeAncestors<IRowViewModel, ILoadableRemovableRowViewModel, IWorkbookConfigListItemViewModel, WorkbookConfigListItemViewModel>();

            // ViewModels.Utilities
            builder.RegisterType<ICheckableTreeViewItem, CheckableTreeViewItem>();
            builder.RegisterType<IColorsComboBoxViewModel, ColorsComboBoxViewModel>();
            builder.RegisterType<IColumnSpecificationViewModel, ColumnSpecificationViewModel>();
            builder.RegisterType<IFilePathAndNamePair, FilePathAndNamePair>();
            builder.RegisterType<IPropertyData, PropertyData>();
            builder.RegisterType<IRowSpecificationViewModel, RowSpecificationViewModel>();
            builder.RegisterType<IRowViewModel, RowViewModel>();
            builder.RegisterTypeAncestors<IRowViewModel, ISelectableRemoveableRowViewModel, SelectableRemoveableRowViewModel>();

            // ViewModels
            builder.RegisterType<IApplicationConfigurationViewModel, ApplicationConfigurationViewModel>();
            builder.RegisterType<IConfigurationCreationViewModel, ConfigurationCreationViewModel>();
            builder.RegisterType<IConfigurationExecutionViewModel, ConfigurationExecutionViewModel>();
            builder.RegisterType<IImportConfigurationViewModel, ImportConfigurationViewModel>();
            builder.RegisterType<ILoadedConfigurationItemViewModel, LoadedConfigurationItemViewModel>();
            builder.RegisterType<IMainViewModel, MainViewModel>();
        }
    }
}
