namespace DataScraper.DataSources;

public interface IFileDataSourceRepository
{
    IFileDataSource GetFileDataSource(string path);
}