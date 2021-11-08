namespace ExcelService.CellDataFormats.NumericFormat
{
  public class FractionCellDataFormat : ICellDataFormat
  {
    public string Example => "3/16";

    public string Name => "Fraction";

    public string GetFormatString()
    {
      return "# ???/???";
    }
  }
}
