using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataObjects.CsvStats;
using DataScraper.Data;
using DataScraper.Data.CsvData;

namespace DataAnalyzer.Common.DataConverters.CsvConverters
{
    internal class CsvToTestConverter : DataConverter
    {
        public override IData InstantiateData() => new CsvTestData();

        public override IStats InstantiateStats() => new CsvTestStats();

        public override bool IsValidData(IData data) => data is CsvTestData;

        public override IStats ToAnalyzerStats(IData data)
        {
            CsvTestData csvData = data as CsvTestData;
            CsvTestStats csvStats = new()
            {
                Date = csvData.Date,
                Name = csvData.Name,
                Age = csvData.Age,
                Gender = csvData.Gender
            };

            return csvStats;
        }
    }
}
