using System;
using DataScraper;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Services
{
    internal static class ImportKeyExtensions
    {
        public static T GetData<T>(this IFlavoredCategorizedDataLibrary<T> library, ImportKey key)
        {
            return library[key.Type][key.Category][key.Flavor];
        }
    }

    internal class ImportKey : IImportKey
    {
        private IImportType type;
        private IScraperCategory category;
        private IScraperFlavor flavor;
        private string name;

        private readonly int hashCode;

        public static ImportKey Default => new(
            new NotApplicableImportType(),
            new NotApplicableScraperCategory(),
            new NotApplicableScraperFlavor());

        public ImportKey() { }

        public ImportKey(IImportType type, IScraperCategory category, IScraperFlavor flavor)
        {
            this.Type = type;
            this.Category = category;
            this.Flavor = flavor;
            this.SetName();
            this.hashCode = HashCode.Combine(this.Type, this.Category, this.Flavor);
        }

        public IImportType Type { get => this.type; init => this.type = value; }

        public IScraperCategory Category { get => this.category; init => this.category = value; }

        public IScraperFlavor Flavor { get => this.flavor; init => this.flavor = value; }

        public string Name { get => this.name; init => this.name = value; }

        public void Update(IImportType type)
        {
            this.type = type;
            this.SetName();
        }

        public void Update(IScraperCategory category)
        {
            this.category = category;
            this.SetName();
        }

        public void Update(IScraperFlavor flavor)
        {
            this.flavor = flavor;
            this.SetName();
        }

        public (IImportType Import, IScraperCategory Category, IScraperFlavor Flavor) AsTuple() =>
            (this.Type, this.Category, this.Flavor);

        private void SetName()
        {
            this.name = $"{this.Type}_{this.Category}_{this.Flavor}";
        }

        public override bool Equals(object obj) => obj is ImportKey key && key.Name.Equals(this.Name);

        public override int GetHashCode() => this.hashCode;

        public override string ToString() => this.name;
    }
}
