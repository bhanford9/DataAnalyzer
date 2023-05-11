namespace ExcelService.CellDataFormats.NumericFormat;

public class FloatingPrecisionWithSeparatorCellDataFormat : IFloatingPrecisionWithSeparatorCellDataFormat
{
    private readonly int precisionCount = 0;

    public string Example
    {
        get
        {
            if (this.precisionCount == 1)
            {
                return "1,236.3";
            }
            if (this.precisionCount == 2)
            {
                return "1,236.30";
            }

            return "1,236.39" + new string(new string('0', this.precisionCount - 2));
        }
    }

    public string Name => "Separated With Decimals";

    public FloatingPrecisionWithSeparatorCellDataFormat(int precisionCount)
    {
        this.precisionCount = precisionCount < 1 ? 1 : precisionCount;
    }

    public string GetFormatString()
    {
        return "#,##0." + new string('0', this.precisionCount);
    }
}
