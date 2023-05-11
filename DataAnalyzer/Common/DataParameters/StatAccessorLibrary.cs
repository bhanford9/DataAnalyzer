using DataAnalyzer.Common.DataParameters.CsvParameters;
using DataAnalyzer.Common.DataParameters.TimeStatParameters;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataParameters;

// TODO --> this whole class needs to be nested dictionaries
//  --> This should not be named as data paramter. This is a mapping to a stats parameter retriever
internal class StatAccessorLibrary : IStatAccessorLibrary
{
    private readonly IReadOnlyDictionary<Type, IStatAccessorCollection> accessorCollections;

    public StatAccessorLibrary(IReadOnlyDictionary<Type, IStatAccessorCollection> parameters)
    {
        this.accessorCollections = parameters;
    }

    internal static IReadOnlyDictionary<Type, IStatAccessorCollection> GetStatAccessorMap() =>
        new Dictionary<Type, IStatAccessorCollection>()
        {
            { typeof(QueryableTimeStats), Resolver.Resolve<IQueryableParameters>() },
            { typeof(CsvNamesStats), Resolver.Resolve<ICsvClassParameters>() },
        };

    public IStatAccessorCollection GetStatAccessors(Type statType) =>
        this.accessorCollections.TryGetValue(statType, out IStatAccessorCollection parameters) ? parameters : default;

    public IStatAccessorCollection this[Type statType] => GetStatAccessors(statType);

    // TODO --> would be much simpler to just use this instead of the above methods
    public TValue GetData<TValue, TStats>(TStats stats, string name)
        where TValue : IComparable
        where TStats : IStats
        => (TValue)this.GetStatAccessors(stats.GetType()).GetStatAccessor(name)(stats);
}
