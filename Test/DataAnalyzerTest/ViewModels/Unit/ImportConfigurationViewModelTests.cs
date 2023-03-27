using DataAnalyzerTest.Fixtures.ViewModels;
using DataAnalyzerTest.Utilities;
using DataScraper.DataScrapers.ImportTypes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Unit
{
    public class ImportConfigurationViewModelTests : IClassFixture<ImportConfigurationViewModelFixture>
    {
        private readonly ImportConfigurationViewModelFixture shared;

        public ImportConfigurationViewModelTests(ImportConfigurationViewModelFixture shared)
        {
            this.shared = shared;
            this.shared.MockConfigurationModel = new();
            this.shared.MockExecutiveCommissioner = new();
            this.shared.MockDataConverters = new();
        }

        [Fact]
        public void ShouldInitializeImportTypesOnCreation()
        {
            this.shared.MockDataConverters
                .Setup(x => x.GetImportTypes())
                .Returns(new List<IImportType>
                {
                    Mock.Of<IImportType>(),
                    Mock.Of<IImportType>(),
                    Mock.Of<IImportType>(),
                });

            this.CreateViewModel();

            this.shared.MockDataConverters.Verify(x => x.GetImportTypes(), Times.Once());
            AssertionExtensions.CountIs(this.shared.ViewModel.ImportTypes, 3);
        }

        private void CreateViewModel() =>
            this.shared.ViewModel = new(
                this.shared.MockConfigurationModel.Object,
                this.shared.MockExecutiveCommissioner.Object,
                this.shared.MockDataConverters.Object);
    }
}
