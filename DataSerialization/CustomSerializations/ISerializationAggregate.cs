using System.Collections.Generic;

namespace DataSerialization.CustomSerializations
{
  public interface ISerializationAggregate : ISerializationData
  {
    ICollection<ISerializationData> Items { get; }

    void ApplyToValue();
    void SetParameter(ISerializationData data);
  }
}