using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataScraper;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;

namespace DataAnalyzer.Services.ExecutiveUtilities
{
    internal interface IExecutiveUtilitiesRepository : IFlavoredCategorizedDataLibrary<IDictionary<ExportType, IAggregateExecutives>>
    {
        IEnumerable<IDataStructureSetupViewModel> StructureSetupViewModels { get; }
        IAggregateExecutives this[IImportType type, IScraperCategory category, IScraperFlavor flavor, ExportType export] { get; }

        IReadOnlyCollection<string> GetExportTypeNamess(IImportType import, IScraperCategory category, IScraperFlavor flavor);
        IReadOnlyCollection<ExportType> GetExportTypes(IImportType import, IScraperCategory category, IScraperFlavor flavor);
    }
}