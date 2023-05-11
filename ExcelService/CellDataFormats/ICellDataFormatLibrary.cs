namespace ExcelService.CellDataFormats;

public interface ICellDataFormatLibrary
{
    ICellDataFormat GetByName(string name);
}