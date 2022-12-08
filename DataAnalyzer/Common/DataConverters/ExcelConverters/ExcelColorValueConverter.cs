using ExcelService.Styles.Colors;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal class ExcelColorValueConverter
    {
        public static ColorValue ToExcelColorValue(System.Drawing.Color color)
        {
            return new ColorValue(color.A, color.R, color.G, color.B);
        }
    }
}
