using DataAnalyzer.Common.Mvvm;
using ExcelService.CellDataFormats;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
    internal abstract class TypeParameter : BasePropertyChanged, ITypeParameter
    {
        private string excelTypeName = string.Empty;
        protected Func<ITypeParameter, ICellDataFormat> createCellDataFormat;
        protected ICellDataFormat cellDataFormat;

        public TypeParameter() : base() { }

        public TypeParameter(ITypeParameter other) : this()
        {
            TypeParameter local = other as TypeParameter;
            this.createCellDataFormat = local.createCellDataFormat;
            this.cellDataFormat = local.cellDataFormat;
            this.DataName = local.DataName;
            this.ExcelTypeName =
            this.ExcelTypeName = this.cellDataFormat?.Name ?? "Non-Associated Data";
            this.CloneParameters(other);
        }

        public TypeParameter(
            ICellDataFormat cellDataFormat,
            Func<ITypeParameter, ICellDataFormat> createCellDataFormat) : this()
        {
            this.cellDataFormat = cellDataFormat;
            this.createCellDataFormat = createCellDataFormat;
            this.ExcelTypeName = this.cellDataFormat?.Name ?? "Non-Associated Data";

            this.NotifyPropertyChanged(nameof(this.ExcelTypeName));
        }

        public string ExcelTypeName
        {
            get => this.excelTypeName;
            set => this.NotifyPropertyChanged(ref this.excelTypeName, value);
        }

        public string Example => this.cellDataFormat.Example;

        public string DataName { get; set; } = string.Empty;

        public abstract ParameterType Type { get; }

        public abstract object[] GetParameterNameValuePairs();

        public ICellDataFormat CreateCellDataFormat() => this.createCellDataFormat(this);

        public void CloneParameters(ITypeParameter other)
        {
            this.DataName = other.DataName;
            this.InternalCloneParameters(other);
        }

        public abstract void UpdateValues(IReadOnlyDictionary<string, object> namedValues);

        public override bool Equals(object obj) => obj != null &&
                obj.GetType() == this.GetType() &&
                obj is ITypeParameter o &&
                o.ExcelTypeName.Equals(this.ExcelTypeName) &&
                o.DataName.Equals(this.DataName) &&
                o.Example.Equals(this.Example) &&
                o.Type.Equals(this.Type);

        protected abstract void InternalCloneParameters(ITypeParameter other);
    }
}