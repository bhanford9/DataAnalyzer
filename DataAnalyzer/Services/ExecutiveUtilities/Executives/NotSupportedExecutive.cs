using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class NotSupportedExecutive : AggregateExecutives
    {
        public override IDataConfiguration DataConfiguration { get; } = new NotSupportedDataConfiguration();

        public override IDataOrganizer DataOrganizer { get; } = new NotSupportedDataOrganizer();

        public override IDataStructureSetupViewModel DataStructureSetupViewModel { get; } 
            = new NotSupportedSetupViewModel(new NotSupportedSetupModel());

        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayNotSupported);
    }
}
