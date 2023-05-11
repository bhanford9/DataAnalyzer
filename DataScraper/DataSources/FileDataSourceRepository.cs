using System.Collections.Generic;
using System.Linq;

namespace DataScraper.DataSources;

internal class FileDataSourceRepository : IFileDataSourceRepository
{
    private IReadOnlyCollection<IFileDataSource> fileDataSources;

    public FileDataSourceRepository(IReadOnlyCollection<IFileDataSource> fileDataSources)
    {
        this.fileDataSources = fileDataSources;
    }

    public IFileDataSource GetFileDataSource(string path)
        => this.fileDataSources
            .FirstOrDefault(x => path.EndsWith(x.GetExpectedExtension()))
            .Initialize(path);
}
