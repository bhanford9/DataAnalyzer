using DataAnalyzer.Services;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Models.ImportModels
{
    internal interface IImportFromFileModel : IImportModel
    {
        string ActiveDirectory { get; }

        void ApplyActiveDirectory(IImportType import, IScraperCategory category, IScraperFlavor flavor);
        void ApplyActiveDirectory(ImportKey key);
        void ApplyActiveDirectory(string path);
    }
}