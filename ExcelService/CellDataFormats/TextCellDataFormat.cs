namespace ExcelService.CellDataFormats
{
    public class TextCellDataFormat : ICellDataFormat
    {
        public string Example => "Text Data";

        public string Name => "Standard Text";

        public string GetFormatString()
        {
            return "";
        }
    }
}
