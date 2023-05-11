namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;

internal class ReadInitCreator : AccessibilityCreator, IReadInitCreator
{
    public override string Create(string accessibility) => "{ get; init; }";

    public override bool IsApplicable(string accessibility) => accessibility.Equals(ClassCreationConstants.READ_INIT);
}
