using DataScraper.Data;
using DataScraper.DataScrapers.DataPropertySetters;
using DataScraper.DataSources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataScraper.DataScrapers.CsvDataScrapers
{
    public abstract class CsvIndexedScraper<T> : ICsvIndexedScraper where T : IData
    {
        private Func<T> getNewInstance;
        public CsvIndexedScraper(Func<T> getNewInstance) => this.getNewInstance = getNewInstance;

        public abstract string Name { get; }

        public abstract List<IDataPropertySetter> DataSetters { get; }

        public bool IsValidSource(IDataSource source)
        {
            return source is FileDataSource s && File.Exists(s.FilePath);
        }

        public ICollection<IData> ScrapeFromSource(IDataSource source)
        {
            string filePath = (source as FileDataSource).FilePath;

            List<IData> items = new();

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length <= 1)
            {
                return items;
            }

            // Skip the CSV Header
            foreach (string line in lines.Skip(1))
            {
                // Skip any blank lines
                if (string.IsNullOrEmpty(line)) continue;

                string[] values = line.Split(',');

                T item = this.getNewInstance();

                // Leaving it up to the developer to fix the data if number of setters is not the same as the number of values
                for (int i = 0; i < values.Length; i++)
                {
                    this.DataSetters[i].Set(item, values[i]);
                }

                items.Add(item);
            }

            return items;
        }
    }
}
