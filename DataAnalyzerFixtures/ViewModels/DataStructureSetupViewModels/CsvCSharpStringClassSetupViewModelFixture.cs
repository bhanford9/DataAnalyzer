using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels;

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

    internal Mock<IClassCreationSetupModel> MockCsvCSharpStringClassSetupModel { get; set; }

    internal Mock<ICsvNamesDataConfiguration> MockDataConfiguration { get; set; }

    internal string DataParamListPropName => nameof(this.MockStatsModel.Object.DataAccessorCollection);
    
    internal string DataConfigPropName => nameof(this.MockCsvCSharpStringClassSetupModel.Object.DataConfiguration);

    internal string ImportExecutionKeyPropName => nameof(this.MockConfigurationModel.Object.ImportExecutionKey);

    internal string ExecutionTypePropName => nameof(this.MockConfigurationModel.Object.SelectedExecutionType);

    internal PropertyChangedEventArgs DataParamListChangeArgs => this.GetNamedEventArgs(this.DataParamListPropName);

    internal PropertyChangedEventArgs DataConfigChangeArgs => this.GetNamedEventArgs(this.DataConfigPropName);

    internal PropertyChangedEventArgs ImportExecutionKeyChangeArgs => this.GetNamedEventArgs(this.ImportExecutionKeyPropName);

    internal PropertyChangedEventArgs ExecutionTypeChangeArgs => this.GetNamedEventArgs(this.ExecutionTypePropName);

    internal ClassCreationSetupViewModel ViewModel { get; set; }
}
