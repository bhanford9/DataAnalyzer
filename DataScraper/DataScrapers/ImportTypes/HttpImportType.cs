namespace DataScraper.DataScrapers.ImportTypes;

public interface IHttpImportType : IImportType { }
public class HttpImportType : ImportType<HttpImportType>, IHttpImportType
{
    public override string Name => "HTTP";
}
