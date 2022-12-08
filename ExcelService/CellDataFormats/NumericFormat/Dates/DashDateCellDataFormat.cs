namespace ExcelService.CellDataFormats.Numeric.Dates
{
    public class DashDateCellDataFormat : ICellDataFormat
    {
        public string Example => "1-Jan-00";

        public string Name => "Numeric Date with Month Abbreviation";

        public string GetFormatString()
        {
            return "d-mmm-yy";
        }
    }
}
