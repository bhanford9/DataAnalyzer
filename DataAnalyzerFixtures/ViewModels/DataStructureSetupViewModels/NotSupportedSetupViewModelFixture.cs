using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using Moq;

namespace DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels
{
    public class NotSupportedSetupViewModelFixture : BaseFixture
    {
        public NotSupportedSetupViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IStatsModel> MockStatsModel { get; set; }

        internal Mock<IMainModel> MockMainModel { get; set; }

        internal Mock<INotSupportedSetupViewModel> MockDefaultSetupViewModel { get; set; }

        internal Mock<INotSupportedSetupModel> MockNotSupportedSetupModel { get; set; }

        internal NotSupportedSetupViewModel ViewModel { get; set; }
    }
}
