using ClosedXML.Excel;
using ExcelService.Styles.Colors;

namespace ExcelService.Styles.Borders
{
    public class Border
    {
        public bool DoApply { get; set; } = false;

        public BorderStyle Style { get; set; } = BorderStyle.None;

        public ColorValue Color { get; set; } = new ColorValue(Colors.Color.Transparent);

        public XLBorderStyleValues ToXlBorderStyle()
        {
            return this.Style switch
            {
                BorderStyle.DashDot => XLBorderStyleValues.DashDot,
                BorderStyle.DashDotDot => XLBorderStyleValues.DashDotDot,
                BorderStyle.Dashed => XLBorderStyleValues.Dashed,
                BorderStyle.Dotted => XLBorderStyleValues.Dotted,
                BorderStyle.Double => XLBorderStyleValues.Double,
                BorderStyle.Hair => XLBorderStyleValues.Hair,
                BorderStyle.Medium => XLBorderStyleValues.Medium,
                BorderStyle.MediumDashDot => XLBorderStyleValues.MediumDashDot,
                BorderStyle.MediumDashDotDot => XLBorderStyleValues.MediumDashDotDot,
                BorderStyle.MediumDashed => XLBorderStyleValues.MediumDashed,
                BorderStyle.None => XLBorderStyleValues.None,
                BorderStyle.SlantDashDot => XLBorderStyleValues.SlantDashDot,
                BorderStyle.Thick => XLBorderStyleValues.Thick,
                BorderStyle.Thin => XLBorderStyleValues.Thin,
                _ => default,
            };
        }
    }
}
