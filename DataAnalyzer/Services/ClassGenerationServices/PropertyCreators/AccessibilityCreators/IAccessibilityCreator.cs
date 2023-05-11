namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;

internal interface IAccessibilityCreator
{
    string Create(string accessibility);
    bool IsApplicable(string accessibility);
}