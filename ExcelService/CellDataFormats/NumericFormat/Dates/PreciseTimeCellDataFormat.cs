namespace ExcelService.CellDataFormats.NumericFormat.Dates
{
    public class PreciseTimeCellDataFormat : IPreciseTimeCellDataFormat
    {
        public string Example => "12:00:00";

        public string Name => "Time with Seconds";

        public string GetFormatString()
        {
            return "h:mm:ss";
        }
    }
}
