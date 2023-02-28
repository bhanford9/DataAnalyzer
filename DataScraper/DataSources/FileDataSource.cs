namespace DataScraper.DataSources
{
    public class FileDataSource : DataSource
    {
        public FileDataSource(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; init; }
    }
}
