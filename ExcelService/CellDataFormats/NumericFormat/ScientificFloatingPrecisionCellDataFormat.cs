namespace ExcelService.CellDataFormats.NumericFormat
{
  public class ScientificFloatingPrecisionCellDataFormat : ICellDataFormat
  {
    private readonly int precisionCount = 1;

    public string Name => "Scientific with Decimals";

    public string Example
    {
      get
      {
        if (this.precisionCount == 1)
        {
          return "6.3E+04";
        }
        if (this.precisionCount == 2)
        {
          return "6.30E+04";
        }

        int zeroCount = this.precisionCount - 2;

        return "6.39" + new string(new string('0', zeroCount < 0 ? 0 : zeroCount)) + "E+04";
      }
    }

    public ScientificFloatingPrecisionCellDataFormat(int precisionCount)
    {
      this.precisionCount = precisionCount;
    }

    public string GetFormatString()
    {
      return "0." + new string('0', this.precisionCount) + "E+00";
    }
  }
}
