using System.Collections.Generic;
using System.Linq;
using DataAnalyzer.Common.DataConverters.TimeStatConverters.QueryableTimeStatConverters;

namespace DataAnalyzer.Common.DataConverters
{
  public class DataConverterLibrary
  {
    private readonly ICollection<IDataConverter> converters = new List<IDataConverter>();

    private void LoadConverters()
    {
      this.converters.Add(new QueryableTimeStatsConverter());
    }

    public DataConverterLibrary()
    {
      this.LoadConverters();
    }

    public IDataConverter GetConverter(ConverterType type)
    {
      return this.converters.First(x => x.Type == type);
    }
  }
}
