namespace ExcelService.CellDataFormats.NumericFormat.Dates
{
  public class DateAndTimeCellDataFormat : ICellDataFormat
  {
    public string Example => "1/1/2001 12:00";

    public string Name => "Date and Time";

    public string GetFormatString()
    {
      return "m/d/yy h:mm";
    }
  }
}
