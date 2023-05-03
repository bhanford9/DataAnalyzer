using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels
{
    public class ConfigurationGroupingViewModelFixture : BaseFixture
    {
        public ConfigurationGroupingViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IStatsModel> MockStatsModel { get; set; }

        internal Mock<IStructureExecutiveCommissioner> MockExecutiveCommissioner { get; set; }

        internal Mock<IGroupingSetupViewModel> MockGroupingSetupViewModel { get; set; }

        internal string DataParamListPropName => nameof(this.MockStatsModel.Object.DataAccessorCollection);

        internal PropertyChangedEventArgs DataParamListChangeArgs => this.GetNamedEventArgs(this.DataParamListPropName);

        internal ConfigurationGroupingViewModel ViewModel { get; set; }
    }
}
