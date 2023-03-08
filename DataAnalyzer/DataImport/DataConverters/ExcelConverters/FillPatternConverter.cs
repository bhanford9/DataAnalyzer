using DataAnalyzer.Services.Enums;
using ServiceStyles = ExcelService.Styles.Patterns;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters
{
    internal class FillPatternConverter
    {
        public static FillPattern ToLocalFillPattern(ExcelService.Styles.Patterns.FillPattern fillPattern) => fillPattern switch
        {
            ServiceStyles.FillPattern.DarkDown => FillPattern.DarkDown,
            ServiceStyles.FillPattern.DarkGray => FillPattern.DarkGray,
            ServiceStyles.FillPattern.DarkGrid => FillPattern.DarkGrid,
            ServiceStyles.FillPattern.DarkHorizontal => FillPattern.DarkHorizontal,
            ServiceStyles.FillPattern.DarkTrellis => FillPattern.DarkTrellis,
            ServiceStyles.FillPattern.DarkUp => FillPattern.DarkUp,
            ServiceStyles.FillPattern.DarkVertical => FillPattern.DarkVertical,
            ServiceStyles.FillPattern.Gray0625 => FillPattern.Gray0625,
            ServiceStyles.FillPattern.Gray125 => FillPattern.Gray125,
            ServiceStyles.FillPattern.LightDown => FillPattern.LightDown,
            ServiceStyles.FillPattern.LightGray => FillPattern.LightGray,
            ServiceStyles.FillPattern.LightGrid => FillPattern.LightGrid,
            ServiceStyles.FillPattern.LightHorizontal => FillPattern.LightHorizontal,
            ServiceStyles.FillPattern.LightTrellis => FillPattern.LightTrellis,
            ServiceStyles.FillPattern.LightUp => FillPattern.LightUp,
            ServiceStyles.FillPattern.LightVertical => FillPattern.LightVertical,
            ServiceStyles.FillPattern.MediumGray => FillPattern.MediumGray,
            ServiceStyles.FillPattern.None => FillPattern.None,
            ServiceStyles.FillPattern.Solid => FillPattern.Solid,
            _ => FillPattern.None,
        };

        public static ExcelService.Styles.Patterns.FillPattern ToExcelFillPattern(FillPattern fillPattern) => fillPattern switch
        {
            FillPattern.DarkDown => ServiceStyles.FillPattern.DarkDown,
            FillPattern.DarkGray => ServiceStyles.FillPattern.DarkGray,
            FillPattern.DarkGrid => ServiceStyles.FillPattern.DarkGrid,
            FillPattern.DarkHorizontal => ServiceStyles.FillPattern.DarkHorizontal,
            FillPattern.DarkTrellis => ServiceStyles.FillPattern.DarkTrellis,
            FillPattern.DarkUp => ServiceStyles.FillPattern.DarkUp,
            FillPattern.DarkVertical => ServiceStyles.FillPattern.DarkVertical,
            FillPattern.Gray0625 => ServiceStyles.FillPattern.Gray0625,
            FillPattern.Gray125 => ServiceStyles.FillPattern.Gray125,
            FillPattern.LightDown => ServiceStyles.FillPattern.LightDown,
            FillPattern.LightGray => ServiceStyles.FillPattern.LightGray,
            FillPattern.LightGrid => ServiceStyles.FillPattern.LightGrid,
            FillPattern.LightHorizontal => ServiceStyles.FillPattern.LightHorizontal,
            FillPattern.LightTrellis => ServiceStyles.FillPattern.LightTrellis,
            FillPattern.LightUp => ServiceStyles.FillPattern.LightUp,
            FillPattern.LightVertical => ServiceStyles.FillPattern.LightVertical,
            FillPattern.MediumGray => ServiceStyles.FillPattern.MediumGray,
            FillPattern.None => ServiceStyles.FillPattern.None,
            FillPattern.Solid => ServiceStyles.FillPattern.Solid,
            _ => ServiceStyles.FillPattern.None,
        };
    }
}
