using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using System.Collections.Generic;

namespace DataAnalyzer.Models.Utilities
{
    internal class ExecutiveLibrary :
        Dictionary<
            IImportType,
            IDictionary<
                IScraperCategory,
                IDictionary<
                    IScraperFlavor,
                    IDictionary<ExportType, ExecutiveType>>>>
    {
        public ExecutiveLibrary()
        {
            FileImportType fileType = new FileImportType();
            this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDictionary<ExportType, ExecutiveType>>>();

            CsvNamesScraperCategory csvNamesScraper = new CsvNamesScraperCategory();
            CsvNamesStandardScraperFlavor csvStandardFlavor = new CsvNamesStandardScraperFlavor();
            this[fileType][csvNamesScraper] = new Dictionary<IScraperFlavor, IDictionary<ExportType, ExecutiveType>>
            {
                [csvStandardFlavor] = new Dictionary<ExportType, ExecutiveType>
                {
                    [ExportType.CSharpStringProperties] = ExecutiveType.CsvToCSharpClass
                }
            };

            QueryableScraperCategory queryableCategory = new QueryableScraperCategory();
            QueryableStandardScraperFlavor standardQueryableFlavor = new QueryableStandardScraperFlavor();
            this[fileType][queryableCategory] = new Dictionary<IScraperFlavor, IDictionary<ExportType, ExecutiveType>>
            {
                [standardQueryableFlavor] = new Dictionary<ExportType, ExecutiveType>
                {
                    [ExportType.Excel] = ExecutiveType.CreateQueryableExcelReport
                }
            };
        }

        public ExecutiveType GetExecutiveType(
            IImportType importType,
            IScraperCategory category,
            IScraperFlavor flavor,
            ExportType exportType)
        {
            try
            {
                return this[importType][category][flavor][exportType];
            }
            catch
            {
                return ExecutiveType.NotSupported;
            }
        }
    }
}
