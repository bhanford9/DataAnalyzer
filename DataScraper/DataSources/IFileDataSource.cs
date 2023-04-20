namespace DataScraper.DataSources
{
    public interface IFileDataSource : IDataSource
    {
        string FilePath { get; init; }
    }
}