using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Services.ClassGenerationServices
{
    internal class ClassCreator
    {
        private readonly string classAccessibility = string.Empty;
        private readonly string className = string.Empty;
        private readonly IReadOnlyCollection<(string Name, string Type, string Accessibility)> propertyData = null;

        public ClassCreator(
            string classAccessibility,
            string className,
            IReadOnlyCollection<(string Name, string Type, string Accessibility)> propertyData)
        {
            this.classAccessibility = classAccessibility;
            this.className = className;
            this.propertyData = propertyData;
        }

        public string Create()
        {
            string classHeader = $"{this.classAccessibility} class {this.className}";
            string properties = this.propertyData.Aggregate(
                "",
                (result, current) => result + new PropertyCreator(current.Name, current.Type, current.Accessibility).Create());
            string nl = Environment.NewLine;
            return $"{classHeader}{nl}{{{nl}{properties}{nl}}}";
        }
    }
}
