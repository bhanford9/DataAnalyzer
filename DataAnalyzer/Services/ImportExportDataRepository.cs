using DataAnalyzer.Services.Enums;
using DataScraper;
using DataScraper.DataScrapers.ScraperFlavors;
using System;
using System.Collections.Generic;
using System.Linq;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;

namespace DataAnalyzer.Services
{
    internal static class Extensions
    {
        public static IDictionary<ExportType, T> AddExport<T>(
            this IDictionary<ExportType, T> source,
            ExportType exportType,
            T data)
        {
            source.Add(exportType, data);
            return source;
        }

        public static IDictionary<IScraperFlavor, IDictionary<ExportType, T>> WithFlavoredData<T>(
            this IDictionary<IScraperFlavor, IDictionary<ExportType, T>> source,
            IScraperFlavor flavor,
            ExportType exportType,
            T aggregateDatas)
        {
            if (!source.ContainsKey(flavor))
            {
                source[flavor] = new Dictionary<ExportType, T>();
            }

            source[flavor][exportType] = aggregateDatas;
            return source;
        }

        public static T GetData<T>(this IImportExportDataRepository<T> source, IImportExportKey key)
            => source[key.ImportKey.Type, key.ImportKey.Category, key.ImportKey.Flavor, key.ExportType];

        public static T GetDataOrDefault<T>(this IImportExportDataRepository<T> source, IImportExportKey key)
        {
            source.TryGetData(key, out T data);
            return data;
        }

        public static bool TryGetData<T>(
            this IImportExportDataRepository<T> source,
            IImportExportKey key,
            out T data)
        {
            try
            {
                data = source.GetData(key);
                return true;
            }
            catch
            {
                data = default;
                return false;
            }
        }

        public static T GetDataOr<T>(
            this IImportExportDataRepository<T> source,
            IImportExportKey key,
            Func<IImportExportDataRepository<T>, T> defaultValueGetter)
            => !source.TryGetData(key, out T data) ? defaultValueGetter(source) : data;

        public static IEnumerable<TExtracted> GetAll<TSource, TExtracted>(
            this ImportExportDataRepository<TSource> source,
            Func<TSource, TExtracted> getter)
            => source.Values
                .SelectMany(x => x.Values
                    .SelectMany(y => y.Values
                        .SelectMany(z => z.Values.Select(getter))));
    }

    internal abstract class ImportExportDataRepository<T> : FlavoredCategorizedDataLibrary<IDictionary<ExportType, T>>, IImportExportDataRepository<T>
    {
        public T this[IImportType type, IScraperCategory category, IScraperFlavor flavor, ExportType export]
            => this[type][category][flavor][export];

        public override abstract string Name { get; }
    }
}
