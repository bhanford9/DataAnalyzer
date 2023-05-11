using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.ApplicationConfigurations;

internal interface IApplicationConfiguration : IVersionedConfiguration
{
    IScraperCategory SelectedCategory { get; set; }
    ExecutionType SelectedExecution { get; set; }
    IScraperFlavor SelectedFlavor { get; set; }
    IImportType SelectedImport { get; set; }
}