using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;

internal class CellModel : BasePropertyChanged, ICellModel
{
    public ICollection<IExcelAction> CellActions { get; set; } = new List<IExcelAction>();

    public object Value { get; set; } = new();

    public ITypeParameter DataType { get; set; }

    public int ColumnIndex { get; set; }

    public string DataMemberName { get; set; } = string.Empty;
}
