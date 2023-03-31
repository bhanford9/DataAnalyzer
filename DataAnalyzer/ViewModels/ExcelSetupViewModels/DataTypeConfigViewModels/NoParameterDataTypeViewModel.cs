using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels
{
    internal class NoParameterDataTypeViewModel : DataTypeConfigViewModel, INoParameterDataTypeViewModel
    {
        public NoParameterDataTypeViewModel(
            ITypeParameter typeParameter,
            IExcelSetupModel excelSetupModel)
            : base(typeParameter, excelSetupModel)
        {
        }

        public override void UpdateTypeParam(ITypeParameter param)
        {
        }

        protected override IReadOnlyDictionary<string, object> GetNamedValues() => new Dictionary<string, object> { };
    }
}
