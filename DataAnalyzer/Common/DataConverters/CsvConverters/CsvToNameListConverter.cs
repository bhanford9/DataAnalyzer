using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataObjects.CsvStats;
using DataScraper.Data;
using DataScraper.Data.CsvData;
using System.Linq;

namespace DataAnalyzer.Common.DataConverters.CsvConverters
{
    internal class CsvToNameListConverter : DataConverter
    {
        public override IData InstantiateData() => new CsvNamesData();

        public override IStats InstantiateStats() => new CsvNamesStats();

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
