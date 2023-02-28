using DataAnalyzer.Common.DataObjects;
using DataScraper.Data;
using System;

namespace DataAnalyzer.Common.DataConverters.CsvConverters
{
    internal class CsvToTestConverter : DataConverter
    {
        public override IData InstantiateData()
        {
            throw new NotImplementedException();
        }

        public override IStats InstantiateStats()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidData(IData data)
        {
            throw new NotImplementedException();
        }

        public override IStats ToAnalyzerStats(IData data)
        {
            throw new NotImplementedException();
        }
    }
}
