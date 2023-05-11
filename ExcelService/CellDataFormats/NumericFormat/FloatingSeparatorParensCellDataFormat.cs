namespace ExcelService.CellDataFormats.NumericFormat;

public class FloatingSeparatorParensCellDataFormat : IFloatingSeparatorParensCellDataFormat
{
    private readonly bool colorRed = false;
    private readonly int precisionCount = 1;
    public string Name => "Separated with Decimals and Negation";

    public string Example => "12,345.02 or (-1,234.02)";

    public FloatingSeparatorParensCellDataFormat(int precisionCount, bool colorRed)
    {
        this.precisionCount = precisionCount < 1 ? 1 : precisionCount;
        this.colorRed = colorRed;
    }

    public string GetFormatString()
    {
        string zeros = new string('0', this.precisionCount);
        return "#,##0." + zeros + " ," + (this.colorRed ? "[Red]" : "") + "(#,##0." + zeros + ")";
    }
}
