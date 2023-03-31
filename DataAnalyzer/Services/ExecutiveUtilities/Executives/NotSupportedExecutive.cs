using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class NotSupportedExecutive : AggregateExecutives
    {
        public override IDataConfiguration DataConfiguration { get; } = new NotSupportedDataConfiguration();

        public override IDataOrganizer DataOrganizer { get; } = new NotSupportedDataOrganizer();

        public override IDataStructureSetupViewModel DataStructureSetupViewModel { get; }
            = Resolver.Resolve<NotSupportedSetupViewModel>();//  new NotSupportedSetupViewModel(new NotSupportedSetupModel());

        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayNotSupported);
    }
}
