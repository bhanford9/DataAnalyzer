namespace ExcelService.CellDataFormats.NumericFormat
{
    public class GeneralNumericCellDataFormat : ICellDataFormat
    {
        public string Example => "1234.5";

        public string Name => "General";

        public string GetFormatString()
        {
            return "General";
        }
    }
}
