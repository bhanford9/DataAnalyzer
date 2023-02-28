using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal class AlignmentTypeConverters
    {
        public static HorizontalAlignment ToLocalHorizontalAlignment(ExcelService.Styles.Alignments.HorizontalAlignment horizontalAlignment)
        {
            return horizontalAlignment switch
            {
                ExcelService.Styles.Alignments.HorizontalAlignment.Center => HorizontalAlignment.Center,
                ExcelService.Styles.Alignments.HorizontalAlignment.CenterContinuous => HorizontalAlignment.CenterContinuous,
                ExcelService.Styles.Alignments.HorizontalAlignment.Distributed => HorizontalAlignment.Distributed,
                ExcelService.Styles.Alignments.HorizontalAlignment.Fill => HorizontalAlignment.Fill,
                ExcelService.Styles.Alignments.HorizontalAlignment.General => HorizontalAlignment.General,
                ExcelService.Styles.Alignments.HorizontalAlignment.Justify => HorizontalAlignment.Justify,
                ExcelService.Styles.Alignments.HorizontalAlignment.Left => HorizontalAlignment.Left,
                ExcelService.Styles.Alignments.HorizontalAlignment.Right => HorizontalAlignment.Right,
                _ => HorizontalAlignment.General,
            };
        }

        public static ExcelService.Styles.Alignments.HorizontalAlignment ToExcelHorizontalAlignment(HorizontalAlignment horizontalAlignment)
        {
            return horizontalAlignment switch
            {
                HorizontalAlignment.Center => ExcelService.Styles.Alignments.HorizontalAlignment.Center,
                HorizontalAlignment.CenterContinuous => ExcelService.Styles.Alignments.HorizontalAlignment.CenterContinuous,
                HorizontalAlignment.Distributed => ExcelService.Styles.Alignments.HorizontalAlignment.Distributed,
                HorizontalAlignment.Fill => ExcelService.Styles.Alignments.HorizontalAlignment.Fill,
                HorizontalAlignment.General => ExcelService.Styles.Alignments.HorizontalAlignment.General,
                HorizontalAlignment.Justify => ExcelService.Styles.Alignments.HorizontalAlignment.Justify,
                HorizontalAlignment.Left => ExcelService.Styles.Alignments.HorizontalAlignment.Left,
                HorizontalAlignment.Right => ExcelService.Styles.Alignments.HorizontalAlignment.Right,
                _ => ExcelService.Styles.Alignments.HorizontalAlignment.General,
            };
        }

        public static VerticalAlignment ToLocalVerticalAlignment(ExcelService.Styles.Alignments.VerticalAlignment verticalAlignment)
        {
            return verticalAlignment switch
            {
                ExcelService.Styles.Alignments.VerticalAlignment.Bottom => VerticalAlignment.Bottom,
                ExcelService.Styles.Alignments.VerticalAlignment.Center => VerticalAlignment.Center,
                ExcelService.Styles.Alignments.VerticalAlignment.Distributed => VerticalAlignment.Distributed,
                ExcelService.Styles.Alignments.VerticalAlignment.Justify => VerticalAlignment.Justify,
                ExcelService.Styles.Alignments.VerticalAlignment.Top => VerticalAlignment.Top,
                _ => VerticalAlignment.Top,
            };
        }

        public static ExcelService.Styles.Alignments.VerticalAlignment ToExcelVerticalAlignment(VerticalAlignment verticalAlignment)
        {
            return verticalAlignment switch
            {
                VerticalAlignment.Bottom => ExcelService.Styles.Alignments.VerticalAlignment.Bottom,
                VerticalAlignment.Center => ExcelService.Styles.Alignments.VerticalAlignment.Center,
                VerticalAlignment.Distributed => ExcelService.Styles.Alignments.VerticalAlignment.Distributed,
                VerticalAlignment.Justify => ExcelService.Styles.Alignments.VerticalAlignment.Justify,
                VerticalAlignment.Top => ExcelService.Styles.Alignments.VerticalAlignment.Top,
                _ => ExcelService.Styles.Alignments.VerticalAlignment.Top,
            };
        }
    }
}
