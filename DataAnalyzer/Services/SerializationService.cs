using DataSerialization;

namespace DataAnalyzer.Services
{
  public class SerializationService
  {
    private readonly SerializationExecutive serializer = new SerializationExecutive();

    public string JsonSerialize<T>(T data)
    {
      return this.serializer.JsonSerialize(data);
    }

    public T JsonDeserialize<T>(string json)
    {
      return this.serializer.JsonDeserialize<T>(json);
    }

    public void JsonSerializeToFile<T>(T data, string filePath)
    {
      this.serializer.JsonSerializeToFile(data, filePath);
    }

    public T JsonDeserializeFromFile<T>(string filePath)
    {
      return this.serializer.JsonDeserializeFromFile<T>(filePath);
    }
  }
}
