using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using ExcelService.CellDataFormats.NumericFormat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels
{
    internal class ExcelDataTypeLibrary
    {
        private readonly ICollection<ITypeParameter> typeParameters = new List<ITypeParameter>();

        public ExcelDataTypeLibrary()
        {
            this.LoadParameters();
        }

        public IReadOnlyDictionary<string, ITypeParameter> NamedTypeParameters { get; private set; }

        public ICollection<ITypeParameter> GetParameterTypes()
        {
            return this.typeParameters.ToList();
        }

        public ITypeParameter GetInstanceByName(string name)
        {
            ITypeParameter parameter = this.NamedTypeParameters[name];
            return (ITypeParameter)Activator.CreateInstance(parameter.GetType(), parameter);
        }

        private void LoadParameters()
        {
            this.typeParameters.Add(new IntegerTypeParameter(
              "Decimal Count:",
              new FloatingPrecisionCellDataFormat(0),
              (param) => new FloatingPrecisionCellDataFormat((param as IntegerTypeParameter).IntegerValue)));

            this.typeParameters.Add(new IntegerTypeParameter(
              "Decimal Count:",
              new FloatingPrecisionWithSeparatorCellDataFormat(0),
              (param) => new FloatingPrecisionWithSeparatorCellDataFormat((param as IntegerTypeParameter).IntegerValue)));

            this.typeParameters.Add(new IntegerBooleanTypeParameter(
              "Decimal Count:",
              "Red when Negative:",
              new FloatingSeparatorParensCellDataFormat(0, false),
              (param) => new FloatingSeparatorParensCellDataFormat(
                (param as IntegerBooleanTypeParameter).IntegerValue,
                (param as IntegerBooleanTypeParameter).BooleanValue)));

            this.typeParameters.Add(new IntegerTypeParameter(
              "Digit Count:",
              new FractionCellDataFormat(0),
              (param) => new FractionCellDataFormat((param as IntegerTypeParameter).IntegerValue)));

            this.typeParameters.Add(new NoTypeParameter(
              new GeneralNumericCellDataFormat(),
              (param) => new GeneralNumericCellDataFormat()));

            this.typeParameters.Add(new NoTypeParameter(
              new IntegerCellDataFormat(),
              (param) => new IntegerCellDataFormat()));

            this.typeParameters.Add(new NoTypeParameter(
              new IntegerSeparatorParensCellDataFormat(),
              (param) => new IntegerSeparatorParensCellDataFormat()));

            this.typeParameters.Add(new NoTypeParameter(
              new IntegerWIthSeparatorCellDataFormat(),
              (param) => new IntegerWIthSeparatorCellDataFormat()));

            this.typeParameters.Add(new NoTypeParameter(
              new NumericAsStringCellDataFormat(),
              (param) => new NumericAsStringCellDataFormat()));

            this.typeParameters.Add(new IntegerTypeParameter(
              "Decimal Count:",
              new PercentFloatingPrecisionCellDataFormat(0),
              (param) => new PercentFloatingPrecisionCellDataFormat((param as IntegerTypeParameter).IntegerValue)));

            this.typeParameters.Add(new NoTypeParameter(
              new PercentIntegerCellDataFormat(),
              (param) => new PercentIntegerCellDataFormat()));

            this.typeParameters.Add(new IntegerTypeParameter(
              "Decimal Count:",
              new ScientificFloatingPrecisionCellDataFormat(0),
              (param) => new ScientificFloatingPrecisionCellDataFormat((param as IntegerTypeParameter).IntegerValue)));

            this.typeParameters.Add(new IntegerIntegerTypeParameter(
              "Whole Number Digits:",
              "Decimal Count:",
              new ZeroPrependFloatingPrecisionCellDataFormat(0, 0),
              (param) => new ZeroPrependFloatingPrecisionCellDataFormat(
                (param as IntegerIntegerTypeParameter).Integer1Value,
                (param as IntegerIntegerTypeParameter).Integer2Value)));

            this.typeParameters.Add(new IntegerTypeParameter(
              "Whole Number Digits:",
              new ZeroPrependIntegerCellDataFormat(0),
              (param) => new ZeroPrependIntegerCellDataFormat((param as IntegerTypeParameter).IntegerValue)));

            this.NamedTypeParameters = this.typeParameters.ToDictionary(x => x.ExcelTypeName, x => x);
        }
    }
}
