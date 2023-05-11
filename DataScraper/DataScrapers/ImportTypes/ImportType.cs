namespace DataScraper.DataScrapers.ImportTypes;

public abstract class ImportType<T> : ScraperKey<T>, IImportType
     where T : IImportType, new()
{
}
