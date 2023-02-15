using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;
using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators;
using System;

namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators
{
    internal class PropertyCreator
    {
        private readonly TypeCreationExecutive typeCreationExecutive = new();
        private readonly AccessibilityCreationExecutive accessibilityCreationExecutive = new();
        private string propertyName = string.Empty;
        private string dataType = string.Empty;
        private string accessibility = string.Empty;

        public PropertyCreator(string name, string dataType, string accessibility)
        {
            this.propertyName = name;
            this.dataType = dataType;
            this.accessibility = accessibility;
        }

        public string Create()
        {
            string typeString = this.typeCreationExecutive.Create(this.dataType);
            string accessibilityString = this.accessibilityCreationExecutive.Create(this.accessibility);
            string lineStart = $"{Environment.NewLine}    ";
            string lineEnd = $"{Environment.NewLine}";

            return $"{lineStart}public {typeString} {this.propertyName} {accessibilityString}{lineEnd}";
        }
    }
}
