namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;

internal class ReadPrivateWriteCreator : AccessibilityCreator, IReadPrivateWriteCreator
{
    public override string Create(string accessibility) => "{ get; private set; }";

    public override bool IsApplicable(string accessibility) => accessibility.Equals(ClassCreationConstants.READ_PRIVATE_WRITE);
}
