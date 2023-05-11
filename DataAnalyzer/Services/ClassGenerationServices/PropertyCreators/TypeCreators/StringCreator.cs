namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators;

internal class StringCreator : TypeCreator, IStringCreator
{
    public override string Create(string dataType) => "string";

    public override bool IsApplicable(string dataType)
        => dataType.Equals(ClassCreationConstants.STRING_TYPE_DISPLAY);
}
