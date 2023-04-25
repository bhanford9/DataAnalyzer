using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels
{
    public class CsvCSharpStringClassSetupViewModelFixture : BaseFixture
    {
        public CsvCSharpStringClassSetupViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IMainModel> MockMainModel { get; set; }

        internal Mock<IStatsModel> MockStatsModel { get; set; }

        internal Mock<INotSupportedSetupViewModel> MockDefaultSetupViewModel { get; set; }

        internal Mock<ICsvCSharpStringClassSetupModel> MockCsvCSharpStringClassSetupModel { get; set; }

        internal Mock<ICsvNamesDataConfiguration> MockDataConfiguration { get; set; }

        internal string DataParamListPropName => nameof(this.MockConfigurationModel.Object.DataParameterCollection);

        internal PropertyChangedEventArgs DataParamListChangeArgs => this.GetNamedEventArgs(this.DataParamListPropName);

        internal CsvCSharpStringClassSetupViewModel ViewModel { get; set; }
    }
}
