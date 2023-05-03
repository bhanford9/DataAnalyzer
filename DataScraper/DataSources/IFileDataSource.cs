namespace DataScraper.DataSources
{
    public interface IFileDataSource : IDataSource
    {
        string FilePath { get; }

        string GetExpectedExtension();
        IFileDataSource Initialize(string filePath);
    }
}