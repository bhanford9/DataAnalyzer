namespace ExcelService.CellDataFormats.NumericFormat
{
  public class FractionCellDataFormat : ICellDataFormat
  {
    private int precisionCount = 1;

    public string Example
    {
      get
      {
        string numerator = new string('1', this.precisionCount);
        string denominator = new string('3', this.precisionCount);
        return numerator + "/" + denominator;
      }
    }

    public string Name => "Fraction";

    public FractionCellDataFormat(int precisionCount)
    {
      this.precisionCount = precisionCount < 1 ? 1 : precisionCount;
    }

    public string GetFormatString()
    {
      string qs = new string('?', this.precisionCount);
      return "# " + qs + "/" + qs;
    }
  }
}
