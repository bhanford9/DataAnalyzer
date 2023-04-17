namespace DataAnalyzer.Services.ClassGenerationServices.PropertyCreators
{
    internal interface IPropertyCreator
    {
        string Create(string propertyName, string dataType, string accessibility);
    }
}