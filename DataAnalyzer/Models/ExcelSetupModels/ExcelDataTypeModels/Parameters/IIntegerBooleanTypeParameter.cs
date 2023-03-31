namespace DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters
{
    internal interface IIntegerBooleanTypeParameter : IIntegerTypeParameter
    {
        string BooleanName { get; set; }
        bool BooleanValue { get; set; }
    }
}