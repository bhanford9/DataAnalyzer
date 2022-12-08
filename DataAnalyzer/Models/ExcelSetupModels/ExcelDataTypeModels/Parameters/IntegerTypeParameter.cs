using ExcelService.CellDataFormats;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
    internal class IntegerTypeParameter : TypeParameter
    {
        private int integerValue = 1;

        public IntegerTypeParameter() : base() { }

        public IntegerTypeParameter(ITypeParameter typeParameter) : base(typeParameter)
        {
            this.IntegerName = (typeParameter as IntegerTypeParameter).IntegerName;
            this.IntegerValue = (typeParameter as IntegerTypeParameter).IntegerValue;
        }

        public IntegerTypeParameter(
          string integerName,
          ICellDataFormat cellDataFormat,
          Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
          : base(cellDataFormat, createCellDataFormat)
        {
            this.IntegerName = integerName;
        }

        public int IntegerValue
        {
            get => this.integerValue;
            set
            {
                this.NotifyPropertyChanged(ref this.integerValue, value);

                // deserialization guard
                if (this.createCellDataFormat != null)
                {
                    this.cellDataFormat = this.createCellDataFormat(this);
                    this.NotifyPropertyChanged(nameof(this.Example));
                }
            }
        }

        public string IntegerName { get; set; }

        public override ParameterType Type => ParameterType.Integer;

        public override object[] GetParameterNameValuePairs()
        {
            return new object[]
            {
                this.IntegerName,
                this.IntegerValue
            };
        }

        public override void UpdateValues(IReadOnlyDictionary<string, object> namedValues)
        {
            this.IntegerValue = namedValues.TryGetValue(this.IntegerName, out object val) ? val is int v ? v : this.IntegerValue : this.IntegerValue;
        }

        protected override void InternalCloneParameters(ITypeParameter other)
        {
            IntegerTypeParameter local = other as IntegerTypeParameter;
            this.IntegerName = local.IntegerName;
            this.IntegerValue = local.IntegerValue;
        }
    }
}
