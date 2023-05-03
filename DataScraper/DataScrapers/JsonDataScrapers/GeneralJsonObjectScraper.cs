using DataScraper.Data;
using DataScraper.Data.ClassData;
using DataScraper.DataSources;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataScraper.DataScrapers.JsonDataScrapers
{
    public class GeneralJsonObjectScraper : IGeneralJsonObjectScraper
    {
        public string Name => "General JSON Object Scraper";

        // TODO --> move this method to base class for FileSourceScrapers
        public bool IsValidSource(IDataSource source)
            => source is FileDataSource s && File.Exists(s.FilePath);

        // TODO --> add protected method in FileSourceScraper for scraping and just do
        // the file source extraction in the public base
        public ICollection<IData> ScrapeFromSource(IDataSource source)
        {
            string filePath = (source as FileDataSource).FilePath;

            JObject jsonObject = JObject.Parse(File.ReadAllText(filePath));

            IClassData classData = new ClassData()
            {
                Name = jsonObject.Path,
                Properties = jsonObject.Properties().Select(x => this.ToProperty(x)).ToList(),
            };

            return new List<IData>() { classData };
        }

        private IProperty ToProperty(JToken token, string name = "") => token switch
        {
            JArray jarray => new CollectionProperty()
            {
                Name = name,
                // TODO --> we technically only need the names, so getting each one is not necessary
                Properties = jarray.Children().Select(x => ToProperty(x, name)).ToList()
            },
            JObject jobject => new ClassProperty()
            {
                Name = name,
                Properties = jobject.Properties().Select(x => ToProperty(x, x.Name)).ToList()
            },
            JProperty jprop when jprop.Children().Any() && jprop.First is not JValue 
                => ToProperty(jprop.First, jprop.Name),
            _ => new SimpleProperty() { Name = name },
        };
    }
}
