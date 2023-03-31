using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.StatConfigurations.CsvConfigurations;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class CsvCSharpClassCreation : AggregateExecutives
    {
        public override IDataConfiguration DataConfiguration { get; } = new ClassPropertiesConfiguration();

        public override IDataOrganizer DataOrganizer { get; } = new CsvDataOrganizer();

        public override IDataStructureSetupViewModel DataStructureSetupViewModel { get; }
            = Resolver.Resolve<CsvCSharpStringClassSetupViewModel>();// new CsvCSharpStringClassSetupViewModel(new CsvCSharpStringClassSetupModel());

        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayClassCreation);
    }
}
