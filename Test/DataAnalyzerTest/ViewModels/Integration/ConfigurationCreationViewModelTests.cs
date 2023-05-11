namespace DataAnalyzerTest.ViewModels.Integration;

internal class ConfigurationCreationViewModelTests
{
    // will want to do something like this to test all instances (present and future)
    //
    //[Theory]
    //[ClassData(typeof(ImportExecutionKeyProvider))]
    //public void ShouldSetActiveViewModelIfValidAtConstructionINTEGRATION(
    //    IImportType importType,
    //    IScraperCategory category,
    //    IScraperFlavor flavor,
    //    ExecutionType exportType)
    //{
    //    this.shared.MockConfigurationModel.Setup(x => x.ImportExecutionKey).Returns(new ImportExecutionKey(
    //        new ImportKey(importType, category, flavor),
    //        exportType));
    //}
}
