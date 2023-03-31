namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels
{
    internal class ClassPropertyData : IClassPropertyData
    {
        public string Name { get; set; } = string.Empty;

        public string DataType { get; set; } = string.Empty;

        public string Accessibility { get; set; } = string.Empty;
    }
}
