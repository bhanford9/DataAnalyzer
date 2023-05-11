using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels;

internal interface IOneParameterDataTypeViewModel<T> : IDataTypeConfigViewModel
{
    string ParameterName { get; set; }
    T ParameterValue { get; set; }

    void UpdateTypeParam(ITypeParameter param);
}