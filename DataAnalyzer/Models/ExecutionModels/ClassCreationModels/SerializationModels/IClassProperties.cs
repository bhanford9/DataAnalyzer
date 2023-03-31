using System.Collections.Generic;

namespace DataAnalyzer.Models.ExecutionModels.ClassCreationModels.SerializationModels
{
    internal interface IClassProperties
    {
        ICollection<IClassPropertyData> Properties { get; set; }
    }
}