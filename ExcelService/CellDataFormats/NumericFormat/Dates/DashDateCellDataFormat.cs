namespace ExcelService.CellDataFormats.NumericFormat.Dates
{
    public class DashDateCellDataFormat : IDashDateCellDataFormat
    {
        public string Example => "1-Jan-00";

        public string Name => "Numeric Date with Month Abbreviation";

        public string GetFormatString()
        {
            return "d-mmm-yy";
        }
    }
}
