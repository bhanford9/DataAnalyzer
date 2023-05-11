namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;

internal interface IClassPropertyData
{
    string Accessibility { get; set; }
    string DataType { get; set; }
    string Name { get; set; }
}