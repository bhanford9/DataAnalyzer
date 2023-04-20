namespace ExcelService.CellDataFormats.NumericFormat.Dates
{
    public class DayOfWeekCellDataFormat : IDayOfWeekCellDataFormat
    {
        public string Example => "Monday";

        public string Name => "Day of Week";

        public string GetFormatString()
        {
            return "dddd";
        }
    }
}
