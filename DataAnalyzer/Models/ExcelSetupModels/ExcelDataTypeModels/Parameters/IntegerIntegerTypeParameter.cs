using ExcelService.CellDataFormats;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
    internal class IntegerIntegerTypeParameter : TypeParameter
    {
        private int integer1Value = 1;
        private int integer2Value = 1;

        public IntegerIntegerTypeParameter() : base() { }

        public IntegerIntegerTypeParameter(ITypeParameter typeParameter) : base(typeParameter)
        {
            this.Integer1Name = (typeParameter as IntegerIntegerTypeParameter).Integer1Name;
            this.Integer1Value = (typeParameter as IntegerIntegerTypeParameter).Integer1Value;
            this.Integer2Name = (typeParameter as IntegerIntegerTypeParameter).Integer2Name;
            this.Integer2Value = (typeParameter as IntegerIntegerTypeParameter).Integer2Value;
        }

        public IntegerIntegerTypeParameter(
          string integer1Name,
          string integer2Name,
          ICellDataFormat cellDataFormat,
          Func<ITypeParameter, ICellDataFormat> createCellDataFormat)
          : base(cellDataFormat, createCellDataFormat)
        {
            this.Integer1Name = integer1Name;
            this.Integer2Name = integer2Name;
        }

        public int Integer1Value
        {
            get => this.integer1Value;
            set
            {
                this.NotifyPropertyChanged(ref this.integer1Value, value);

                // deserialization guard
                if (this.createCellDataFormat != null)
                {
                    this.cellDataFormat = this.createCellDataFormat(this);
                    this.NotifyPropertyChanged(nameof(this.Example));
                }
            }
        }

        public int Integer2Value
        {
            get => this.integer2Value;
            set
            {
                this.NotifyPropertyChanged(ref this.integer2Value, value);

                // deserialization guard
                if (this.createCellDataFormat != null)
                {
                    this.cellDataFormat = this.createCellDataFormat(this);
                    this.NotifyPropertyChanged(nameof(this.Example));
                }
            }
        }

        public string Integer1Name { get; set; }

        public string Integer2Name { get; set; }

        public override ParameterType Type => ParameterType.IntegerInteger;

        public override object[] GetParameterNameValuePairs()
        {
            return new object[]
            {
                this.Integer1Name,
                this.Integer1Value,
                this.Integer2Name,
                this.Integer2Value
            };
        }

        public override void UpdateValues(IReadOnlyDictionary<string, object> namedValues)
        {
            if (namedValues.TryGetValue(this.Integer1Name, out object value1))
            {
                this.Integer1Value = value1 is int v ? v : this.integer1Value;
            }

            if (namedValues.TryGetValue(this.Integer2Name, out object value2))
            {
                this.Integer2Value = value2 is int v ? v : this.integer2Value;
            }
        }

        protected override void InternalCloneParameters(ITypeParameter other)
        {
            IntegerIntegerTypeParameter local = other as IntegerIntegerTypeParameter;
            this.Integer1Name = local.Integer1Name;
            this.Integer1Value = local.Integer1Value;
        }
    }
}
