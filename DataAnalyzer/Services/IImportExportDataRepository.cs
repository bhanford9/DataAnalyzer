using DataAnalyzer.Services.Enums;
using DataScraper;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;

namespace DataAnalyzer.Services;

internal interface IImportExecutionDataRepository<T> : IFlavoredCategorizedDataLibrary<IDictionary<ExecutionType, T>>
{
    T this[IImportType type, IScraperCategory category, IScraperFlavor flavor, ExecutionType execution] { get; }
}