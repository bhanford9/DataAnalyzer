using ClosedXML.Excel;

namespace ExcelService.Styles.Alignments;

public class AlignmentValues : IAlignmentValues
{
    private HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
    private VerticalAlignment verticalAlignment = VerticalAlignment.Center;

    public HorizontalAlignment HorizontalAlignment
    {
        get => this.horizontalAlignment;
        set
        {
            this.horizontalAlignment = value;
            this.DoApplyHorizontal = true;
        }
    }

    public VerticalAlignment VerticalAlignment
    {
        get => this.verticalAlignment;
        set
        {
            this.verticalAlignment = value;
            this.DoApplyVertical = true;
        }
    }

    public bool DoApplyHorizontal { get; set; } = false;

    public bool DoApplyVertical { get; set; } = false;

    public XLAlignmentHorizontalValues ToXlHorizontalAlignment()
    {
        return this.HorizontalAlignment switch
        {
            HorizontalAlignment.Center => XLAlignmentHorizontalValues.Center,
            HorizontalAlignment.CenterContinuous => XLAlignmentHorizontalValues.CenterContinuous,
            HorizontalAlignment.Distributed => XLAlignmentHorizontalValues.Distributed,
            HorizontalAlignment.Fill => XLAlignmentHorizontalValues.Fill,
            HorizontalAlignment.General => XLAlignmentHorizontalValues.General,
            HorizontalAlignment.Justify => XLAlignmentHorizontalValues.Justify,
            HorizontalAlignment.Left => XLAlignmentHorizontalValues.Left,
            HorizontalAlignment.Right => XLAlignmentHorizontalValues.Right,
            _ => XLAlignmentHorizontalValues.Left,
        };
    }

    public XLAlignmentVerticalValues ToXlVerticalAlignment()
    {
        return this.VerticalAlignment switch
        {
            VerticalAlignment.Bottom => XLAlignmentVerticalValues.Bottom,
            VerticalAlignment.Center => XLAlignmentVerticalValues.Center,
            VerticalAlignment.Distributed => XLAlignmentVerticalValues.Distributed,
            VerticalAlignment.Justify => XLAlignmentVerticalValues.Justify,
            VerticalAlignment.Top => XLAlignmentVerticalValues.Top,
            _ => XLAlignmentVerticalValues.Center,
        };
    }
}
