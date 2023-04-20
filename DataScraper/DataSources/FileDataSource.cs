namespace DataScraper.DataSources
{
    public class FileDataSource : DataSource, IFileDataSource
    {
        public FileDataSource(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; init; }
    }
}
