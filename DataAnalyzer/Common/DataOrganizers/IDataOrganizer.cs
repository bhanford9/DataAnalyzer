using DataAnalyzer.StatConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers;

internal interface IDataOrganizer
{
    public IHeirarchalStats Organize(IStatsConfiguration configuration, ICollection<IStats> data);
}
