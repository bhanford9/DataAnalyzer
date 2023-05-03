using Newtonsoft.Json.Linq;

namespace DataScraper.Data.JsonData
{
    internal interface IJsonObjectData : IData
    {
        JObject JsonObject { get; set; }
    }
}