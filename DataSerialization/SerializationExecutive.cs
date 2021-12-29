using DataSerialization.CustomSerializations;
using DataSerialization.Serializers;
using System.IO;

namespace DataSerialization
{
  public class SerializationExecutive
  {
    public string JsonSerialize<T>(T data)
    {
      return new JsonSerializer<T>().Serialize(data);
    }

    public T JsonDeserialize<T>(string json)
    {
      return new JsonSerializer<T>().Deserialize(json);
    }

    public void JsonSerializeToFile<T>(T data, string filePath)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(filePath));
      File.WriteAllText(filePath, this.JsonSerialize(data));
    }

    public T JsonDeserializeFromFile<T>(string filePath)
    {
      return this.JsonDeserialize<T>(File.ReadAllText(filePath));
    }

    public string CustomSerialize(ISerializationData data)
    {
      return new SerializationInstructions().Serialize(data);
    }

    public ISerializationData CustomDeserialize(string serializedData)
    {
      return new SerializationInstructions().Deserialize(serializedData);
    }

    public void CustomSerializeToFile(ISerializationData data, string filePath)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(filePath));
      File.WriteAllText(filePath, this.CustomSerialize(data));
    }

    public ISerializationData CustomDeserializeFromFile(string filePath)
    {
      return this.CustomDeserialize(File.ReadAllText(filePath));
    }
  }
}
