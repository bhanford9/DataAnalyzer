using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSerialization.CustomSerializations
{
  public abstract class SerializationCollection<T> : SerializationData<List<T>>, ISerializationCollection
  {
    private readonly IDictionary<Type, ISerializationData> serializers = new Dictionary<Type, ISerializationData>();

    public SerializationCollection() : base()
    {
      this.RegisterTypes();
    }

    public SerializationCollection(ICollection<T> dataItems, string parameterName)
      : this()
    {
      this.Initialize(parameterName, dataItems);
    }

    public ICollection<ISerializationData> Items { get; set; } = new List<ISerializationData>();

    public ISerializationData GetSerializationData(Type modelType)
    {
      return this.serializers[modelType];
    }

    public abstract void RegisterTypes();

    public override void Initialize(string name, object value)
    {
      base.Initialize(name, value);
      this.InitializeItems(value as ICollection<T>);
    }

    public void InitializeItems(ICollection<T> dataItems)
    {
      this.Items.Clear();

      foreach (T item in dataItems)
      {
        this.AddItem(item);
      }
    }

    public void AddItem(T dataItem)
    {
      this.Items.Add(this.GetInitializedSerializationData(dataItem));
    }

    public void ApplyToValue()
    {
      this.DiscreteValue = this.Items.Select(x =>
      {
        if (x is ISerializationCollection serializationCollection)
        {
          serializationCollection.ApplyToValue();
        }
        else if (x is ISerializationAggregate serializationAggregate)
        {
          serializationAggregate.ApplyToValue();
        }

        return (T)x.Value;
      }).ToList();
    }

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

    protected void RegisterType(Type type, ISerializationData serializationData)
    {
      this.serializers.Add(type, serializationData);
    }

    private ISerializationData GetInitializedSerializationData(T value)
    {
      ISerializationData data = Activator.CreateInstance(this.serializers[value.GetType()].GetType()) as ISerializationData;
      data.Initialize(this.Items.Count().ToString(), value);
      return data;
    }
  }
}
