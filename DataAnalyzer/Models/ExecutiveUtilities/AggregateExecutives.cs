using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;

namespace DataAnalyzer.Models.ExecutiveUtilities
{
    internal abstract class AggregateExecutives : IAggregateExecutives
    {
        public abstract IDataConfiguration DataConfiguration { get; }

        public abstract IDataOrganizer DataOrganizer { get; }
    }
}
