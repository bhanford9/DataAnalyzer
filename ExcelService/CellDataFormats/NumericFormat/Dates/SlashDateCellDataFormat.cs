namespace ExcelService.CellDataFormats.Numeric.Dates
{
  public class SlashDateCellDataFormat : ICellDataFormat
  {
    public string Example => "1/1/2000";

    public string Name => "Date with Slashes";

    public string GetFormatString()
    {
      return "m/d/yy";
    }
  }
}
