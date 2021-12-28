using System;

namespace DataSerialization.CustomSerializations
{
  public abstract class SerializationData<T> : ISerializationData
  {
    public SerializationData()
    {
      this.SelfAssemblyName = this.GetType().AssemblyQualifiedName;
    }

    public SerializationData(T data, string parameterName) : this()
    {
      this.Initialize(parameterName, data);
    }

    public string SelfAssemblyName { get; set; }

    public string ParameterName { get; set; }

    public T DiscreteValue { get; set; }

    public object Value => this.DiscreteValue;

    public Type ValueType => typeof(T);

    public virtual void Initialize(string name, object value)
    {
      this.ParameterName = name;
      this.DiscreteValue = (T)value;
    }

    public abstract override string ToString();

    public abstract void SetValueFromString(string valueAsString);
  }
}
