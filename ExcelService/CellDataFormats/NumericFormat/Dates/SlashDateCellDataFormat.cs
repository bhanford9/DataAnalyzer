namespace ExcelService.CellDataFormats.NumericFormat.Dates;

public class SlashDateCellDataFormat : ISlashDateCellDataFormat
{
    public string Example => "1/1/2000";

    public string Name => "Date with Slashes";

    public string GetFormatString()
    {
        return "m/d/yy";
    }
}
