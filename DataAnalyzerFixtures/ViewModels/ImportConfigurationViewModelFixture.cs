using DataAnalyzer.DataImport.DataConverters;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using Moq;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels;

public class ImportConfigurationViewModelFixture : BaseFixture
{
    public ImportConfigurationViewModelFixture()
    {
        // one time setup
    }

    internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

    internal Mock<IImportExecutiveCommissioner> MockExecutiveCommissioner { get; set; }

    internal Mock<IDataConverterLibrary> MockDataConverters { get; set; }

    internal string ImportPropName => nameof(this.MockConfigurationModel.Object.ImportType);

    internal string CategoryPropName => nameof(this.MockConfigurationModel.Object.Category);

    internal string FlavorPropName => nameof(this.MockConfigurationModel.Object.Flavor);

    internal PropertyChangedEventArgs ImportChangeArgs => this.GetNamedEventArgs(this.ImportPropName);

    internal PropertyChangedEventArgs CategoryChangeArgs => this.GetNamedEventArgs(this.CategoryPropName);

    internal PropertyChangedEventArgs FlavorChangeArgs => this.GetNamedEventArgs(this.FlavorPropName);

    internal ImportConfigurationViewModel ViewModel { get; set; }
}
