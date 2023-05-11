using Autofac;
using DependencyInjectionUtilities;
using ExcelService.CellDataFormats;
using ExcelService.CellDataFormats.NumericFormat;
using ExcelService.CellDataFormats.NumericFormat.Dates;
using ExcelService.DataActions;
using ExcelService.DataActions.ActionParameters;
using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;
using ExcelService.DataActions.ActionParameters.ClusterStyleParameters;
using ExcelService.DataActions.ActionParameters.InserterParameters;
using ExcelService.DataActions.ActionParameters.RangeStyleParameters;
using ExcelService.DataActions.ActionParameters.WorkbookParameters;
using ExcelService.DataActions.ClusterActions;
using ExcelService.DataActions.RowActions;
using ExcelService.DataActions.SharedActions;
using ExcelService.DataActions.WorkbookActions;
using ExcelService.DataClusters;
using ExcelService.ReturnMessages;
using ExcelService.Rows;
using ExcelService.Styles.Alignments;
using ExcelService.Styles.Borders;
using ExcelService.Styles.Colors;
using ExcelService.Styles.Patterns;
using ExcelService.Utilities;
using ExcelService.Workbooks;
using ExcelService.Worksheets;
using System.Reflection;

namespace ExcelService;

public class ExcelSerivceContainer
{
    public static void Register(ContainerBuilder builder)
    {
        // ExcelService.CellDataFormats.NumericFormat.Dates
        builder.RegisterTypeAncestors<ICellDataFormat, IDashDateCellDataFormat, DashDateCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, IDateAndTimeCellDataFormat, DateAndTimeCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, IDayOfWeekCellDataFormat, DayOfWeekCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, IPreciseTimeCellDataFormat, PreciseTimeCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, ISlashDateCellDataFormat, SlashDateCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, ITimeMeridiemCellDataFormat, TimeMeridiemCellDataFormat>();

        // ExcelService.CellDataFormats.NumericFormat
        builder.RegisterTypeAncestors<ICellDataFormat, IFloatingPrecisionCellDataFormat, FloatingPrecisionCellDataFormat>()
            .WithParameter("precisionCount", 0);
        builder.RegisterTypeAncestors<ICellDataFormat, IFloatingPrecisionWithSeparatorCellDataFormat, FloatingPrecisionWithSeparatorCellDataFormat>()
            .WithParameter("precisionCount", 0);
        builder.RegisterTypeAncestors<ICellDataFormat, IFloatingSeparatorParensCellDataFormat, FloatingSeparatorParensCellDataFormat>()
            .WithParameter("precisionCount", 0)
            .WithParameter("colorRed", false);
        builder.RegisterTypeAncestors<ICellDataFormat, IFractionCellDataFormat, FractionCellDataFormat>()
            .WithParameter("precisionCount", 1);
        builder.RegisterTypeAncestors<ICellDataFormat, IGeneralNumericCellDataFormat, GeneralNumericCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, IIntegerCellDataFormat, IntegerCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, IIntegerSeparatorParensCellDataFormat, IntegerSeparatorParensCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, IIntegerWIthSeparatorCellDataFormat, IntegerWIthSeparatorCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, INumericAsStringCellDataFormat, NumericAsStringCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, IPercentFloatingPrecisionCellDataFormat, PercentFloatingPrecisionCellDataFormat>()
            .WithParameter("precisionCount", 0);
        builder.RegisterTypeAncestors<ICellDataFormat, IPercentIntegerCellDataFormat, PercentIntegerCellDataFormat>();
        builder.RegisterTypeAncestors<ICellDataFormat, IScientificFloatingPrecisionCellDataFormat, ScientificFloatingPrecisionCellDataFormat>()
            .WithParameter("precisionCount", 0);
        builder.RegisterTypeAncestors<ICellDataFormat, IZeroPrependFloatingPrecisionCellDataFormat, ZeroPrependFloatingPrecisionCellDataFormat>()
            .WithParameter("zerosPrepended", 0)
            .WithParameter("precisionCount", 0);
        builder.RegisterTypeAncestors<ICellDataFormat, IZeroPrependIntegerCellDataFormat, ZeroPrependIntegerCellDataFormat>()
            .WithParameter("zerosPrepended", 0);

        // ExcelService.CellDataFormats
        builder.RegisterType<ICellDataFormatLibrary, CellDataFormatLibrary>();
        builder.RegisterTypeAncestors<ICellDataFormat, ITextCellDataFormat, TextCellDataFormat>();

        // ExcelService.Cells
        // probably never injected anywhere
        //builder.RegisterTypeAncestors<IExcelEntity, ICell, Cell>();

        // ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters
        builder.RegisterTypeAncestors<IActionParameters, IBackgroundStyleParameters, IHeaderBackgroundStyleParameters, HeaderBackgroundStyleParameters>();
        builder.RegisterTypeAncestors<IActionParameters, IBorderStyleParameters, IHeaderBorderStyleParameters, HeaderBorderStyleParameters>();
        builder.RegisterTypeAncestors<IActionParameters, IHeaderMergeCenterFullParameters, HeaderMergeCenterFullParameters>();

        // ExcelService.DataActions.ActionParameters.ClusterStyleParameters
        builder.RegisterTypeAncestors<IActionParameters, IAlignmentStyleParameters, INthRowAlignmentStyleParameters, NthRowAlignmentStyleParameters>();
        builder.RegisterTypeAncestors<IActionParameters, IBorderStyleParameters, INthRowBorderStyleParameters, NthRowBorderStyleParameters>();

        // ExcelService.DataActions.ActionParameters.InserterParameters
        builder.RegisterTypeAncestors<IActionParameters, IInsertMergeCenteredParameters, InsertMergeCenteredParameters>();

        // ExcelService.DataActions.ActionParameters.RangeStyleParameters
        builder.RegisterTypeAncestors<IActionParameters, IAlignmentStyleParameters, AlignmentStyleParameters>();
        builder.RegisterTypeAncestors<IActionParameters, IBackgroundStyleParameters, BackgroundStyleParameters>();
        builder.RegisterTypeAncestors<IActionParameters, IBorderStyleParameters, BorderStyleParameters>();
        builder.RegisterTypeAncestors<IActionParameters, IColumnBorderStyleParameters, ColumnBorderStyleParameters>();

        // ExcelService.DataActions.ActionParameters.WorkbookParameters
        builder.RegisterTypeAncestors<IActionParameters, IDisplayWorkbookParameters, DisplayWorkbookParameters>();

        // ExcelService.DataActions.ActionParameters
        builder.RegisterTypeAncestors<ICollection<IActionParameters>, IActionDefinitions, ActionDefinitions>();

        // ExcelService.DataActions.CellActions

        // ExcelService.DataActions.ClusterActions
        builder.RegisterTypeAncestors<IDataAction, IBackgroundStyleAction, IHeaderBackgroundStyleAction, HeaderBackgroundStyleAction>();
        builder.RegisterTypeAncestors<IDataAction, IBorderStyleAction, IHeaderBorderStyleAction, HeaderBorderStyleAction>();
        builder.RegisterTypeAncestors<IDataAction, IHeaderMergeCenterFullAction, HeaderMergeCenterFullAction>();

        // ExcelService.DataActions.RowActions
        builder.RegisterTypeAncestors<IDataAction, IInsertMergeCentered, InsertMergeCentered>();

        // ExcelService.DataActions.SharedActions
        builder.RegisterTypeAncestors<IDataAction, IAlignmentStyleAction, AlignmentStyleAction>();
        builder.RegisterTypeAncestors<IDataAction, IBackgroundStyleAction, BackgroundStyleAction>();
        builder.RegisterTypeAncestors<IDataAction, IBorderStyleAction, BorderStyleAction>();

        // ExcelService.DataActions.WorkbookActions
        builder.RegisterTypeAncestors<IDataAction, IDisplayWorkbookAction, DisplayWorkbookAction>();

        // ExcelService.DataActions.WorksheetActions

        // ExcelService.DataActions
        builder
            .RegisterType<IActionExecutive, ActionExecutive>()
            .FindConstructorsWith(type => type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic));
        builder
            .RegisterAs<IInternalActionLibrary, ActionLibrary>(context =>
            {
                IReadOnlyCollection<IDataAction> GetWorkbookActions() =>
                    new HashSet<IDataAction>
                    {
                        Resolver.Resolve<IDisplayWorkbookAction>()
                    };


                IReadOnlyCollection<IDataAction> GetWorksheetActions() =>
                    new HashSet<IDataAction>
                    {
                    };

                IReadOnlyCollection<IDataAction> GetDataClusterActions() =>
                    new HashSet<IDataAction>
                    {
                        Resolver.Resolve<IHeaderBorderStyleAction>(),
                        Resolver.Resolve<IHeaderMergeCenterFullAction>(),
                        Resolver.Resolve<IHeaderBackgroundStyleAction>(),

                        Resolver.Resolve<IBorderStyleAction>(),
                        Resolver.Resolve<IBackgroundStyleAction>(),
                        Resolver.Resolve<IAlignmentStyleAction>(),
                    };

                IReadOnlyCollection<IDataAction> GetRowActions() =>
                    new HashSet<IDataAction>
                    {
                        Resolver.Resolve<IBorderStyleAction>(),
                        Resolver.Resolve<IBackgroundStyleAction>(),
                        Resolver.Resolve<IAlignmentStyleAction>(),
                    };

                IReadOnlyCollection<IDataAction> GetCellActions() =>
                    new HashSet<IDataAction>
                    {
                        Resolver.Resolve<IBorderStyleAction>(),
                        Resolver.Resolve<IBackgroundStyleAction>(),
                        Resolver.Resolve<IAlignmentStyleAction>(),
                    };

                return new ActionLibrary(
                    GetWorkbookActions(),
                    GetWorksheetActions(),
                    GetDataClusterActions(),
                    GetRowActions(),
                    GetCellActions());
            })
            .As<IActionLibrary>()
            .As<IActionLookup>();

