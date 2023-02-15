namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators
{
    internal class StringCreator : TypeCreator
    {
        public override string Create(string dataType) => "string";

        public override bool IsApplicable(string dataType) => dataType.Equals(ClassCreationConstants.STRING_TYPE);
    }
}
