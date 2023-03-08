using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataScraper
{
    public static class ScraperExtensions
    {
        public static IDictionary<IScraperFlavor, T> ThenAdd<T>(
            this IDictionary<IScraperFlavor, T> source,
            IScraperFlavor flavor,
            T data)
        {
            source.Add(flavor, data);
            return source;
        }
    }

    public abstract class FlavoredCategorizedDataLibrary<T>
        : Dictionary<IImportType, IDictionary<IScraperCategory, IDictionary<IScraperFlavor, T>>>
    {
        public abstract string Name { get; }

        public T this[IImportType type, IScraperCategory category, IScraperFlavor flavor] => this[type][category][flavor];

        public T GetData(IImportType type, IScraperCategory category, IScraperFlavor flavor)
        {
            try
            {
                return this[type, category, flavor];
            }
            catch
            {
                throw new ArgumentOutOfRangeException(
                    $"Failed to retrieve {Name} with provided parameters. Make sure {Name} Library contains specified arguments." +
                    $"{Environment.NewLine}\tType: {type}" +
                    $"{Environment.NewLine}\tCategory: {category}" +
                    $"{Environment.NewLine}\tFlavor: {flavor}");
            }
        }

        public bool TryGetData(
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor,
            out T data)
        {
            try
            {
                data = this.GetData(type, category, flavor);
                return true;
            }
            catch(ArgumentOutOfRangeException)
            {
                data = default;
                return false;
            }
        }

        public IReadOnlyCollection<IImportType> GetImportTypes() => this.Keys;

        public IReadOnlyCollection<string> GetImportTypeNames() => this.Keys.Select(x => x.Name).ToList();

        public IReadOnlyCollection<IScraperCategory> GetCategories(IImportType type) => this[type].Keys.ToList();

        public IReadOnlyCollection<string> GetCategoryNames(IImportType type) => GetCategories(type).Select(x => x.Name).ToList();

        public IReadOnlyCollection<IScraperFlavor> GetFlavors(IImportType type, IScraperCategory category)
            => this[type][category].Keys.ToList();

        public IReadOnlyCollection<string> GetFlavorNames(IImportType type, IScraperCategory category)
            => this.GetFlavors(type, category).Select(x => x.Name).ToList();

        protected IDictionary<IScraperFlavor, T> InitializeCategory(IImportType type, IScraperCategory category)
        {
            this[type][category] = new Dictionary<IScraperFlavor, T>();
            return this[type][category];
        }
    }
}
