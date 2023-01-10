using DataAnalyzer.Common.DataObjects;
using DataScraper.Data;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataConverters
{
    // TODO --> Stats and Data should be named wrt incoming & internal (Stats are internal to UI)
    internal abstract class DataConverter : IDataConverter
    {
        public abstract ConverterType Type { get; }

        public abstract bool IsValidData(IData data);

        public abstract IStats InstantiateStats();

        public abstract IData InstantiateData();

        public abstract IStats ToAnalyzerStats(IData data);

        public ICollection<IStats> ToAnalyzerStats(ICollection<IData> data)
        {
            return data.Select(x => this.ToAnalyzerStats(x)).ToList();
        }
    }
}
