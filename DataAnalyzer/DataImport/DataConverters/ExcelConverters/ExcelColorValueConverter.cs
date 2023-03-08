using ExcelService.Styles.Colors;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters
{
    internal class ExcelColorValueConverter
    {
        public static ColorValue ToExcelColorValue(System.Drawing.Color color) => new ColorValue(color.A, color.R, color.G, color.B);
    }
}
