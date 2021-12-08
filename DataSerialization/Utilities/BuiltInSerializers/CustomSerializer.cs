using System;

namespace DataSerialization.Utilities.BuiltInSerializers
{
  public class CustomSerializer<T> : IParameterSerializer<T>
  {
    public Func<string, T> Deserialize { get; set; }
    public Func<T, string> Serialize { get; set; }
  }
}
