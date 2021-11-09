namespace ExcelService.CellDataFormats.NumericFormat
{
  public class IntegerSeparatorParensCellDataFormat : ICellDataFormat
  {
    private bool colorRed = false;

    public string Name => "Integer with Separator Negation Parenthesis";

    public string Example => "12,345 or (-1,234)";

    public string GetFormatString()
    {
      return "#,##0 ," + (this.colorRed ? "[Red]" : "") + "(#,##0)";
    }
  }
}
