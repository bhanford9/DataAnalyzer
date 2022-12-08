using ExcelService.CellDataFormats;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
    internal interface ITypeParameter : INotifyPropertyChanged
    {
        string ExcelTypeName { get; set; }
        string Example { get; }
        ParameterType Type { get; }
        string DataName { get; set; }

        void CloneParameters(ITypeParameter other);
        ICellDataFormat CreateCellDataFormat();
        object[] GetParameterNameValuePairs();
        void UpdateValues(IReadOnlyDictionary<string, object> namedValues);
    }
}
