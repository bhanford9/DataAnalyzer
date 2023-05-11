using System.Collections.Generic;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels;

internal interface IClassesData
{
    ICollection<IClassData> Classes { get; set; }
}