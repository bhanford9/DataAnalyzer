using DataScraper.Data;
using DataScraper.DataScrapers.DataPropertySetters;
using DataScraper.DataSources;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataScraper.DataScrapers.CsvDataScrapers
{
    // TODO --> update wiki to address this acrhitecture
    public abstract class CsvNamedScraper<T> : IDataScraper where T : IData, new()
    {
        public abstract string Name { get; }

        public abstract Dictionary<string, IDataPropertySetter> DataSetters { get; }

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

            string[] names = lines.First().Split(',');

            // Skip the CSV Header
            foreach (string line in lines.Skip(1))
            {
                // Skip any blank lines
                if (string.IsNullOrEmpty(line)) continue;

                string[] values = line.Split(',');

                T item = new();

                // Leaving it up to the developer to fix the data if number of setters is not the same as the number of values/names
                for (int i = 0; i < values.Length; i++)
                {
                    this.DataSetters[names[i]].Set(item, values[i]);
                }

                items.Add(item);
            }

            return items;
        }
    }
}
