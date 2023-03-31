using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels
{
    internal class TwoParameterDataTypeViewModel<T1, T2> : DataTypeConfigViewModel, ITwoParameterDataTypeViewModel<T1, T2>
    {
        private string parameter1Name = string.Empty;
        private string parameter2Name = string.Empty;

        private T1 parameter1Value = default;
        private T2 parameter2Value = default;

        public TwoParameterDataTypeViewModel(
            ITypeParameter typeParameter,
            IExcelSetupModel excelSetupModel)
            : base(typeParameter, excelSetupModel)
        {
            switch (typeParameter)
            {
                case IntegerIntegerTypeParameter integerType:
                    this.parameter1Name = integerType.Integer1Name;
                    this.parameter1Value = (T1)(object)integerType.Integer1Value;
                    this.parameter2Name = integerType.Integer2Name;
                    this.parameter2Value = (T2)(object)integerType.Integer2Value;
                    break;
                case IntegerBooleanTypeParameter integerType:
                    this.parameter1Name = integerType.IntegerName;
                    this.parameter1Value = (T1)(object)integerType.IntegerValue;
                    this.parameter2Name = integerType.BooleanName;
                    this.parameter2Value = (T2)(object)integerType.BooleanValue;
                    break;
            }
        }

        public string Parameter1Name
        {
            get => this.parameter1Name;
            set => this.NotifyPropertyChanged(ref this.parameter1Name, value);
        }

        public string Parameter2Name
        {
            get => this.parameter2Name;
            set => this.NotifyPropertyChanged(ref this.parameter2Name, value);
        }

        // TODO --> implement parameter like the one paramter data type view model
        public T1 Parameter1Value
        {
            get => this.parameter1Value;
            set => this.NotifyPropertyChanged(ref this.parameter1Value, value);
        }

        // TODO --> implement parameter like the one paramter data type view model
        public T2 Parameter2Value
        {
            get => this.parameter2Value;
            set => this.NotifyPropertyChanged(ref this.parameter2Value, value);
        }

        public override void UpdateTypeParam(ITypeParameter param)
        {
            if (param is IntegerIntegerTypeParameter p)
            {
                p.Integer1Name = this.Parameter1Name;
                p.Integer1Value = (int)(object)this.Parameter1Value;
                p.Integer2Name = this.Parameter2Name;
                p.Integer2Value = (int)(object)this.Parameter2Value;
            }
            else if (param is IntegerBooleanTypeParameter o)
            {
                o.IntegerName = this.Parameter1Name;
                o.IntegerValue = (int)(object)this.Parameter1Value;
                o.BooleanName = this.Parameter2Name;
                o.BooleanValue = (bool)(object)this.Parameter2Value;
            }
        }

        protected override IReadOnlyDictionary<string, object> GetNamedValues() => new Dictionary<string, object>
            {
                { this.Parameter1Name, this.Parameter1Value },
                { this.Parameter2Name, this.Parameter2Value }
            };
    }
}
