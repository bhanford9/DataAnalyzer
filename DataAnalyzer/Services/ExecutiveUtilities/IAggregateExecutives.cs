using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;

namespace DataAnalyzer.Services.ExecutiveUtilities
{
    internal interface IAggregateExecutives
    {
        IDataConfiguration DataConfiguration { get; }
        IDataOrganizer DataOrganizer { get; }
        IDataStructureSetupViewModel DataStructureSetupViewModel { get; }
        string ExecutionDisplayKey { get; }
    }
}
