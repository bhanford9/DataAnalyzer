using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Services
{
    internal interface IImportExportKey
    {
        ExportType ExportType { get; init; }
        ImportKey ImportKey { get; init; }
        bool IsValid { get; }
        string Name { get; }

        bool Equals(object obj);
        int GetHashCode();
        string ToString();
        void Update(ExportType export);
        void Update(IImportType type);
        void Update(IScraperCategory category);
        void Update(IScraperFlavor flavor);
    }
}