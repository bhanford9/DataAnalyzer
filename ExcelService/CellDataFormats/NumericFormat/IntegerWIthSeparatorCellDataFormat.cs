namespace ExcelService.CellDataFormats.NumericFormat
{
  public class IntegerWIthSeparatorCellDataFormat : ICellDataFormat
  {
    public string Example => "123,456,000";

    public string Name => "Integer with Separator";

    public string GetFormatString()
    {
      return "#,##0";
    }
  }
}
