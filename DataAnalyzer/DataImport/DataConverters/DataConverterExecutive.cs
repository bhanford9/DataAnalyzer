using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.DataImport.DataObjects;
using DataScraper.Data;
using DataScraper.DataScrapers.ImportTypes;
using DataScraper.DataScrapers.ScraperCategories;
using DataScraper.DataScrapers.ScraperFlavors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.DataImport.DataConverters
{
    internal class DataConverterExecutive : IDataConverterExecutive
    {
        private readonly IDataConverterLibrary converters;

        public DataConverterExecutive(IDataConverterLibrary converters)
        {
            this.converters = converters;
        }

        public ICollection<IStats> Convert(
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor,
            ICollection<IData> data)
        {
            IDataConverter converter = this.converters.GetData(type, category, flavor);

            return data
                .Where(x => converter.IsValidData(x))
                .Select(x => converter.ToAnalyzerStats(x))
                .ToList();
        }

        public IStats Convert(
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor,
            IData data)
        {
            IDataConverter converter = this.converters.GetData(type, category, flavor);

            if (converter.IsValidData(data))
            {
                return converter.ToAnalyzerStats(data);
            }

            throw new ArgumentException("Invalid data supplied");
        }

        public bool TryConvert(
            IImportType type,
            IScraperCategory category,
            IScraperFlavor flavor,
            IData data,
            out IStats stats)
        {
            if (this.converters.TryGetData(type, category, flavor, out IDataConverter converter))
            {
                if (converter.IsValidData(data))
                {
                    stats = converter.ToAnalyzerStats(data);
                    return true;
                }
            }

            stats = default;
            return false;
        }
    }
}
