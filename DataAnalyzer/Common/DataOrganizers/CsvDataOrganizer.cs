using DataAnalyzer.Common.DataConfigurations.CsvConfigurations;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataObjects.CsvStats;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal class CsvDataOrganizer : DataOrganizer<CsvConfiguration>
    {
        protected override HeirarchalStats InternalOrganize(CsvConfiguration configuration, ICollection<IStats> data)
        {
            return new HeirarchalStats()
            {
                Values = new List<IStats>() { new CsvNamesStats() { CsvNames = configuration.Names } }
            };
        }
    }
}
