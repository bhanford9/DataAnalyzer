using DataScraper;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using DataAnalyzer.Models.ExecutiveUtilities.Executives;
using DataAnalyzer.Services.Enums;
using System.Linq;

namespace DataAnalyzer.Models.ExecutiveUtilities
{
    internal static class Extensions
    {
        public static IDictionary<ExportType, IAggregateExecutives> AddExport(
            this IDictionary<ExportType, IAggregateExecutives> source,
            ExportType exportType,
            IAggregateExecutives data)
        {
            source.Add(exportType, data);
            return source;
        }

        public static IDictionary<IScraperFlavor, IDictionary<ExportType, IAggregateExecutives>> WithFlavoredExecutive(
            this IDictionary<IScraperFlavor, IDictionary<ExportType, IAggregateExecutives>> source,
            IScraperFlavor flavor,
            ExportType exportType,
            IAggregateExecutives aggregateExecutives)
        {
            if (!source.ContainsKey(flavor))
            {
                source[flavor] = new Dictionary<ExportType, IAggregateExecutives>();
            }

            source[flavor][exportType] = aggregateExecutives;
            return source;
        }
    }

    internal class ExecutiveUtilitiesRepository : FlavoredCategorizedDataLibrary<IDictionary<ExportType, IAggregateExecutives>>
    {
        public ExecutiveUtilitiesRepository()
        {
            FileImportType fileType = new();
            //DatabaseImportType databaseType = new DatabaseImportType();
            //HttpImportType httpType = new HttpImportType();

            this[fileType] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, IDictionary<ExportType, IAggregateExecutives>>>();

            this.InitializeCategory(fileType, new QueryableScraperCategory())
                .WithFlavoredExecutive(new QueryableStandardScraperFlavor(), ExportType.Excel, new QueryableExcelCreation());
            
            this.InitializeCategory(fileType, new CsvNamesScraperCategory())
                .WithFlavoredExecutive(new CsvNamesStandardScraperFlavor(), ExportType.CSharpStringProperties, new CsvCSharpClassCreation())
                .WithFlavoredExecutive(new CsvNamesStandardScraperFlavor(), ExportType.CSharpStringProperties, new CsvTest());
        }

        public override string Name => "Executive Utilities";

        public IReadOnlyCollection<ExportType> GetExportTypes(IImportType import, IScraperCategory category, IScraperFlavor flavor)
            => this[import][category][flavor].Keys.ToList();

        public IReadOnlyCollection<string> GetExportTypeNamess(IImportType import, IScraperCategory category, IScraperFlavor flavor)
            => GetExportTypes(import, category, flavor).Select(x => x.ToString()).ToList();
    }
}
