using DataSerialization;

namespace DataAnalyzer.Services;

internal class SerializationService : ISerializationService
{
    private readonly ISerializationExecutive serializer;

    public SerializationService(ISerializationExecutive serializer)
    {
        this.serializer = serializer;
    }

    public string JsonSerialize<T>(T data) => this.serializer.JsonSerialize(data);

    public T JsonDeserialize<T>(string json) => this.serializer.JsonDeserialize<T>(json);

    public void JsonSerializeToFile<T>(T data, string filePath) => this.serializer.JsonSerializeToFile(data, filePath);

    public T JsonDeserializeFromFile<T>(string filePath) => this.serializer.JsonDeserializeFromFile<T>(filePath);
}
