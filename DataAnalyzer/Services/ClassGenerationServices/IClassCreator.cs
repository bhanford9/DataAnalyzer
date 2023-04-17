using System.Collections.Generic;

namespace DataAnalyzer.Services.ClassGenerationServices
{
    internal interface IClassCreator
    {
        string Create(
            string classAccessibility,
            string className,
            IReadOnlyCollection<(string Name, string Type, string Accessibility)> propertyData);
    }
}