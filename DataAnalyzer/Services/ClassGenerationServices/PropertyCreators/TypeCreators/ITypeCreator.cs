namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators.TypeCreators;

internal interface ITypeCreator
{
    string Create(string dataType);
    bool IsApplicable(string dataType);
}