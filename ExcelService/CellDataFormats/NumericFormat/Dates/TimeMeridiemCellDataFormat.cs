﻿namespace ExcelService.CellDataFormats.NumericFormat.Dates
{
    public class TimeMeridiemCellDataFormat : ICellDataFormat
    {
        public string Example => "12:00 AM";

        public string Name => "Time Meridiem";

        public string GetFormatString()
        {
            return "h:mm AM/PM";
        }
    }
}
