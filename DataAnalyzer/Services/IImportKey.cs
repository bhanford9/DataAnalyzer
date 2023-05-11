using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Services;

internal interface IImportKey
{
    IScraperCategory Category { get; init; }
    IScraperFlavor Flavor { get; init; }
    string Name { get; init; }
    IImportType Type { get; init; }

    bool Equals(object obj);
    int GetHashCode();
    string ToString();
    void Update(IImportType type);
    void Update(IScraperCategory category);
    void Update(IScraperFlavor flavor);
}