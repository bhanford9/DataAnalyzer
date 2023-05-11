namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;

internal interface IClassData
{
    string ClassName { get; set; }

    string Accessibility { get; set; }
    IClassProperties ClassProperties { get; set; }
}