using DataAnalyzer.Common.DataObjects;
using DataScraper.Data;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataConverters
{
  public abstract class DataConverter : IDataConverter
  {
    public abstract ConverterType Type { get; }

    protected abstract void InternalToAnalyzer(IData timeData, IStats timeStats);

    public abstract bool IsValidData(IData timeData);

    public abstract IStats InstantiateStats();

    public abstract IData InstantiateData();

    public abstract IStats ToAnalyzerStats(IData timeData);

    public ICollection<IStats> ToAnalyzerStats(ICollection<IData> timeData)
    {
      return timeData.Select(x => this.ToAnalyzerStats(x)).ToList();
    }
  }
}
