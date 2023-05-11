using DataAnalyzer.Services;
using DataScraper;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Models.ImportModels;

internal interface IFileMap : IFlavoredCategorizedDataLibrary<string>
{
    string MapFile(IImportType import, IScraperCategory category, IScraperFlavor flavor, string rootPath, string fileName = "");
    string MapFile(ImportKey key, string rootPath, string fileName = "");
}