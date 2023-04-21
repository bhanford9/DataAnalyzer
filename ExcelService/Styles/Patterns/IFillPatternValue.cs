using ClosedXML.Excel;
using ExcelService.Styles.Colors;

namespace ExcelService.Styles.Patterns
{
    public interface IFillPatternValue
    {
        ColorValue Color { get; set; }
        bool DoApply { get; set; }
        FillPattern Type { get; set; }

        XLFillPatternValues ToXlFromLocal();
    }
}