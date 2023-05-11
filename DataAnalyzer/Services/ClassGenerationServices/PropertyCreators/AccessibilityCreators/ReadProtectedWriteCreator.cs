namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;

internal class ReadProtectedWriteCreator : AccessibilityCreator, IReadProtectedWriteCreator
{
    public override string Create(string accessibility) => "{ get; protected set; }";

    public override bool IsApplicable(string accessibility) => accessibility.Equals(ClassCreationConstants.READ_PROTECTED_WRITE);
}
