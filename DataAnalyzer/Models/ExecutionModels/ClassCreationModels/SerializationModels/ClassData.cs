namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;

internal class ClassData : IClassData
{
    public string ClassName { get; set; } = string.Empty;

    public string Accessibility { get; set; } = string.Empty;

    public IClassProperties ClassProperties { get; set; } = new ClassProperties();
}
