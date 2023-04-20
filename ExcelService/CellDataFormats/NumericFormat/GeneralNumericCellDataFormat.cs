namespace ExcelService.CellDataFormats.NumericFormat
{
    public class GeneralNumericCellDataFormat : IGeneralNumericCellDataFormat
    {
        public string Example => "1234.5";

        public string Name => "General";

        public string GetFormatString()
        {
            return "General";
        }
    }
}
