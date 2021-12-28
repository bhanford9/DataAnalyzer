using System.Collections.Generic;

namespace DataSerialization.CustomSerializations
{
  public interface ISerializationCollection : ISerializationData
  {
    ICollection<ISerializationData> Items { get; set; }

    void ApplyToValue();
  }
}