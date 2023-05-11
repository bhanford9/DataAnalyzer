using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.Utilities;

internal class ClassData : IClassData
{
    public string ClassName { get; set; } = string.Empty;

    public string Accessibility { get; set; } = string.Empty;

    public IReadOnlyCollection<IPropertyData> Properties { get; set; } = new List<IPropertyData>();
}
