using DataSerialization.Utilities.BuiltInSerializers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSerialization.Utilities
{
  public abstract class DefaultSerializable //: ISerializable
  {
    private string DELIMITER => $"_{this.DelimiterKey}_";
    protected IDictionary<int, ISerializerProxy> parameterSerializers = new Dictionary<int, ISerializerProxy>();

    public DefaultSerializable()
    {
      this.RegisterSerializations();
      DelimiterDictionary.Instance.RegisterDelimiter(this.GetType().AssemblyQualifiedName, this.DelimiterKey);
    }

    public abstract string DelimiterKey { get; }
    public string FullyQualifiedClassName { get; set; } = string.Empty;
    public string Serialization { get; set; } = string.Empty;

    public T As<T>()
    {
      // Currently assumes that Deserialize has already been called and therefore can simply cast out
      // Might want to throw exception if Deserialize has not been called
      return this.IsCorrectType(typeof(T))
          ? (T)(object)this
          : throw new Exception($"Invalid Type. {this.GetType()} cannot be converted to {typeof(T)}");
    }

    public void Deserialize()
    {
      //string[] stringParams = this.Serialization.Split(this.DELIMITER);

      //for (int i = 0; i < stringParams.Length; i++)
      //{
      //  this.parameterSerializers[i].Deserialize(this, stringParams[i]);
      //}
    }

    public string Serialize()
    {
      //this.Serialization = this.parameterSerializers
      //  .Select((keyValuePair) => keyValuePair.Value.Serialize(this))
      //  .Aggregate((a, b) => a + this.DELIMITER + b);

      return this.FullyQualifiedClassName + Environment.NewLine + this.Serialization;
    }

    protected abstract bool IsCorrectType(Type type);

    protected abstract void RegisterSerializations();

    protected void RegisterSerializableParameter<T>(
      int index,
      Func<ISerializable, T> getValue,
      Action<ISerializable, T> setValue,
      Func<string, T> deserialize,
      Func<T, string> serialize = null)
    {
      if (serialize == null)
      {
        serialize = (obj) => obj.ToString();
      }

      this.parameterSerializers.Add(
        index,
        new SerializerProxy<T>(
          getValue,
          setValue,
          new CustomSerializer<T>() { Deserialize = deserialize, Serialize = serialize }));
    }

    protected void RegisterSerializableParameter<T>(
      int index,
      Func<ISerializable, T> getValue,
      Action<ISerializable, T> setValue,
      IParameterSerializer<T> serializer)
    {
      this.parameterSerializers.Add(
        index,
        new SerializerProxy<T>(
          getValue,
          setValue,
          serializer));
    }
  }
}
