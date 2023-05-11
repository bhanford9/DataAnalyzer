using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels;

internal interface ITwoParameterDataTypeViewModel<T1, T2> : IDataTypeConfigViewModel
{
    string Parameter1Name { get; set; }
    T1 Parameter1Value { get; set; }
    string Parameter2Name { get; set; }
    T2 Parameter2Value { get; set; }

    void UpdateTypeParam(ITypeParameter param);
}