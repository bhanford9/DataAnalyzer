using DataAnalyzer.Common.DataOrganizers;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.StatConfigurations;
using DataAnalyzer.StatConfigurations.ExcelConfiguration;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.Services.ExecutiveUtilities.Executives
{
    internal class QueryableExcelCreation : AggregateExecutives
    {
        public override IDataConfiguration DataConfiguration { get; } = new ExcelConfiguration();

        public override IDataOrganizer DataOrganizer { get; } = new ExcelDataOrganizer();

        public override IDataStructureSetupViewModel DataStructureSetupViewModel { get; }
            = new GroupingSetupViewModel(new GroupingSetupModel());

        public override string ExecutionDisplayKey => nameof(ExecutionExecutiveCommissioner.DisplayExcelCreation);
    }
}
