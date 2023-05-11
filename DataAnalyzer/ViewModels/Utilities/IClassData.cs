using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal interface IClassData
    {
        string Accessibility { get; set; }
        string ClassName { get; set; }
        IReadOnlyCollection<IPropertyData> Properties { get; set; }
    }
}