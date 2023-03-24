using DataAnalyzer.Services;
using DataScraper;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System.Collections.Generic;
using System.IO;

namespace DataAnalyzer.Models.ImportModels
{
    internal class FileMap : FlavoredCategorizedDataLibrary<string>
    {
        public override string Name => "Previous Directories Map";

        public string MapFile(ImportKey key, string rootPath, string fileName = "")
            => MapFile(key.Type, key.Category, key.Flavor, rootPath, fileName);

        public string MapFile(
            IImportType import,
            IScraperCategory category,
            IScraperFlavor flavor,
            string rootPath,
            string fileName = "")
        {
            string fullPath = Path.Combine(rootPath, fileName);
            
            if (!this.ContainsKey(import))
            {
                this[import] = new Dictionary<IScraperCategory, IDictionary<IScraperFlavor, string>>();
            }

            if (!this[import].ContainsKey(category))
            {
                this[import][category] = new Dictionary<IScraperFlavor, string>();
            }

            this[import][category][flavor] = fullPath;
            
            return fullPath;
        }
    }
}
