using DataAnalyzer.Services.Enums;
using ServiceStyles = ExcelService.Styles.Borders;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters
{
    internal class BorderTypesConverter
    {
        public static BorderStyle ToLocalBorderStyle(ServiceStyles.BorderStyle borderStyle) => borderStyle switch
        {
            ServiceStyles.BorderStyle.DashDot => BorderStyle.DashDot,
            ServiceStyles.BorderStyle.DashDotDot => BorderStyle.DashDotDot,
            ServiceStyles.BorderStyle.Dashed => BorderStyle.Dashed,
            ServiceStyles.BorderStyle.Dotted => BorderStyle.Dotted,
            ServiceStyles.BorderStyle.Double => BorderStyle.Double,
            ServiceStyles.BorderStyle.Hair => BorderStyle.Hair,
            ServiceStyles.BorderStyle.Medium => BorderStyle.Medium,
            ServiceStyles.BorderStyle.MediumDashDot => BorderStyle.MediumDashDot,
            ServiceStyles.BorderStyle.MediumDashDotDot => BorderStyle.MediumDashDotDot,
            ServiceStyles.BorderStyle.MediumDashed => BorderStyle.MediumDashed,
            ServiceStyles.BorderStyle.None => BorderStyle.None,
            ServiceStyles.BorderStyle.SlantDashDot => BorderStyle.SlantDashDot,
            ServiceStyles.BorderStyle.Thick => BorderStyle.Thick,
            ServiceStyles.BorderStyle.Thin => BorderStyle.Thin,
            _ => BorderStyle.None,
        };

        public static ServiceStyles.BorderStyle ToExcelBorderStyle(BorderStyle borderStyle) => borderStyle switch
        {
            BorderStyle.DashDot => ServiceStyles.BorderStyle.DashDot,
            BorderStyle.DashDotDot => ServiceStyles.BorderStyle.DashDotDot,
            BorderStyle.Dashed => ServiceStyles.BorderStyle.Dashed,
            BorderStyle.Dotted => ServiceStyles.BorderStyle.Dotted,
            BorderStyle.Double => ServiceStyles.BorderStyle.Double,
            BorderStyle.Hair => ServiceStyles.BorderStyle.Hair,
            BorderStyle.Medium => ServiceStyles.BorderStyle.Medium,
            BorderStyle.MediumDashDot => ServiceStyles.BorderStyle.MediumDashDot,
            BorderStyle.MediumDashDotDot => ServiceStyles.BorderStyle.MediumDashDotDot,
            BorderStyle.MediumDashed => ServiceStyles.BorderStyle.MediumDashed,
            BorderStyle.None => ServiceStyles.BorderStyle.None,
            BorderStyle.SlantDashDot => ServiceStyles.BorderStyle.SlantDashDot,
            BorderStyle.Thick => ServiceStyles.BorderStyle.Thick,
            BorderStyle.Thin => ServiceStyles.BorderStyle.Thin,
            _ => ServiceStyles.BorderStyle.None,
        };
    }
}
