using Autofac;
using DependencyInjectionUtilities;
using ExcelService.CellDataFormats;
using ExcelService.CellDataFormats.NumericFormat;
using ExcelService.CellDataFormats.NumericFormat.Dates;
using ExcelService.Cells;

namespace ExcelService
{
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
            // ExcelService.DataActions.ActionParameters.ClusterStyleParameters
            // ExcelService.DataActions.ActionParameters.InserterParameters
            // ExcelService.DataActions.ActionParameters.RangeStyleParameters
            // ExcelService.DataActions.ActionParameters.WorkbookParameters
            // ExcelService.DataActions.ActionParameters
            // ExcelService.DataActions.CellActions
            // ExcelService.DataActions.ClusterActions
            // ExcelService.DataActions.RowActions
            // ExcelService.DataActions.SharedActions
            // ExcelService.DataActions.WorkbookActions
            // ExcelService.DataActions.WorksheetActions
            // ExcelService.DataActions
            // ExcelService.DataClusters
            // ExcelService.ReturnMessages
            // ExcelService.Rows
            // ExcelService.Styles.Alignments
            // ExcelService.Styles.Borders
            // ExcelService.Styles.Colors
            // ExcelService.Styles.Patters
            // ExcelService.Utilities
            // ExcelService.Workbooks
            // ExcelService.Worksheets
            // ExcelSErvice
        }
    }
}
