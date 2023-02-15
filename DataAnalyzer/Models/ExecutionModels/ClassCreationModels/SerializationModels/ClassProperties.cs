using System.Collections.Generic;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels
{
    internal class ClassProperties
    {
        public ICollection<ClassPropertyData> Properties { get; set; } = new List<ClassPropertyData>();
    }
}
