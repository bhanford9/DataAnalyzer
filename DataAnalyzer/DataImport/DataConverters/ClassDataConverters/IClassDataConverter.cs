using DataAnalyzer.DataImport.DataObjects;
using DataScraper.Data;

namespace DataAnalyzer.DataImport.DataConverters.ClassDataConverters;

internal interface IClassDataConverter : IDataConverter
{
    bool IsValidData(IData data);
    IStats ToAnalyzerStats(IData data);
}