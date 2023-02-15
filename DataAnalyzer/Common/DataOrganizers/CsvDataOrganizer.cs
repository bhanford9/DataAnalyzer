using DataAnalyzer.Common.DataConfigurations.CsvConfigurations;
using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Common.DataObjects.CsvStats;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal class CsvDataOrganizer : DataOrganizer<ClassPropertiesConfiguration>
    {
        protected override HeirarchalStats InternalOrganize(ClassPropertiesConfiguration configuration, ICollection<IStats> data)
        {
            return new HeirarchalStats()
            {
                Values = new List<IStats>()
                {
                    new CsvNamesStats() 
                    { 
                        CsvNames = new ComparableList(configuration.PropertyNames)
                    }
                }
            };
        }
    }
}
