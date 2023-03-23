using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;

namespace DataAnalyzer.Models.ExecutiveUtilities.Executives
{
    internal class NotSupportedExecutive : AggregateExecutives
    {
        public override IDataConfiguration DataConfiguration { get; } = new NotSupportedDataConfiguration();

        public override IDataOrganizer DataOrganizer { get; } = new NotSupportedDataOrganizer();
    }
}
