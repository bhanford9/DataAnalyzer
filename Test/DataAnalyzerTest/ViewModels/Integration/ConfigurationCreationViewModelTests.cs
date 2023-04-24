namespace DataAnalyzerTest.ViewModels.Integration
{
    internal class ConfigurationCreationViewModelTests
    {
        // will want to do something like this to test all instances (present and future)
        //
        //[Theory]
        //[ClassData(typeof(ImportExportKeyProvider))]
        //public void ShouldSetActiveViewModelIfValidAtConstructionINTEGRATION(
        //    IImportType importType,
        //    IScraperCategory category,
        //    IScraperFlavor flavor,
        //    ExportType exportType)
        //{
        //    this.shared.MockConfigurationModel.Setup(x => x.ImportExportKey).Returns(new ImportExportKey(
        //        new ImportKey(importType, category, flavor),
        //        exportType));
        //}
    }
}
