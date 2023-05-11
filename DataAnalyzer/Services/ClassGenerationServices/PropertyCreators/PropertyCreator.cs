using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;
using DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators;
using System;

namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators;

internal class PropertyCreator : IPropertyCreator
{
    private readonly ITypeCreationExecutive typeCreationExecutive;
    private readonly IAccessibilityCreationExecutive accessibilityCreationExecutive;

    public PropertyCreator(
        ITypeCreationExecutive typeCreationExecutive,
        IAccessibilityCreationExecutive accessibilityCreationExecutive)
    {
        this.typeCreationExecutive = typeCreationExecutive;
        this.accessibilityCreationExecutive = accessibilityCreationExecutive;
    }

    // this should just be static and pass statAccessors into the method instead
    public string Create(string propertyName, string dataType, string accessibility)
    {
        string typeString = this.typeCreationExecutive.Create(dataType);
        string accessibilityString = this.accessibilityCreationExecutive.Create(accessibility);
        string lineStart = $"{Environment.NewLine}    ";
        string lineEnd = $"{Environment.NewLine}";

        return $"{lineStart}public {typeString} {propertyName} {accessibilityString}{lineEnd}";
    }
}
