namespace ExcelService.CellDataFormats.NumericFormat
{
    public class NumericAsStringCellDataFormat : INumericAsStringCellDataFormat
    {
        public string Example => "42";

        public string Name => "Number as Text";

        public string GetFormatString()
        {
            return "@";
        }
    }
}
