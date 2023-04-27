using System;
using DataAnalyzer.Services.Enums;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Services
{
    internal class ImportExportKey : IImportExportKey
    {
        private ExportType exportType = ExportType.NotApplicable;
        private string name;

        private readonly int hashCode;

        public static ImportExportKey Default => new(ImportKey.Default, ExportType.NotApplicable);

        public ImportExportKey() { }

        public ImportExportKey(ImportKey importKey, ExportType exportType)
        {
            this.ImportKey = importKey;
            this.ExportType = exportType;
            this.SetName();

            this.hashCode = HashCode.Combine(this.ImportKey, this.ExportType);
        }

        public ImportKey ImportKey { get; init; } = ImportKey.Default;

        public ExportType ExportType { get => this.exportType; init => this.exportType = value; }

        public string Name { get => this.name; private set => this.name = value; }

        public bool IsValid =>
            ImportKey.Type is not NotApplicableImportType &&
            ImportKey.Category is not NotApplicableScraperCategory &&
            ImportKey.Flavor is not NotApplicableScraperFlavor &&
            this.ExportType != ExportType.NotApplicable;

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

        public void Update(ExportType export)
        {
            this.exportType = export;
            this.SetName();
        }

        private void SetName()
        {
            this.name = $"{ImportKey}_{ExportType}";
        }

        public override bool Equals(object obj) =>
            obj is ImportExportKey key &&
                ImportKey.Equals(key.ImportKey) &&
                ExportType.Equals(key.ExportType);

        public override int GetHashCode() => this.hashCode;

        public override string ToString() => this.Name;
    }
}
