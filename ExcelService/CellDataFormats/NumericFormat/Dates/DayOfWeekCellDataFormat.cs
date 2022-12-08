namespace ExcelService.CellDataFormats.Numeric.Dates
{
    public class DayOfWeekCellDataFormat : ICellDataFormat
    {
        public string Example => "Monday";

        public string Name => "Day of Week";

        public string GetFormatString()
        {
            return "dddd";
        }
    }
}
