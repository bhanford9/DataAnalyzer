using System;

namespace DataSerialization.Utilities.BuiltInSerializers
{
  public abstract class BuiltInSerializer<T> : IParameterSerializer<T>
  {
    public Func<T, string> Serialize { get; set; }
      = (obj) => obj.ToString();

    public abstract Func<string, T> Deserialize { get; set; }
  }
}
