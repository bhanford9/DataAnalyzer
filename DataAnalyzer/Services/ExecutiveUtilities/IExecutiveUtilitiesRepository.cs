using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;

namespace DataAnalyzer.Services.ExecutiveUtilities
{
    internal interface IExecutiveUtilitiesRepository : IImportExportDataRepository<IAggregateExecutives>
    {
        //IEnumerable<IDataStructureSetupViewModel> StructureSetupViewModels { get; }
        IReadOnlyCollection<string> GetExportTypeNamess(IImportType import, IScraperCategory category, IScraperFlavor flavor);
        IReadOnlyCollection<ExportType> GetExportTypes(IImportType import, IScraperCategory category, IScraperFlavor flavor);
    }
}