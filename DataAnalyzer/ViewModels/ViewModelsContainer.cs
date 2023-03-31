using Autofac;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.ExecutionViewModels;
using DataAnalyzer.ViewModels.ImportViewModels;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels
{
    internal class ViewModelsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // ViewModels.DataStructureSetupViewModels
            builder.RegisterType<IConfigurationGroupingViewModel, ConfigurationGroupingViewModel>();
            builder.RegisterType<ICsvCSharpStringClassSetupViewModel, CsvCSharpStringClassSetupViewModel>();
            builder.RegisterType<IGroupingSetupViewModel, GroupingSetupViewModel>();
            builder.RegisterType<INotSupportedSetupViewModel, NotSupportedSetupViewModel>();
            builder.RegisterType<IStringPropertyRowViewModel, StringPropertyRowViewModel>();

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
                new EditActionLibrary(new List<Func<ExcelEntityType, IEditActionViewModel>>
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

            // ViewModels.ExcelSetupViewModels
            builder.RegisterType<IExcelDashboardViewModel, ExcelDashboardViewModel>();
            builder.RegisterType<IExcelDataTypesViewModel, ExcelDataTypesViewModel>();
            builder.RegisterType<IExcelSetupViewModel, ExcelSetupViewModel>();

            // ViewModels.ExecutionViewModels
            builder.RegisterType<IClassCreationSetupViewModel, ClassCreationSetupViewModel>();

            // ViewModels.ImportViewModels
            builder.RegisterType<IImportFromFileViewModel, ImportFromFileViewModel>();

            // ViewModels.Utilities.ExecutiveCommissioners
            builder.RegisterType<IExecutionExecutiveCommissioner, ExecutionExecutiveCommissioner>();
            builder.RegisterType<IImportExecutiveCommissioner, ImportExecutiveCommissioner>();
            builder.RegisterType<IStructureExecutiveCommissioner, StructureExecutiveCommissioner>();

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
