using ClosedXML.Excel;
using ExcelService.Styles.Colors;

namespace ExcelService.Styles.Borders
{
    public interface IBorder
    {
        ColorValue Color { get; set; }
        bool DoApply { get; set; }
        BorderStyle Style { get; set; }

        XLBorderStyleValues ToXlBorderStyle();
    }
}