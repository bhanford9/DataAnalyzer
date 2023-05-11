namespace ExcelService.CellDataFormats;

public class TextCellDataFormat : ITextCellDataFormat
{
    public string Example => "Text Data";

    public string Name => "Standard Text";

    public string GetFormatString()
    {
        return "";
    }
}
