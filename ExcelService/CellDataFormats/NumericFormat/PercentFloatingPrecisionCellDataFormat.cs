namespace ExcelService.CellDataFormats.NumericFormat
{
  public class PercentFloatingPrecisionCellDataFormat : ICellDataFormat
  {
    private int precisionCount = 1;

    public string Name => "Percent Floating Precision";

    public string Example
    {
      get
      {
        if (this.precisionCount == 1)
        {
          return "6.3%";
        }
        if (this.precisionCount == 2)
        {
          return "6.30%";
        }

        return "6.39" + new string(new string('0', this.precisionCount - 2)) + "%";
      }
    }

    public PercentFloatingPrecisionCellDataFormat(int precisionCount)
    {
      this.precisionCount = precisionCount < 1 ? 1 : precisionCount;
    }

    public string GetFormatString()
    {
      return "0." + new string('0', this.precisionCount) + "%";
    }
  }
}
