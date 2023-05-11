using DataAnalyzer.Services.Enums;
using DataScraper;
using DataScraper.DataScrapers.ScraperFlavors;
using System;
using System.Collections.Generic;
using System.Linq;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;

namespace DataAnalyzer.Services;

internal static class Extensions
{
    public static IDictionary<ExecutionType, T> AddExecution<T>(
        this IDictionary<ExecutionType, T> source,
        ExecutionType executionType,
        T data)
    {
        source.Add(executionType, data);
        return source;
    }

    public static IDictionary<IScraperFlavor, IDictionary<ExecutionType, T>> WithFlavoredData<T>(
        this IDictionary<IScraperFlavor, IDictionary<ExecutionType, T>> source,
        IScraperFlavor flavor,
        ExecutionType executionType,
        T aggregateDatas)
    {
        if (!source.ContainsKey(flavor))
        {
            source[flavor] = new Dictionary<ExecutionType, T>();
        }

        source[flavor][executionType] = aggregateDatas;
        return source;
    }

    public static T GetData<T>(this IImportExecutionDataRepository<T> source, IImportExecutionKey key)
        => source[key.ImportKey.Type, key.ImportKey.Category, key.ImportKey.Flavor, key.ExecutionType];

    public static T GetDataOrDefault<T>(this IImportExecutionDataRepository<T> source, IImportExecutionKey key)
    {
        source.TryGetData(key, out T data);
        return data;
    }

    public static bool TryGetData<T>(
        this IImportExecutionDataRepository<T> source,
        IImportExecutionKey key,
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
        this IImportExecutionDataRepository<T> source,
        IImportExecutionKey key,
        Func<IImportExecutionDataRepository<T>, T> defaultValueGetter)
        => !source.TryGetData(key, out T data) ? defaultValueGetter(source) : data;

    public static IEnumerable<TExtracted> GetAll<TSource, TExtracted>(
        this ImportExecutionDataRepository<TSource> source,
        Func<TSource, TExtracted> getter)
        => source.Values
            .SelectMany(x => x.Values
                .SelectMany(y => y.Values
                    .SelectMany(z => z.Values.Select(getter))));
}

internal abstract class ImportExecutionDataRepository<T> : FlavoredCategorizedDataLibrary<IDictionary<ExecutionType, T>>, IImportExecutionDataRepository<T>
{
    public T this[IImportType type, IScraperCategory category, IScraperFlavor flavor, ExecutionType execution]
        => this[type][category][flavor][execution];

    public override abstract string Name { get; }
}
