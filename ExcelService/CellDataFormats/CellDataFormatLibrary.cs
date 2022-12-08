using ExcelService.CellDataFormats.NumericFormat;
using System.Collections.Generic;
using System.Linq;

namespace ExcelService.CellDataFormats
{
    public class CellDataFormatLibrary
    {
        private readonly ICollection<ICellDataFormat> cellDataFormats = new List<ICellDataFormat>();

        public CellDataFormatLibrary()
        {
            this.LoadCellDataFormats();
        }

        public ICellDataFormat GetByName(string name)
        {
            return this.cellDataFormats.First(x => x.Name.Equals(name));
        }

        private void LoadCellDataFormats()
        {
            this.cellDataFormats.Add(new FloatingPrecisionCellDataFormat(0));
            this.cellDataFormats.Add(new FloatingPrecisionWithSeparatorCellDataFormat(0));
            this.cellDataFormats.Add(new FloatingSeparatorParensCellDataFormat(0, false));
            this.cellDataFormats.Add(new FractionCellDataFormat(1));
            this.cellDataFormats.Add(new GeneralNumericCellDataFormat());
            this.cellDataFormats.Add(new IntegerCellDataFormat());
            this.cellDataFormats.Add(new IntegerSeparatorParensCellDataFormat());
            this.cellDataFormats.Add(new IntegerWIthSeparatorCellDataFormat());
            this.cellDataFormats.Add(new NumericAsStringCellDataFormat());
            this.cellDataFormats.Add(new PercentFloatingPrecisionCellDataFormat(0));
            this.cellDataFormats.Add(new PercentIntegerCellDataFormat());
            this.cellDataFormats.Add(new ScientificFloatingPrecisionCellDataFormat(0));
            this.cellDataFormats.Add(new ZeroPrependFloatingPrecisionCellDataFormat(0, 0));
            this.cellDataFormats.Add(new ZeroPrependIntegerCellDataFormat(0));
        }
    }
}
