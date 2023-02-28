using DataAnalyzer.Common.DataObjects;
using DataScraper.Data;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataConverters
{
    internal interface IDataConverter
    {
        bool IsValidData(IData data);
        ICollection<IStats> ToAnalyzerStats(ICollection<IData> data);
        IStats ToAnalyzerStats(IData data);
    }
}