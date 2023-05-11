namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;

internal abstract class AccessibilityCreator : IAccessibilityCreator
{
    public abstract bool IsApplicable(string accessibility);

    public abstract string Create(string accessibility);
}
