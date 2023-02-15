namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators
{
    internal abstract class TypeCreator : ITypeCreator
    {
        public abstract bool IsApplicable(string dataType);

        public abstract string Create(string dataType);
    }
}
