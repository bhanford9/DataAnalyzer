namespace ExcelService.CellDataFormats.NumericFormat
{
  public class ZeroPrependFloatingPrecisionCellDataFormat : ICellDataFormat
  {
    private readonly int zerosPrependedCount = 0;
    private readonly int precisionCount = 0;

    public string Example => "0023.100";

    public string Name => "Zero Prepended Floating Point Precision";

    public ZeroPrependFloatingPrecisionCellDataFormat(int zerosPrependedCount, int precisionCount)
    {
      this.zerosPrependedCount = zerosPrependedCount < 1 ? 1 : zerosPrependedCount;
      this.precisionCount = precisionCount < 1 ? 1 : precisionCount;
    }

    public string GetFormatString()
    {
      return new string('0', this.zerosPrependedCount) + "." + new string('0', this.precisionCount);
    }
  }
}
