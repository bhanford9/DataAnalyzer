using DataSerialization.Utilities.BuiltInSerializers;
using System;

namespace DataSerialization.Utilities
{
  public class SerializerProxy<T> : ISerializerProxy
  {
    private readonly Func<ISerializable, T> valueGetter;
    private readonly Action<ISerializable, T> valueSetter;
    private readonly IParameterSerializer<T> parameterSerializer;

    public SerializerProxy(
      Func<ISerializable, T> getValue,
      Action<ISerializable, T> setValue,
      IParameterSerializer<T> serializer)
    {
      this.valueGetter = getValue;
      this.valueSetter = setValue;
      this.parameterSerializer = serializer;
    }

    public string Serialize(ISerializable serializable)
    {
      return this.parameterSerializer.Serialize(this.valueGetter(serializable));
    }

    public void Deserialize(ISerializable serializable, string content)
    {
      this.valueSetter(serializable, this.parameterSerializer.Deserialize(content));
    }
  }
}
