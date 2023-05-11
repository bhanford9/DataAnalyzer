using DataAnalyzer.DataImport.DataObjects;
using DataScraper.Data;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.DataImport.DataConverters;

// TODO --> Stats and Data should be named wrt incoming & internal (Stats are internal to UI)
internal abstract class DataConverter<TStats, TData> : IDataConverter
    where TStats : IStats, new()
    where TData : IData, new()
{
    public abstract bool IsValidData(IData data);

    public abstract IStats ToAnalyzerStats(IData data);

    public TStats InstantiateStats() => new();

    public TData InstantiateData() => new();

    public ICollection<IStats> ToAnalyzerStats(ICollection<IData> data) => data.Select(x => ToAnalyzerStats(x)).ToList();
}
