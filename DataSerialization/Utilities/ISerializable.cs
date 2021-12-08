namespace DataSerialization.Utilities
{
  public interface ISerializable
  {
    string FullyQualifiedClassName { get; set; }

    string Serialization { get; set; }

    string Serialize();

    void Deserialize();
    T As<T>();
  }
}
