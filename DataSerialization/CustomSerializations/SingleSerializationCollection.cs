using System.Collections.Generic;

namespace DataSerialization.CustomSerializations
{
  public class SingleSerializationCollection<TData, TSerialization> : SerializationCollection<TData>
    where TSerialization : ISerializationData
  {
    private readonly TSerialization serialization;

    public SingleSerializationCollection() : base() { }

    public SingleSerializationCollection(ICollection<TData> dataItems, string parameterName)
      : base(dataItems, parameterName)
    {
    }

    public SingleSerializationCollection(TSerialization serialization)
      : this()
    {
      this.serialization = serialization;
    }

    public override void RegisterTypes()
    {
      this.RegisterType(typeof(TData), this.serialization);
    }
  }
}
