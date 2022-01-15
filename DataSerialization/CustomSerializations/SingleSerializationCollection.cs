using System;
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
      if (this.serialization == null)
      {
        this.RegisterType(typeof(TData), Activator.CreateInstance(typeof(TSerialization)) as ISerializationData);
      }
      else
      {
        this.RegisterType(typeof(TData), this.serialization);
      }
    }
  }
}
