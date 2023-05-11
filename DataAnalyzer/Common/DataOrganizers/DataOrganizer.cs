using DataAnalyzer.StatConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers;

internal abstract class DataOrganizer<T> : IDataOrganizer
    where T : IStatsConfiguration
{
    public IHeirarchalStats Organize(IStatsConfiguration configuration, ICollection<IStats> data) =>
        this.InternalOrganize((T)configuration, data);

    protected abstract IHeirarchalStats InternalOrganize(T configuration, ICollection<IStats> data);
}
