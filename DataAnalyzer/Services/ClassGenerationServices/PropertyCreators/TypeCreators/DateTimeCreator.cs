namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators;

internal class DateTimeCreator : TypeCreator, IDateTimeCreator
{
    // TODO --> may need a way to handle importing a using statement

    public override string Create(string dataType) => "DateTime";

    public override bool IsApplicable(string dataType)
        => dataType.Equals(ClassCreationConstants.DATE_TIME_TYPE_DISPLAY);
}
