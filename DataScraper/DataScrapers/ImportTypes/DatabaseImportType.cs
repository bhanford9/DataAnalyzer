namespace DataScraper.DataScrapers.ImportTypes;

public interface IDatabaseImportType : IImportType { }
public class DatabaseImportType : ImportType<DatabaseImportType>, IDatabaseImportType
{
    public override string Name => "Database";
}
