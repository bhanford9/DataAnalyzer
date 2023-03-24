using DataScraper;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors.CsvNamesFlavors;
using DataScraper.DataScrapers.ScraperFlavors.QueryableFlavors;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using DataAnalyzer.Services.Enums;
using System.Linq;
using DataAnalyzer.Services.ExecutiveUtilities.Executives;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using System;
using System.Runtime.CompilerServices;

namespace DataAnalyzer.Services.ExecutiveUtilities
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

        public static IAggregateExecutives GetExecutive(this ExecutiveUtilitiesRepository source, ImportExportKey key)
            => source[key.ImportKey.Type][key.ImportKey.Category][key.ImportKey.Flavor][key.ExportType];

        public static IAggregateExecutives GetExecutiveOrDefault(this ExecutiveUtilitiesRepository source, ImportExportKey key)
        {
            source.TryGetExecutive(key, out IAggregateExecutives executive);
            return executive;
        }

        public static bool TryGetExecutive(this ExecutiveUtilitiesRepository source, ImportExportKey key, out IAggregateExecutives executive)
        {
            try
            {
                executive = source.GetExecutive(key);
                return true;
            }
            catch
            {
                executive = new NotSupportedExecutive();
                return false;
            }
        }

        public static IEnumerable<T> GetAll<T>(this ExecutiveUtilitiesRepository source, Func<IAggregateExecutives, T> getter) =>
            source.Values
                .SelectMany(x => x.Values
                    .SelectMany(y => y.Values
                        .SelectMany(z => z.Values.Select(getter))));
    }

    internal class ExecutiveUtilitiesRepository : FlavoredCategorizedDataLibrary<IDictionary<ExportType, IAggregateExecutives>>
    {
        private static readonly Lazy<ExecutiveUtilitiesRepository> instance = new(() => new ExecutiveUtilitiesRepository());

        public static ExecutiveUtilitiesRepository Instance => instance.Value;

        private ExecutiveUtilitiesRepository()
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

        public IEnumerable<IDataStructureSetupViewModel> StructureSetupViewModels => this.GetAll(x => x.DataStructureSetupViewModel);
    }
}
