using DataAnalyzer.DataImport.DataObjects;
using DataScraper.Data;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataConverters;

internal interface IDataConverterExecutive
{
    ICollection<IStats> Convert(IImportType type, IScraperCategory category, IScraperFlavor flavor, ICollection<IData> data);
    IStats Convert(IImportType type, IScraperCategory category, IScraperFlavor flavor, IData data);
    bool TryConvert(IImportType type, IScraperCategory category, IScraperFlavor flavor, IData data, out IStats stats);
}