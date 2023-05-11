using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;

namespace DataAnalyzer.Services.ExecutiveUtilities;

internal interface IAggregateExecutives
{
    IStatsConfiguration DataConfiguration { get; }
    IDataOrganizer DataOrganizer { get; }
    string ExecutionDisplayKey { get; }
}
