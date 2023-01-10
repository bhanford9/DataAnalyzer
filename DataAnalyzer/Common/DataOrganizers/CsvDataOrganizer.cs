using DataAnalyzer.Common.DataConfigurations.CsvConfigurations;
using DataAnalyzer.Common.DataObjects;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal class CsvDataOrganizer : DataOrganizer<CsvConfiguration>
    {
        protected override HeirarchalStats InternalOrganize(CsvConfiguration configuration, ICollection<IStats> data)
        {
            // TODO
            return new();
        }
    }
}
