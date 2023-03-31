using System.Collections.Generic;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels
{
    internal class ClassProperties : IClassProperties
    {
        public ICollection<IClassPropertyData> Properties { get; set; } = new List<IClassPropertyData>();
    }
}
