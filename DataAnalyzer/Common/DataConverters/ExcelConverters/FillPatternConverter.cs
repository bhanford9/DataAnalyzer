using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal class FillPatternConverter
    {
        public static FillPattern ToLocalFillPattern(ExcelService.Styles.Patterns.FillPattern fillPattern)
        {
            return fillPattern switch
            {
                ExcelService.Styles.Patterns.FillPattern.DarkDown => FillPattern.DarkDown,
                ExcelService.Styles.Patterns.FillPattern.DarkGray => FillPattern.DarkGray,
                ExcelService.Styles.Patterns.FillPattern.DarkGrid => FillPattern.DarkGrid,
                ExcelService.Styles.Patterns.FillPattern.DarkHorizontal => FillPattern.DarkHorizontal,
                ExcelService.Styles.Patterns.FillPattern.DarkTrellis => FillPattern.DarkTrellis,
                ExcelService.Styles.Patterns.FillPattern.DarkUp => FillPattern.DarkUp,
                ExcelService.Styles.Patterns.FillPattern.DarkVertical => FillPattern.DarkVertical,
                ExcelService.Styles.Patterns.FillPattern.Gray0625 => FillPattern.Gray0625,
                ExcelService.Styles.Patterns.FillPattern.Gray125 => FillPattern.Gray125,
                ExcelService.Styles.Patterns.FillPattern.LightDown => FillPattern.LightDown,
                ExcelService.Styles.Patterns.FillPattern.LightGray => FillPattern.LightGray,
                ExcelService.Styles.Patterns.FillPattern.LightGrid => FillPattern.LightGrid,
                ExcelService.Styles.Patterns.FillPattern.LightHorizontal => FillPattern.LightHorizontal,
                ExcelService.Styles.Patterns.FillPattern.LightTrellis => FillPattern.LightTrellis,
                ExcelService.Styles.Patterns.FillPattern.LightUp => FillPattern.LightUp,
                ExcelService.Styles.Patterns.FillPattern.LightVertical => FillPattern.LightVertical,
                ExcelService.Styles.Patterns.FillPattern.MediumGray => FillPattern.MediumGray,
                ExcelService.Styles.Patterns.FillPattern.None => FillPattern.None,
                ExcelService.Styles.Patterns.FillPattern.Solid => FillPattern.Solid,
                _ => FillPattern.None,
            };
        }

        public static ExcelService.Styles.Patterns.FillPattern ToExcelFillPattern(FillPattern fillPattern)
        {
            return fillPattern switch
            {
                FillPattern.DarkDown => ExcelService.Styles.Patterns.FillPattern.DarkDown,
                FillPattern.DarkGray => ExcelService.Styles.Patterns.FillPattern.DarkGray,
                FillPattern.DarkGrid => ExcelService.Styles.Patterns.FillPattern.DarkGrid,
                FillPattern.DarkHorizontal => ExcelService.Styles.Patterns.FillPattern.DarkHorizontal,
                FillPattern.DarkTrellis => ExcelService.Styles.Patterns.FillPattern.DarkTrellis,
                FillPattern.DarkUp => ExcelService.Styles.Patterns.FillPattern.DarkUp,
                FillPattern.DarkVertical => ExcelService.Styles.Patterns.FillPattern.DarkVertical,
                FillPattern.Gray0625 => ExcelService.Styles.Patterns.FillPattern.Gray0625,
                FillPattern.Gray125 => ExcelService.Styles.Patterns.FillPattern.Gray125,
                FillPattern.LightDown => ExcelService.Styles.Patterns.FillPattern.LightDown,
                FillPattern.LightGray => ExcelService.Styles.Patterns.FillPattern.LightGray,
                FillPattern.LightGrid => ExcelService.Styles.Patterns.FillPattern.LightGrid,
                FillPattern.LightHorizontal => ExcelService.Styles.Patterns.FillPattern.LightHorizontal,
                FillPattern.LightTrellis => ExcelService.Styles.Patterns.FillPattern.LightTrellis,
                FillPattern.LightUp => ExcelService.Styles.Patterns.FillPattern.LightUp,
                FillPattern.LightVertical => ExcelService.Styles.Patterns.FillPattern.LightVertical,
                FillPattern.MediumGray => ExcelService.Styles.Patterns.FillPattern.MediumGray,
                FillPattern.None => ExcelService.Styles.Patterns.FillPattern.None,
                FillPattern.Solid => ExcelService.Styles.Patterns.FillPattern.Solid,
                _ => ExcelService.Styles.Patterns.FillPattern.None,
            };
        }
    }
}
