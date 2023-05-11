using ClosedXML.Excel;

namespace ExcelService.Styles.Alignments;

public interface IAlignmentValues
{
    bool DoApplyHorizontal { get; set; }
    bool DoApplyVertical { get; set; }
    HorizontalAlignment HorizontalAlignment { get; set; }
    VerticalAlignment VerticalAlignment { get; set; }

    XLAlignmentHorizontalValues ToXlHorizontalAlignment();
    XLAlignmentVerticalValues ToXlVerticalAlignment();
}