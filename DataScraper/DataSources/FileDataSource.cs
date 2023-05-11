using System.IO;

namespace DataScraper.DataSources;

public abstract class FileDataSource : DataSource, IFileDataSource
{
    public string FilePath { get; private set; }

    public IFileDataSource Initialize(string filePath)
    {
        this.FilePath = filePath;
        return this;
    }

    public abstract string GetExpectedExtension();

    protected override bool IsValidSource()
        => !string.IsNullOrWhiteSpace(this.FilePath)
        && Path.GetExtension(this.FilePath).Equals(this.GetExpectedExtension());

}
