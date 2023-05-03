using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels
{
    public class GroupingSetupViewModelFixture : BaseFixture
    {
        public GroupingSetupViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IStatsModel> MockStatsModel { get; set; }

        internal Mock<IMainModel> MockMainModel { get; set; }

        internal Mock<INotSupportedSetupViewModel> MockDefaultSetupViewModel { get; set; }

        internal Mock<IGroupingSetupModel> MockGroupingSetupModel { get; set; }

        internal Mock<ICsvNamesDataConfiguration> MockDataConfiguration { get; set; }

        internal string RemoveLevelPropName => nameof(this.MockGroupingSetupModel.Object.RemoveLevel);

        internal PropertyChangedEventArgs RemoveLevelChangeArgs => this.GetNamedEventArgs(this.RemoveLevelPropName);

        internal GroupingSetupViewModel ViewModel { get; set; }
    }
}
