using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSerialization.CustomSerializations
{
  public abstract class SerializationAggregate<T> : SerializationData<T>, ISerializationAggregate
  {
    private Dictionary<string, ISerializationData> items = new Dictionary<string, ISerializationData>();

    public SerializationAggregate() : base() { }

    public SerializationAggregate(T value, string parameterName)
      : base(value, parameterName)
    {
    }

    public ICollection<ISerializationData> Items => this.items.Values;

    public override void SetValueFromString(string valueAsString)
    {
      // n/a
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      // n/a
      throw new NotImplementedException();
    }

    public void SetParameter(ISerializationData data)
    {
      this.items[data.ParameterName] = data;
    }

    public abstract void ApplyToValue();

    public override void Initialize(string name, object value)
    {
      base.Initialize(name, value);
      this.InitializeItems(this.InitializeSelf((T)value));
    }

    protected abstract ICollection<ISerializationData> InitializeSelf(T value);

    protected TParam GetParameter<TParam>(string parameterName)
    {
      return (TParam)this.items[parameterName].Value;
    }

    protected void RegisterParameter(ISerializationData serializationData)
    {
      this.items.Add(serializationData.ParameterName, serializationData);
    }

    private void InitializeItems(ICollection<ISerializationData> items)
    {
      items.ToList().ForEach(item => this.RegisterParameter(item));
    }
  }
}
