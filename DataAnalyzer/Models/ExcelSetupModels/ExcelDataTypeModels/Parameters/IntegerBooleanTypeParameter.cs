using ExcelService.CellDataFormats;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
    internal class IntegerBooleanTypeParameter : IntegerTypeParameter, IIntegerBooleanTypeParameter
    {
        private bool booleanValue = true;

        public IntegerBooleanTypeParameter() : base() { }

        public IntegerBooleanTypeParameter(ITypeParameter typeParameter) : base(typeParameter)
        {
            this.BooleanName = (typeParameter as IIntegerBooleanTypeParameter).BooleanName;
            this.BooleanValue = (typeParameter as IIntegerBooleanTypeParameter).BooleanValue;
        }

        public IntegerBooleanTypeParameter(
          string integerName,
          string booleanName,
          ICellDataFormat cellDataFormat,
          Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
          : base(integerName, cellDataFormat, createCellDataFormat)
        {
            this.BooleanName = booleanName;
        }

        public bool BooleanValue
        {
            get => this.booleanValue;
            set
            {
                this.NotifyPropertyChanged(ref this.booleanValue, value);

                // deserialization guard
                if (this.createCellDataFormat != null)
                {
                    this.cellDataFormat = this.createCellDataFormat(this);
                    this.NotifyPropertyChanged(nameof(this.Example));
                }
            }
        }

        public string BooleanName { get; set; }

        public override ParameterType Type => ParameterType.IntegerBoolean;

        public override object[] GetParameterNameValuePairs() => new object[]
            {
                this.IntegerName,
                this.IntegerValue,
                this.BooleanName,
                this.BooleanValue
            };

        public override void UpdateValues(IReadOnlyDictionary<string, object> namedValues)
        {
            if (namedValues.TryGetValue(this.IntegerName, out object value1))
            {
                this.IntegerValue = value1 is int v ? v : this.IntegerValue;
            }

            if (namedValues.TryGetValue(this.BooleanName, out object value2))
            {
                this.BooleanValue = value2 is bool v ? v : this.BooleanValue;
            }
        }

        protected override void InternalCloneParameters(ITypeParameter other)
        {
            IIntegerBooleanTypeParameter local = other as IIntegerBooleanTypeParameter;
            this.IntegerName = local.IntegerName;
            this.IntegerValue = local.IntegerValue;
            this.BooleanName = local.BooleanName;
            this.BooleanValue = local.BooleanValue;
        }
    }
}
