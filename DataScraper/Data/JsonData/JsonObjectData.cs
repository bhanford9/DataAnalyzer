using Newtonsoft.Json.Linq;

namespace DataScraper.Data.JsonData
{
    internal class JsonObjectData : IJsonObjectData
    {
        public JObject JsonObject { get; set; }
    }
}
