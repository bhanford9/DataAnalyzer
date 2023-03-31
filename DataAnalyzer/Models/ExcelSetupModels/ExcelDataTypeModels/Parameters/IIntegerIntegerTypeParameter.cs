namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
    internal interface IIntegerIntegerTypeParameter : ITypeParameter
    {
        string Integer1Name { get; set; }
        int Integer1Value { get; set; }
        string Integer2Name { get; set; }
        int Integer2Value { get; set; }
    }
}