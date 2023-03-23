using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.StatConfigurations.ExcelConfiguration;

namespace DataAnalyzer.Models.ExecutiveUtilities.Executives
{
    internal class QueryableExcelCreation : AggregateExecutives
    {
        public override IDataConfiguration DataConfiguration { get; } = new ExcelConfiguration();

        public override IDataOrganizer DataOrganizer { get; } = new ExcelDataOrganizer();
    }
}
