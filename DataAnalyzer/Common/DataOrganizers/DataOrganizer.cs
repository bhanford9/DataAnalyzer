using DataAnalyzer.StatConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal abstract class DataOrganizer<T> : IDataOrganizer
        where T : IDataConfiguration
    {
        public HeirarchalStats Organize(IDataConfiguration configuration, ICollection<IStats> data) =>
            this.InternalOrganize((T)configuration, data);

        protected abstract HeirarchalStats InternalOrganize(T configuration, ICollection<IStats> data);
    }
}
