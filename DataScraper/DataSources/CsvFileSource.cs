namespace DataScraper.DataSources;

public class CsvFileSource : FileDataSource, ICsvFileSource
{
    public override string GetExpectedExtension() => ".csv";
}
