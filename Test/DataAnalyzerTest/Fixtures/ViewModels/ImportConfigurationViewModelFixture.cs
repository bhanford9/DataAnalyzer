using DataAnalyzer.DataImport.DataConverters;
using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using Moq;

namespace DataAnalyzerTest.Fixtures.ViewModels
{
    public class ImportConfigurationViewModelFixture : BaseFixture
    {
        public ImportConfigurationViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IConfigurationModel> MockConfigurationModel { get; set; }

        internal Mock<IImportExecutiveCommissioner> MockExecutiveCommissioner { get; set; }

        internal Mock<IDataConverterLibrary> MockDataConverters { get; set; }

        internal ImportConfigurationViewModel ViewModel { get; set; }
    }
}
