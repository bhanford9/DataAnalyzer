namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal class BorderTypesConverter
    {
        public static Services.BorderStyle ToLocalBorderStyle(ExcelService.Styles.Borders.BorderStyle borderStyle)
        {
            return borderStyle switch
            {
                ExcelService.Styles.Borders.BorderStyle.DashDot => Services.BorderStyle.DashDot,
                ExcelService.Styles.Borders.BorderStyle.DashDotDot => Services.BorderStyle.DashDotDot,
                ExcelService.Styles.Borders.BorderStyle.Dashed => Services.BorderStyle.Dashed,
                ExcelService.Styles.Borders.BorderStyle.Dotted => Services.BorderStyle.Dotted,
                ExcelService.Styles.Borders.BorderStyle.Double => Services.BorderStyle.Double,
                ExcelService.Styles.Borders.BorderStyle.Hair => Services.BorderStyle.Hair,
                ExcelService.Styles.Borders.BorderStyle.Medium => Services.BorderStyle.Medium,
                ExcelService.Styles.Borders.BorderStyle.MediumDashDot => Services.BorderStyle.MediumDashDot,
                ExcelService.Styles.Borders.BorderStyle.MediumDashDotDot => Services.BorderStyle.MediumDashDotDot,
                ExcelService.Styles.Borders.BorderStyle.MediumDashed => Services.BorderStyle.MediumDashed,
                ExcelService.Styles.Borders.BorderStyle.None => Services.BorderStyle.None,
                ExcelService.Styles.Borders.BorderStyle.SlantDashDot => Services.BorderStyle.SlantDashDot,
                ExcelService.Styles.Borders.BorderStyle.Thick => Services.BorderStyle.Thick,
                ExcelService.Styles.Borders.BorderStyle.Thin => Services.BorderStyle.Thin,
                _ => Services.BorderStyle.None,
            };
        }

        public static ExcelService.Styles.Borders.BorderStyle ToExcelBorderStyle(Services.BorderStyle borderStyle)
        {
            return borderStyle switch
            {
                Services.BorderStyle.DashDot => ExcelService.Styles.Borders.BorderStyle.DashDot,
                Services.BorderStyle.DashDotDot => ExcelService.Styles.Borders.BorderStyle.DashDotDot,
                Services.BorderStyle.Dashed => ExcelService.Styles.Borders.BorderStyle.Dashed,
                Services.BorderStyle.Dotted => ExcelService.Styles.Borders.BorderStyle.Dotted,
                Services.BorderStyle.Double => ExcelService.Styles.Borders.BorderStyle.Double,
                Services.BorderStyle.Hair => ExcelService.Styles.Borders.BorderStyle.Hair,
                Services.BorderStyle.Medium => ExcelService.Styles.Borders.BorderStyle.Medium,
                Services.BorderStyle.MediumDashDot => ExcelService.Styles.Borders.BorderStyle.MediumDashDot,
                Services.BorderStyle.MediumDashDotDot => ExcelService.Styles.Borders.BorderStyle.MediumDashDotDot,
                Services.BorderStyle.MediumDashed => ExcelService.Styles.Borders.BorderStyle.MediumDashed,
                Services.BorderStyle.None => ExcelService.Styles.Borders.BorderStyle.None,
                Services.BorderStyle.SlantDashDot => ExcelService.Styles.Borders.BorderStyle.SlantDashDot,
                Services.BorderStyle.Thick => ExcelService.Styles.Borders.BorderStyle.Thick,
                Services.BorderStyle.Thin => ExcelService.Styles.Borders.BorderStyle.Thin,
                _ => ExcelService.Styles.Borders.BorderStyle.None,
            };
        }
    }
}
