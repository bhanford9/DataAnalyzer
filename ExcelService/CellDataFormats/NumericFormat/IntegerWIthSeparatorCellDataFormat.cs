﻿namespace ExcelService.CellDataFormats.NumericFormat
{
    public class IntegerWIthSeparatorCellDataFormat : IIntegerWIthSeparatorCellDataFormat
    {
        public string Example => "123,456,000";

        public string Name => "Separated";

        public string GetFormatString()
        {
            return "#,##0";
        }
    }
}
