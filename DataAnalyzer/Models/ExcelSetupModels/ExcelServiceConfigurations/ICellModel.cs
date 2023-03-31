using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
    internal interface ICellModel : INotifyPropertyChanged
    {
        ICollection<IExcelAction> CellActions { get; set; }
        int ColumnIndex { get; set; }
        string DataMemberName { get; set; }
        ITypeParameter DataType { get; set; }
        object Value { get; set; }
    }
}