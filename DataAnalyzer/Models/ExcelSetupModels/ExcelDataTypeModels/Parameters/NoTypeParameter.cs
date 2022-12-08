using ExcelService.CellDataFormats;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
    internal class NoTypeParameter : TypeParameter
    {
        public NoTypeParameter() : base() { }

        public NoTypeParameter(ITypeParameter typeParameter) : base(typeParameter) { }

        public NoTypeParameter(ICellDataFormat cellDataFormat, Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
          : base(cellDataFormat, createCellDataFormat)
        {
        }

        public override ParameterType Type => ParameterType.None;

        public override object[] GetParameterNameValuePairs()
        {
            return new object[] { };
        }

        public override void UpdateValues(IReadOnlyDictionary<string, object> namedValues)
        {
        }

        protected override void InternalCloneParameters(ITypeParameter other)
        {
        }
    }
}
