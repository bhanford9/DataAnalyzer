using DataAnalyzer.StatConfigurations.CsvConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal class CsvDataOrganizer : DataOrganizer<ClassPropertiesConfiguration>
    {
        protected override HeirarchalStats InternalOrganize(ClassPropertiesConfiguration configuration, ICollection<IStats> data) => new HeirarchalStats()
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
