using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;

namespace DataAnalyzer.Services.ExecutiveUtilities
{
    internal interface IAggregateExecutives
    {
        IDataConfiguration DataConfiguration { get; }
        IDataOrganizer DataOrganizer { get; }
        string ExecutionDisplayKey { get; }
    }
}
