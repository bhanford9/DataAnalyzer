using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzerTest.ViewModels.Builders;

internal class ImportExecutionKeyBuilder
{
    private readonly IImportExecutionKey importExecutionKey = ImportExecutionKey.Default;

    public ImportExecutionKeyBuilder With(
        IImportType importType = null,
        IScraperCategory category = null,
        IScraperFlavor flavor = null,
        ExecutionType execution = ExecutionType.NotApplicable) => this
            .WithImportType(importType)
            .WithCategory(category)
            .WithFlavor(flavor)
            .WithExecutionType(execution);

    public ImportExecutionKeyBuilder WithImportType(IImportType importType)
    {
        this.importExecutionKey.Update(importType ?? new NotApplicableImportType());
        return this;
    }

    public ImportExecutionKeyBuilder WithCategory(IScraperCategory category)
    {
        this.importExecutionKey.Update(category ?? new NotApplicableScraperCategory());
        return this;
    }

    public ImportExecutionKeyBuilder WithFlavor(IScraperFlavor flavor)
    {
        this.importExecutionKey.Update(flavor ?? new NotApplicableScraperFlavor());
        return this;
    }

    public ImportExecutionKeyBuilder WithExecutionType(ExecutionType? execution)
    {
        this.importExecutionKey.Update(execution ?? ExecutionType.NotApplicable);
        return this;
    }

    public IImportExecutionKey Build()
    {
        return this.importExecutionKey;
    }
}
