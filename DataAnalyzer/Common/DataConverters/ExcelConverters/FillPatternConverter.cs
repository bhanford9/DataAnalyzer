namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
  public class FillPatternConverter
  {
    public static Services.FillPattern ToLocalFillPattern(ExcelService.Styles.Patterns.FillPattern fillPattern)
    {
      return fillPattern switch
      {
        ExcelService.Styles.Patterns.FillPattern.DarkDown => Services.FillPattern.DarkDown,
        ExcelService.Styles.Patterns.FillPattern.DarkGray => Services.FillPattern.DarkGray,
        ExcelService.Styles.Patterns.FillPattern.DarkGrid => Services.FillPattern.DarkGrid,
        ExcelService.Styles.Patterns.FillPattern.DarkHorizontal => Services.FillPattern.DarkHorizontal,
        ExcelService.Styles.Patterns.FillPattern.DarkTrellis => Services.FillPattern.DarkTrellis,
        ExcelService.Styles.Patterns.FillPattern.DarkUp => Services.FillPattern.DarkUp,
        ExcelService.Styles.Patterns.FillPattern.DarkVertical => Services.FillPattern.DarkVertical,
        ExcelService.Styles.Patterns.FillPattern.Gray0625 => Services.FillPattern.Gray0625,
        ExcelService.Styles.Patterns.FillPattern.Gray125 => Services.FillPattern.Gray125,
        ExcelService.Styles.Patterns.FillPattern.LightDown => Services.FillPattern.LightDown,
        ExcelService.Styles.Patterns.FillPattern.LightGray => Services.FillPattern.LightGray,
        ExcelService.Styles.Patterns.FillPattern.LightGrid => Services.FillPattern.LightGrid,
        ExcelService.Styles.Patterns.FillPattern.LightHorizontal => Services.FillPattern.LightHorizontal,
        ExcelService.Styles.Patterns.FillPattern.LightTrellis => Services.FillPattern.LightTrellis,
        ExcelService.Styles.Patterns.FillPattern.LightUp => Services.FillPattern.LightUp,
        ExcelService.Styles.Patterns.FillPattern.LightVertical => Services.FillPattern.LightVertical,
        ExcelService.Styles.Patterns.FillPattern.MediumGray => Services.FillPattern.MediumGray,
        ExcelService.Styles.Patterns.FillPattern.None => Services.FillPattern.None,
        ExcelService.Styles.Patterns.FillPattern.Solid => Services.FillPattern.Solid,
        _ => Services.FillPattern.None,
      };
    }

    public static ExcelService.Styles.Patterns.FillPattern ToExcelFillPattern(Services.FillPattern fillPattern)
    {
      return fillPattern switch
      {
        Services.FillPattern.DarkDown => ExcelService.Styles.Patterns.FillPattern.DarkDown,
        Services.FillPattern.DarkGray => ExcelService.Styles.Patterns.FillPattern.DarkGray,
        Services.FillPattern.DarkGrid => ExcelService.Styles.Patterns.FillPattern.DarkGrid,
        Services.FillPattern.DarkHorizontal => ExcelService.Styles.Patterns.FillPattern.DarkHorizontal,
        Services.FillPattern.DarkTrellis => ExcelService.Styles.Patterns.FillPattern.DarkTrellis,
        Services.FillPattern.DarkUp => ExcelService.Styles.Patterns.FillPattern.DarkUp,
        Services.FillPattern.DarkVertical => ExcelService.Styles.Patterns.FillPattern.DarkVertical,
        Services.FillPattern.Gray0625 => ExcelService.Styles.Patterns.FillPattern.Gray0625,
        Services.FillPattern.Gray125 => ExcelService.Styles.Patterns.FillPattern.Gray125,
        Services.FillPattern.LightDown => ExcelService.Styles.Patterns.FillPattern.LightDown,
        Services.FillPattern.LightGray => ExcelService.Styles.Patterns.FillPattern.LightGray,
        Services.FillPattern.LightGrid => ExcelService.Styles.Patterns.FillPattern.LightGrid,
        Services.FillPattern.LightHorizontal => ExcelService.Styles.Patterns.FillPattern.LightHorizontal,
        Services.FillPattern.LightTrellis => ExcelService.Styles.Patterns.FillPattern.LightTrellis,
        Services.FillPattern.LightUp => ExcelService.Styles.Patterns.FillPattern.LightUp,
        Services.FillPattern.LightVertical => ExcelService.Styles.Patterns.FillPattern.LightVertical,
        Services.FillPattern.MediumGray => ExcelService.Styles.Patterns.FillPattern.MediumGray,
        Services.FillPattern.None => ExcelService.Styles.Patterns.FillPattern.None,
        Services.FillPattern.Solid => ExcelService.Styles.Patterns.FillPattern.Solid,
        _ => ExcelService.Styles.Patterns.FillPattern.None,
      };
    }
  }
}
