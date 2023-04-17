using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Services.ClassGenerationServices
{
    internal class ClassCreator : IClassCreator
    {
        private IPropertyCreator propertyCreator;

        public ClassCreator(IPropertyCreator propertyCreator)
        {
            this.propertyCreator = propertyCreator;
        }

        public string Create(string classAccessibility, string className, IReadOnlyCollection<(string Name, string Type, string Accessibility)> propertyData)
        {
            string classHeader = $"{classAccessibility} class {className}";
            string properties = propertyData.Aggregate(
                "",
                (result, current) => result + this.propertyCreator.Create(current.Name, current.Type, current.Accessibility));
            string nl = Environment.NewLine;
            return $"{classHeader}{nl}{{{nl}{properties}{nl}}}";
        }
    }
}