        // ExcelService.DataClusters
        builder.RegisterTypeAncestors<IExcelEntity, IDataCluster, DataCluster>();
        builder.RegisterTypeAncestors<IExcelEntity, IDataCluster, IUniformDataCluster, UniformDataCluster>();

        // ExcelService.ReturnMessages
        builder.RegisterType<IActionStatus, ActionStatus>();

        // ExcelService.Rows
        builder.RegisterTypeAncestors<IExcelEntity, IRow, Row>();

        // ExcelService.Styles.Alignments
        builder.RegisterType<IAlignmentValues, AlignmentValues>();

        // ExcelService.Styles.Borders
        builder.RegisterType<IBorder, Border>();

        // ExcelService.Styles.Colors
        builder.RegisterType<IColorValue, ColorValue>();

        // ExcelService.Styles.Patterns
        builder.RegisterType<IFillPatternValue, FillPatternValue>();

        // ExcelService.Utilities
        builder.RegisterType<IColumnRowSpecification,  ColumnRowSpecification>();
        builder.RegisterType<IColumnSpecification, ColumnSpecification>();
        builder.RegisterType<IRowSpecification, RowSpecification>();

        // ExcelService.Workbooks
        builder.RegisterTypeAncestors<IExcelEntity, IWorkbook, IAddInWorkbook, AddInWorkbook>();
        builder.RegisterTypeAncestors<IExcelEntity, IWorkbook, IMacroEnabledTemplateWorkbook, MacroEnabledTemplateWorkbook>();
        builder.RegisterTypeAncestors<IExcelEntity, IWorkbook, IMacroEnabledWorkbook, MacroEnabledWorkbook>();
        builder.RegisterTypeAncestors<IExcelEntity, IWorkbook, IStandardWorkbook, StandardWorkbook>();
        builder.RegisterTypeAncestors<IExcelEntity, IWorkbook, ITemplateWorkbook, TemplateWorkbook>();

        // ExcelService.Worksheets
        builder.RegisterTypeAncestors<IExcelEntity, IWorksheet, Worksheet>();

        // ExcelSErvice
        builder.RegisterType<IExcelEntity, ExcelEntity>();
        builder.RegisterType<IExcelExecutive, ExcelExecutive>();
        builder.RegisterType<IOpenXmlExcelExecutive, OpenXmlExcelExecutive>();
    }
}
