using DataSerialization;

namespace DataAnalyzer.Services
{
    internal class SerializationService : ISerializationService
    {
        private readonly SerializationExecutive serializer = new();

        public string JsonSerialize<T>(T data) => this.serializer.JsonSerialize(data);

        public T JsonDeserialize<T>(string json) => this.serializer.JsonDeserialize<T>(json);

        public void JsonSerializeToFile<T>(T data, string filePath) => this.serializer.JsonSerializeToFile(data, filePath);

        public T JsonDeserializeFromFile<T>(string filePath) => this.serializer.JsonDeserializeFromFile<T>(filePath);
    }
}
