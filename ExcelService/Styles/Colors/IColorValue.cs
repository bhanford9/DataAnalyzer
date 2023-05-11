using ClosedXML.Excel;

namespace ExcelService.Styles.Colors;

public interface IColorValue
{
    System.Drawing.Color ToSystemColor();
    XLColor ToXlColor(Color color);
    XLColor ToXlColorFromArgb();
    XLColor ToXlColorFromLocal();
}