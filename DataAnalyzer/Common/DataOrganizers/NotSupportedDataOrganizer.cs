using DataAnalyzer.StatConfigurations;
using DataAnalyzer.DataImport.DataObjects;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers
{
    internal class NotSupportedDataOrganizer : DataOrganizer<NotSupportedDataConfiguration>, INotSupportedDataOrganizer
    {
        protected override HeirarchalStats InternalOrganize(NotSupportedDataConfiguration configuration, ICollection<IStats> data) => new();
    }
}
