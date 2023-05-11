namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators;

internal class BoolCreator : TypeCreator, IBoolCreator
{
    public override string Create(string dataType) => "bool";

    public override bool IsApplicable(string dataType)
        => dataType.Equals(ClassCreationConstants.BOOL_TYPE_DISPLAY);
}
