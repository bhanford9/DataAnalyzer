using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzerTest.ViewModels.Builders
{
    internal class ImportExportKeyBuilder
    {
        private readonly IImportExportKey importExportKey = ImportExportKey.Default;

        public ImportExportKeyBuilder With(
            IImportType importType = null,
            IScraperCategory category = null,
            IScraperFlavor flavor = null,
            ExportType export = ExportType.NotApplicable) => this
                .WithImportType(importType)
                .WithCategory(category)
                .WithFlavor(flavor)
                .WithExportType(export);

        public ImportExportKeyBuilder WithImportType(IImportType importType)
        {
            this.importExportKey.Update(importType ?? new NotApplicableImportType());
            return this;
        }

        public ImportExportKeyBuilder WithCategory(IScraperCategory category)
        {
            this.importExportKey.Update(category ?? new NotApplicableScraperCategory());
            return this;
        }

        public ImportExportKeyBuilder WithFlavor(IScraperFlavor flavor)
        {
            this.importExportKey.Update(flavor ?? new NotApplicableScraperFlavor());
            return this;
        }

        public ImportExportKeyBuilder WithExportType(ExportType? export)
        {
            this.importExportKey.Update(export ?? ExportType.NotApplicable);
            return this;
        }

        public IImportExportKey Build()
        {
            return this.importExportKey;
        }
    }
}
