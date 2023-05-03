using DataAnalyzer.StatConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal interface IDataOrganizer
    {
        public IHeirarchalStats Organize(IDataConfiguration configuration, ICollection<IStats> data);
    }
}
