namespace ExcelService.CellDataFormats.NumericFormat
{
  public class FloatingPrecisionCellDataFormat : ICellDataFormat
  {
    private int precisionCount = 0;

    public string Example
    {
      get
      {
        if (this.precisionCount == 1)
        {
          return "6.3";
        }
        if (this.precisionCount == 2)
        {
          return "6.30";
        }

        return "6.39" + new string(new string('0', this.precisionCount - 2));
      }
    }

    public string Name => "Floating Point Precision";

    public FloatingPrecisionCellDataFormat(int precisionCount)
    {
      this.precisionCount = precisionCount < 1 ? 1 : precisionCount;
    }

    public string GetFormatString()
    {
      return "0." + new string('0', this.precisionCount);
    }
  }
}
