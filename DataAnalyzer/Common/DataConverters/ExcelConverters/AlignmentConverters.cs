namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal class AlignmentConverters
    {
        public static Services.HorizontalAlignment ToLocalHorizontalAlignment(ExcelService.Styles.Alignments.HorizontalAlignment horizontalAlignment)
        {
            return horizontalAlignment switch
            {
                ExcelService.Styles.Alignments.HorizontalAlignment.Center => Services.HorizontalAlignment.Center,
                ExcelService.Styles.Alignments.HorizontalAlignment.CenterContinuous => Services.HorizontalAlignment.CenterContinuous,
                ExcelService.Styles.Alignments.HorizontalAlignment.Distributed => Services.HorizontalAlignment.Distributed,
                ExcelService.Styles.Alignments.HorizontalAlignment.Fill => Services.HorizontalAlignment.Fill,
                ExcelService.Styles.Alignments.HorizontalAlignment.General => Services.HorizontalAlignment.General,
                ExcelService.Styles.Alignments.HorizontalAlignment.Justify => Services.HorizontalAlignment.Justify,
                ExcelService.Styles.Alignments.HorizontalAlignment.Left => Services.HorizontalAlignment.Left,
                ExcelService.Styles.Alignments.HorizontalAlignment.Right => Services.HorizontalAlignment.Right,
                _ => Services.HorizontalAlignment.General,
            };
        }

        public static ExcelService.Styles.Alignments.HorizontalAlignment ToExcelHorizontalAlignment(Services.HorizontalAlignment horizontalAlignment)
        {
            return horizontalAlignment switch
            {
                Services.HorizontalAlignment.Center => ExcelService.Styles.Alignments.HorizontalAlignment.Center,
                Services.HorizontalAlignment.CenterContinuous => ExcelService.Styles.Alignments.HorizontalAlignment.CenterContinuous,
                Services.HorizontalAlignment.Distributed => ExcelService.Styles.Alignments.HorizontalAlignment.Distributed,
                Services.HorizontalAlignment.Fill => ExcelService.Styles.Alignments.HorizontalAlignment.Fill,
                Services.HorizontalAlignment.General => ExcelService.Styles.Alignments.HorizontalAlignment.General,
                Services.HorizontalAlignment.Justify => ExcelService.Styles.Alignments.HorizontalAlignment.Justify,
                Services.HorizontalAlignment.Left => ExcelService.Styles.Alignments.HorizontalAlignment.Left,
                Services.HorizontalAlignment.Right => ExcelService.Styles.Alignments.HorizontalAlignment.Right,
                _ => ExcelService.Styles.Alignments.HorizontalAlignment.General,
            };
        }

        public static Services.VerticalAlignment ToLocalVerticalAlignment(ExcelService.Styles.Alignments.VerticalAlignment verticalAlignment)
        {
            return verticalAlignment switch
            {
                ExcelService.Styles.Alignments.VerticalAlignment.Bottom => Services.VerticalAlignment.Bottom,
                ExcelService.Styles.Alignments.VerticalAlignment.Center => Services.VerticalAlignment.Center,
                ExcelService.Styles.Alignments.VerticalAlignment.Distributed => Services.VerticalAlignment.Distributed,
                ExcelService.Styles.Alignments.VerticalAlignment.Justify => Services.VerticalAlignment.Justify,
                ExcelService.Styles.Alignments.VerticalAlignment.Top => Services.VerticalAlignment.Top,
                _ => Services.VerticalAlignment.Top,
            };
        }

        public static ExcelService.Styles.Alignments.VerticalAlignment ToExcelVerticalAlignment(Services.VerticalAlignment verticalAlignment)
        {
            return verticalAlignment switch
            {
                Services.VerticalAlignment.Bottom => ExcelService.Styles.Alignments.VerticalAlignment.Bottom,
                Services.VerticalAlignment.Center => ExcelService.Styles.Alignments.VerticalAlignment.Center,
                Services.VerticalAlignment.Distributed => ExcelService.Styles.Alignments.VerticalAlignment.Distributed,
                Services.VerticalAlignment.Justify => ExcelService.Styles.Alignments.VerticalAlignment.Justify,
                Services.VerticalAlignment.Top => ExcelService.Styles.Alignments.VerticalAlignment.Top,
                _ => ExcelService.Styles.Alignments.VerticalAlignment.Top,
            };
        }
    }
}
