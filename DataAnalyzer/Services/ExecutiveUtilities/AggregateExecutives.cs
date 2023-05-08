using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;

namespace DataAnalyzer.Services.ExecutiveUtilities
{
    internal abstract class AggregateExecutives : IAggregateExecutives
    {
        public AggregateExecutives(
            IStatsConfiguration dataConfiguration,
            IDataOrganizer dataOrganizer)
        {
            this.DataConfiguration = dataConfiguration;
            this.DataOrganizer = dataOrganizer;
        }

        public IStatsConfiguration DataConfiguration { get; }

        public IDataOrganizer DataOrganizer { get; }

        public abstract string ExecutionDisplayKey { get; }
    }
}
