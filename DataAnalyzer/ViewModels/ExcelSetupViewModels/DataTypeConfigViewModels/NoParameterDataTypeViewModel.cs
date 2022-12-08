using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels
{
    internal class NoParameterDataTypeViewModel : DataTypeConfigViewModel
    {
        public NoParameterDataTypeViewModel(ITypeParameter typeParameter) : base(typeParameter)
        {
        }

        public override void UpdateTypeParam(ITypeParameter param)
        {
        }

        protected override IReadOnlyDictionary<string, object> GetNamedValues()
        {
            return new Dictionary<string, object> { };
        }
    }
}
