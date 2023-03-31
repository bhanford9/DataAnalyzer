using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataScraper.Data;
using DataScraper.Data.CsvData;

namespace DataAnalyzer.DataImport.DataConverters.CsvConverters
{
    internal class CsvToTestConverter : DataConverter<CsvTestStats, CsvTestData>, ICsvToTestConverter
    {
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
