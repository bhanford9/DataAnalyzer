namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators
{
    internal class DoubleCreator : TypeCreator
    {
        public override string Create(string dataType) => "double";

        public override bool IsApplicable(string dataType) => dataType.Equals(ClassCreationConstants.DOUBLE_TYPE);
    }
}
