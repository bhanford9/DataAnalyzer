using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels
{
    internal class OneParameterDataTypeViewModel<T> : DataTypeConfigViewModel
    {
        private string parameterName = string.Empty;
        private T parameterValue = default;

        public OneParameterDataTypeViewModel(ITypeParameter typeParameter) : base(typeParameter)
        {
            switch(typeParameter)
            {
                case IntegerTypeParameter integerType:
                    this.ParameterName = integerType.DataName;
                    this.ParameterValue = (T)(object)integerType.IntegerValue;
                    break;
            }
        }

        public string ParameterName
        {
            get => this.parameterName;
            set => this.NotifyPropertyChanged(ref this.parameterName, value);
        }

        public T ParameterValue
        {
            get => this.parameterValue;
            set
            {
                this.NotifyPropertyChanged(ref this.parameterValue, value);
                
                (this.TypeParameter as IntegerTypeParameter).IntegerValue = (int)(object)value;
                this.TypeParameter.CreateCellDataFormat();
                this.Example = this.TypeParameter.Example;
            }
        }

        public override void UpdateTypeParam(ITypeParameter param)
        {
            if (param is IntegerTypeParameter p)
            {
                p.IntegerName = this.ParameterName;
                p.IntegerValue = (int)(object)this.ParameterValue;
            }
        }

        protected override IReadOnlyDictionary<string, object> GetNamedValues()
        {
            return new Dictionary<string, object> { { this.ParameterName, this.ParameterValue } };
        }
    }
}
