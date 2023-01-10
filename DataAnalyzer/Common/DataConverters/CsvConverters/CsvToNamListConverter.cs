using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataObjects.CsvStats;
using DataScraper.Data;
using DataScraper.Data.CsvData;
using System.Linq;

namespace DataAnalyzer.Common.DataConverters.CsvConverters
{
    internal class CsvToNameListConverter : DataConverter
    {
        public override ConverterType Type => ConverterType.CsvNames;

        public override IData InstantiateData()
        {
            return new CsvNamesData();
        }

        public override IStats InstantiateStats()
        {
            return new CsvNamesStats();
        }

        public override bool IsValidData(IData data)
        {
            return data is CsvNamesData;
        }

        public override IStats ToAnalyzerStats(IData data)
        {
            CsvNamesData csvData = data as CsvNamesData;
            CsvNamesStats stats = new();
            csvData.CsvNames.ToList().ForEach(name => stats.ParameterNames.Add(name));
            return stats;
        }
    }
}
