using DataAnalyzer.DataImport.DataObjects;
using DataScraper.Data;
using System.Collections.Generic;

namespace DataAnalyzer.DataImport.DataConverters
{
    internal interface IDataConverter
    {
        bool IsValidData(IData data);
        ICollection<IStats> ToAnalyzerStats(ICollection<IData> data);
        IStats ToAnalyzerStats(IData data);
    }
}