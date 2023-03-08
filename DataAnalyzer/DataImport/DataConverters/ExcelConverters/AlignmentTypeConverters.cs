using DataAnalyzer.Services.Enums;
using ServiceStyles = ExcelService.Styles.Alignments;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters
{
    internal class AlignmentTypeConverters
    {
        public static HorizontalAlignment ToLocalHorizontalAlignment(ServiceStyles.HorizontalAlignment horizontalAlignment) => horizontalAlignment switch
        {
            ServiceStyles.HorizontalAlignment.Center => HorizontalAlignment.Center,
            ServiceStyles.HorizontalAlignment.CenterContinuous => HorizontalAlignment.CenterContinuous,
            ServiceStyles.HorizontalAlignment.Distributed => HorizontalAlignment.Distributed,
            ServiceStyles.HorizontalAlignment.Fill => HorizontalAlignment.Fill,
            ServiceStyles.HorizontalAlignment.General => HorizontalAlignment.General,
            ServiceStyles.HorizontalAlignment.Justify => HorizontalAlignment.Justify,
            ServiceStyles.HorizontalAlignment.Left => HorizontalAlignment.Left,
            ServiceStyles.HorizontalAlignment.Right => HorizontalAlignment.Right,
            _ => HorizontalAlignment.General,
        };

        public static ServiceStyles.HorizontalAlignment ToExcelHorizontalAlignment(HorizontalAlignment horizontalAlignment) => horizontalAlignment switch
        {
            HorizontalAlignment.Center => ServiceStyles.HorizontalAlignment.Center,
            HorizontalAlignment.CenterContinuous => ServiceStyles.HorizontalAlignment.CenterContinuous,
            HorizontalAlignment.Distributed => ServiceStyles.HorizontalAlignment.Distributed,
            HorizontalAlignment.Fill => ServiceStyles.HorizontalAlignment.Fill,
            HorizontalAlignment.General => ServiceStyles.HorizontalAlignment.General,
            HorizontalAlignment.Justify => ServiceStyles.HorizontalAlignment.Justify,
            HorizontalAlignment.Left => ServiceStyles.HorizontalAlignment.Left,
            HorizontalAlignment.Right => ServiceStyles.HorizontalAlignment.Right,
            _ => ServiceStyles.HorizontalAlignment.General,
        };

        public static VerticalAlignment ToLocalVerticalAlignment(ServiceStyles.VerticalAlignment verticalAlignment) => verticalAlignment switch
        {
            ServiceStyles.VerticalAlignment.Bottom => VerticalAlignment.Bottom,
            ServiceStyles.VerticalAlignment.Center => VerticalAlignment.Center,
            ServiceStyles.VerticalAlignment.Distributed => VerticalAlignment.Distributed,
            ServiceStyles.VerticalAlignment.Justify => VerticalAlignment.Justify,
            ServiceStyles.VerticalAlignment.Top => VerticalAlignment.Top,
            _ => VerticalAlignment.Top,
        };

        public static ServiceStyles.VerticalAlignment ToExcelVerticalAlignment(VerticalAlignment verticalAlignment) => verticalAlignment switch
        {
            VerticalAlignment.Bottom => ServiceStyles.VerticalAlignment.Bottom,
            VerticalAlignment.Center => ServiceStyles.VerticalAlignment.Center,
            VerticalAlignment.Distributed => ServiceStyles.VerticalAlignment.Distributed,
            VerticalAlignment.Justify => ServiceStyles.VerticalAlignment.Justify,
            VerticalAlignment.Top => ServiceStyles.VerticalAlignment.Top,
            _ => ServiceStyles.VerticalAlignment.Top,
        };
    }
}
