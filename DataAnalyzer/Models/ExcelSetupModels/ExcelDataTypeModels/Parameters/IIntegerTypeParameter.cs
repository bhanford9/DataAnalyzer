namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;

internal interface IIntegerTypeParameter : ITypeParameter
{
    string IntegerName { get; set; }
    int IntegerValue { get; set; }
}