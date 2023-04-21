using ClosedXML.Excel;
using ExcelService.Styles.Colors;

namespace ExcelService.Styles.Patterns
{
    public class FillPatternValue : IFillPatternValue
    {
        public FillPattern Type { get; set; } = FillPattern.None;

        public ColorValue Color { get; set; } = new ColorValue(Colors.Color.Transparent);

        public bool DoApply { get; set; } = false;

        public XLFillPatternValues ToXlFromLocal()
        {
            return this.Type switch
            {
                FillPattern.DarkDown => XLFillPatternValues.DarkDown,
                FillPattern.DarkGray => XLFillPatternValues.DarkGray,
                FillPattern.DarkGrid => XLFillPatternValues.DarkGrid,
                FillPattern.DarkHorizontal => XLFillPatternValues.DarkHorizontal,
                FillPattern.DarkTrellis => XLFillPatternValues.DarkTrellis,
                FillPattern.DarkUp => XLFillPatternValues.DarkUp,
                FillPattern.DarkVertical => XLFillPatternValues.DarkVertical,
                FillPattern.Gray0625 => XLFillPatternValues.Gray0625,
                FillPattern.Gray125 => XLFillPatternValues.Gray125,
                FillPattern.LightDown => XLFillPatternValues.LightDown,
                FillPattern.LightGray => XLFillPatternValues.LightGray,
                FillPattern.LightGrid => XLFillPatternValues.LightGrid,
                FillPattern.LightHorizontal => XLFillPatternValues.LightHorizontal,
                FillPattern.LightTrellis => XLFillPatternValues.LightTrellis,
                FillPattern.LightUp => XLFillPatternValues.LightUp,
                FillPattern.LightVertical => XLFillPatternValues.LightVertical,
                FillPattern.MediumGray => XLFillPatternValues.MediumGray,
                FillPattern.None => XLFillPatternValues.None,
                FillPattern.Solid => XLFillPatternValues.Solid,
                _ => XLFillPatternValues.None,
            };
        }
    }
}
