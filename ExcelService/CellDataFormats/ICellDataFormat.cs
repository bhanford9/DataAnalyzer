namespace ExcelService.CellDataFormats
{
    public interface ICellDataFormat
    {
        string Name { get; }

        string Example { get; }

        string GetFormatString();
    }
}
