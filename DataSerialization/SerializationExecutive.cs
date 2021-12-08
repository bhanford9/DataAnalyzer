using DataSerialization.Serializers;
using DataSerialization.Utilities;
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

    public string CustomSerialize(ISerializable data)
    {
      return new CustomSerializer().Serialize(data);
    }

    public ISerializable CustomDeserialize(string serializedData)
    {
      return new CustomSerializer().Deserialize(serializedData);
    }

    public void CustomSerializeToFile(ISerializable data, string filePath)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(filePath));
      File.WriteAllText(filePath, this.CustomSerialize(data));
    }

    public ISerializable CustomSerializeFromFile(string filePath)
    {
      return this.CustomDeserialize(File.ReadAllText(filePath));
    }
  }
}
