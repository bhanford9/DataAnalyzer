using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;

namespace DataAnalyzer.Services.ExecutiveUtilities
{
    internal interface IExecutiveUtilitiesRepository : IImportExecutionDataRepository<IAggregateExecutives>
    {
        //IEnumerable<IDataStructureSetupViewModel> StructureSetupViewModels { get; }
        IReadOnlyCollection<string> GetExecutionTypeNamess(IImportType import, IScraperCategory category, IScraperFlavor flavor);
        IReadOnlyCollection<ExecutionType> GetExecutionTypes(IImportType import, IScraperCategory category, IScraperFlavor flavor);
    }
}