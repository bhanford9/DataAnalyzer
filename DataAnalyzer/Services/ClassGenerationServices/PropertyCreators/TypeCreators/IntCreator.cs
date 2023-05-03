namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators
{
    internal class IntCreator : TypeCreator, IIntCreator
    {
        public override string Create(string dataType) => "int";

        public override bool IsApplicable(string dataType)
            => dataType.Equals(ClassCreationConstants.INT_TYPE_DISPLAY);
    }
}
