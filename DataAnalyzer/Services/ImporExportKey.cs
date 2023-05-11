using System;
using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Services;

internal class ImportExecutionKey : IImportExecutionKey
{
    private ExecutionType executionType = ExecutionType.NotApplicable;
    private string name;

    private readonly int hashCode;

    public static ImportExecutionKey Default => new(ImportKey.Default, ExecutionType.NotApplicable);

    public ImportExecutionKey() { }

    public ImportExecutionKey(ImportKey importKey, ExecutionType executionType)
    {
        this.ImportKey = importKey;
        this.ExecutionType = executionType;
        this.SetName();

        this.hashCode = HashCode.Combine(this.ImportKey, this.ExecutionType);
    }

    public ImportKey ImportKey { get; init; } = ImportKey.Default;

    public ExecutionType ExecutionType { get => this.executionType; init => this.executionType = value; }

    public string Name { get => this.name; private set => this.name = value; }

    public bool IsValid =>
        ImportKey.Type is not NotApplicableImportType &&
        ImportKey.Category is not NotApplicableScraperCategory &&
        ImportKey.Flavor is not NotApplicableScraperFlavor &&
        this.ExecutionType != ExecutionType.NotApplicable;

    public void Update(IImportType type)
    {
        this.ImportKey.Update(type);
        this.SetName();
    }

    public void Update(IScraperCategory category)
    {
        this.ImportKey.Update(category);
        this.SetName();
    }

    public void Update(IScraperFlavor flavor)
    {
        this.ImportKey.Update(flavor);
        this.SetName();
    }

    public void Update(ExecutionType execution)
    {
        this.executionType = execution;
        this.SetName();
    }

    private void SetName()
    {
        this.name = $"{ImportKey}_{ExecutionType}";
    }

    public override bool Equals(object obj) =>
        obj is ImportExecutionKey key &&
            ImportKey.Equals(key.ImportKey) &&
            ExecutionType.Equals(key.ExecutionType);

    public override int GetHashCode() => this.hashCode;

    public override string ToString() => this.Name;
}
