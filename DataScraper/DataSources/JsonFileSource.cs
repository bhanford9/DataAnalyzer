namespace DataScraper.DataSources;

internal class JsonFileSource : FileDataSource, IJsonFileSource
{
    public override string GetExpectedExtension() => ".json";
}
