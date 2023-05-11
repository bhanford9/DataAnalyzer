using System.Collections.Generic;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;

internal class ClassesData : IClassesData
{
    public ICollection<IClassData> Classes { get; set; } = new List<IClassData>();
}
