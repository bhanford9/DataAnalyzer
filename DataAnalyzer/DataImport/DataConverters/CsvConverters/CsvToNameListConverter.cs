using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataScraper.Data;
using DataScraper.Data.CsvData;
using System.Linq;

namespace DataAnalyzer.DataImport.DataConverters.CsvConverters
{
    internal class CsvToNameListConverter : DataConverter<CsvNamesStats, CsvNamesData>, ICsvToNameListConverter
    {
        public override bool IsValidData(IData data) => data is CsvNamesData;

        public override IStats ToAnalyzerStats(IData data)
        {
            CsvNamesData csvData = data as CsvNamesData;
            CsvNamesStats stats = new();
            csvData.CsvNames.ToList().ForEach(name => stats.CsvNames.Add(name));
            return stats;
        }
    }
}
