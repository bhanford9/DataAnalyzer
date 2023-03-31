using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels
{
    internal interface INoParameterDataTypeViewModel : IDataTypeConfigViewModel
    {
        void UpdateTypeParam(ITypeParameter param);
    }
}