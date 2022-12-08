namespace ExcelService.CellDataFormats.NumericFormat
{
    public class ZeroPrependIntegerCellDataFormat : ICellDataFormat
    {
        private readonly int zerosPrependedCount = 0;

        public string Example
        {
            get
            {
                if (this.zerosPrependedCount == 1)
                {
                    return "9";
                }
                if (this.zerosPrependedCount == 2)
                {
                    return "09";
                }

                return new string('0', this.zerosPrependedCount - 2) + 19;
            }
        }

        public string Name => "Leading Zeros";

        public ZeroPrependIntegerCellDataFormat(int zerosPrependedCount)
        {
            this.zerosPrependedCount = zerosPrependedCount < 1 ? 1 : zerosPrependedCount;
        }

        public string GetFormatString()
        {
            return new string('0', this.zerosPrependedCount);
        }
    }
}
