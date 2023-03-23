using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;

namespace DataAnalyzer.Models.ExecutiveUtilities
{
    internal interface IAggregateExecutives
    {
        IDataConfiguration DataConfiguration { get; }
        IDataOrganizer DataOrganizer { get; }
    }
}
