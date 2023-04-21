namespace ExcelService.CellDataFormats
{
    public class CellDataFormatLibrary : ICellDataFormatLibrary
    {
        private readonly IReadOnlyCollection<ICellDataFormat> cellDataFormats;

        public CellDataFormatLibrary(IReadOnlyCollection<ICellDataFormat> cellDataFormats)
        {
            this.cellDataFormats = cellDataFormats;
        }

        public ICellDataFormat GetByName(string name)
        {
            return this.cellDataFormats.First(x => x.Name.Equals(name));
        }
    }
}
