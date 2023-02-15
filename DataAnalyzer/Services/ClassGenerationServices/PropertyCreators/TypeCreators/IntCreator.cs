namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators
{
    internal class IntCreator : TypeCreator
    {
        public override string Create(string dataType) => "int";

        public override bool IsApplicable(string dataType) => dataType.Equals(ClassCreationConstants.INT_TYPE);
    }
}
