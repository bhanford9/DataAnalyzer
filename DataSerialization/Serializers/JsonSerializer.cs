using System.Text.Json;

namespace DataSerialization.Serializers
{
  internal class JsonSerializer<T> : Serializer<T>
  {
    private readonly JsonSerializerOptions options = new JsonSerializerOptions()
    {
      WriteIndented = true
    };

    public override T Deserialize(string content)
    {
      return JsonSerializer.Deserialize<T>(content, this.options);
    }

    public override string Serialize(T data)
    {
      return JsonSerializer.Serialize(data, data.GetType(), this.options);
    }
  }
}
