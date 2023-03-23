using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.StatConfigurations.CsvConfigurations;

namespace DataAnalyzer.Models.ExecutiveUtilities.Executives
{
    internal class CsvCSharpClassCreation : AggregateExecutives
    {
        public override IDataConfiguration DataConfiguration { get; } = new ClassPropertiesConfiguration();

        public override IDataOrganizer DataOrganizer { get; } = new CsvDataOrganizer();
    }
}
