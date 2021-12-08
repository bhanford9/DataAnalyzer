namespace DataSerialization.Utilities
{
  public interface ISerializerProxy
  {
    void Deserialize(ISerializable serializable, string content);
    string Serialize(ISerializable serializable);
  }
}