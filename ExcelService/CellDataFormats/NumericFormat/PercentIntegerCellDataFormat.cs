namespace ExcelService.CellDataFormats.NumericFormat
{
  public class PercentIntegerCellDataFormat : ICellDataFormat
  {
    public string Example => "23%";

    public string Name => "Percentage";

    public string GetFormatString()
    {
      return "0%";
    }
  }
}
