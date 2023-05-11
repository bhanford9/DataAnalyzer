namespace DataScraper.DataScrapers.ImportTypes;

public interface IFileImportType : IImportType { }
public class FileImportType : ImportType<FileImportType>, IFileImportType
{
    public override string Name => "File";
}
