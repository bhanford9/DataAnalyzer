namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.AccessibilityCreators;

internal class ReadWriteCreator : AccessibilityCreator, IReadWriteCreator
{
    public override string Create(string accessibility) => "{ get; set; }";

    public override bool IsApplicable(string accessibility) => accessibility.Equals(ClassCreationConstants.READ_WRITE);
}
