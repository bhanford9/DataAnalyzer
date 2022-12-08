using DataAnalyzer.Common.DataObjects;
using DataScraper.Data;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataConverters
{
    internal interface IDataConverter
    {
        ConverterType Type { get; }

        bool IsValidData(IData timeData);
        ICollection<IStats> ToAnalyzerStats(ICollection<IData> timeData);
        IStats ToAnalyzerStats(IData timeData);
    }
}