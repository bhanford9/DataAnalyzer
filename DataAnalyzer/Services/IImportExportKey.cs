using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Services;

internal interface IImportExecutionKey
{
    ExecutionType ExecutionType { get; init; }
    ImportKey ImportKey { get; init; }
    bool IsValid { get; }
    string Name { get; }

    bool Equals(object obj);
    int GetHashCode();
    string ToString();
    void Update(ExecutionType execution);
    void Update(IImportType type);
    void Update(IScraperCategory category);
    void Update(IScraperFlavor flavor);
}