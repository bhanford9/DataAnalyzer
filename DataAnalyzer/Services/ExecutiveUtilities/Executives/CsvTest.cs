using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.StatConfigurations.CsvConfigurations;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class CsvTest : AggregateExecutives
    {
        public override IDataConfiguration DataConfiguration { get; } = new ClassPropertiesConfiguration();

        public override IDataOrganizer DataOrganizer { get; } = new CsvDataOrganizer();

        public override IDataStructureSetupViewModel DataStructureSetupViewModel { get; }
            = new CsvCSharpStringClassSetupViewModel(new CsvCSharpStringClassSetupModel());

        // TODO --> I don't love having just a string here. I think I prever having the view model here, but it may be overkill
        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayClassCreation);
    }
}
