﻿namespace ExcelService.CellDataFormats.NumericFormat;

public class IntegerCellDataFormat : IIntegerCellDataFormat
{
    public string Example => "123";

    public string Name => "Integer";

    public string GetFormatString()
    {
        return "0";
    }
}
