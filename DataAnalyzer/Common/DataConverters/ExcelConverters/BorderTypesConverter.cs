using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal class BorderTypesConverter
    {
        public static BorderStyle ToLocalBorderStyle(ExcelService.Styles.Borders.BorderStyle borderStyle)
        {
            return borderStyle switch
            {
                ExcelService.Styles.Borders.BorderStyle.DashDot => BorderStyle.DashDot,
                ExcelService.Styles.Borders.BorderStyle.DashDotDot => BorderStyle.DashDotDot,
                ExcelService.Styles.Borders.BorderStyle.Dashed => BorderStyle.Dashed,
                ExcelService.Styles.Borders.BorderStyle.Dotted => BorderStyle.Dotted,
                ExcelService.Styles.Borders.BorderStyle.Double => BorderStyle.Double,
                ExcelService.Styles.Borders.BorderStyle.Hair => BorderStyle.Hair,
                ExcelService.Styles.Borders.BorderStyle.Medium => BorderStyle.Medium,
                ExcelService.Styles.Borders.BorderStyle.MediumDashDot => BorderStyle.MediumDashDot,
                ExcelService.Styles.Borders.BorderStyle.MediumDashDotDot => BorderStyle.MediumDashDotDot,
                ExcelService.Styles.Borders.BorderStyle.MediumDashed => BorderStyle.MediumDashed,
                ExcelService.Styles.Borders.BorderStyle.None => BorderStyle.None,
                ExcelService.Styles.Borders.BorderStyle.SlantDashDot => BorderStyle.SlantDashDot,
                ExcelService.Styles.Borders.BorderStyle.Thick => BorderStyle.Thick,
                ExcelService.Styles.Borders.BorderStyle.Thin => BorderStyle.Thin,
                _ => BorderStyle.None,
            };
        }

        public static ExcelService.Styles.Borders.BorderStyle ToExcelBorderStyle(BorderStyle borderStyle)
        {
            return borderStyle switch
            {
                BorderStyle.DashDot => ExcelService.Styles.Borders.BorderStyle.DashDot,
                BorderStyle.DashDotDot => ExcelService.Styles.Borders.BorderStyle.DashDotDot,
                BorderStyle.Dashed => ExcelService.Styles.Borders.BorderStyle.Dashed,
                BorderStyle.Dotted => ExcelService.Styles.Borders.BorderStyle.Dotted,
                BorderStyle.Double => ExcelService.Styles.Borders.BorderStyle.Double,
                BorderStyle.Hair => ExcelService.Styles.Borders.BorderStyle.Hair,
                BorderStyle.Medium => ExcelService.Styles.Borders.BorderStyle.Medium,
                BorderStyle.MediumDashDot => ExcelService.Styles.Borders.BorderStyle.MediumDashDot,
                BorderStyle.MediumDashDotDot => ExcelService.Styles.Borders.BorderStyle.MediumDashDotDot,
                BorderStyle.MediumDashed => ExcelService.Styles.Borders.BorderStyle.MediumDashed,
                BorderStyle.None => ExcelService.Styles.Borders.BorderStyle.None,
                BorderStyle.SlantDashDot => ExcelService.Styles.Borders.BorderStyle.SlantDashDot,
                BorderStyle.Thick => ExcelService.Styles.Borders.BorderStyle.Thick,
                BorderStyle.Thin => ExcelService.Styles.Borders.BorderStyle.Thin,
                _ => ExcelService.Styles.Borders.BorderStyle.None,
            };
        }
    }
}
