using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;

namespace DataAnalyzer.Services.ExecutiveUtilities
{
    internal abstract class AggregateExecutives : IAggregateExecutives
    {
        public abstract IDataConfiguration DataConfiguration { get; }

        public abstract IDataOrganizer DataOrganizer { get; }

        public abstract IDataStructureSetupViewModel DataStructureSetupViewModel { get; }

        public abstract string ExecutionDisplayKey { get; }
    }
}
