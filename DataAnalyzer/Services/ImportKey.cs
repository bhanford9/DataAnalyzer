using System;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;

namespace DataAnalyzer.Services
{
    internal class ImportKey
    {
        private int hashCode;

        public ImportKey(IImportType type, IScraperCategory category, IScraperFlavor flavor)
        {
            this.Type = type;
            this.Category = category;
            this.Flavor = flavor;
            this.Name = $"{this.Type} - {this.Category} - {this.Flavor}";
            this.hashCode = HashCode.Combine(this.Type, this.Category, this.Flavor);
        }

        public IImportType Type { get; }

        public IScraperCategory Category { get; }

        public IScraperFlavor Flavor { get; }

        public string Name { get; }

        public override bool Equals(object obj) => obj is ImportKey key && key.Name.Equals(this.Name);

        public override int GetHashCode() => this.hashCode;

        public override string ToString() => this.Name;
    }
}
