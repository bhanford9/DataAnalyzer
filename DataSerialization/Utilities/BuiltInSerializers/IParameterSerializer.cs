using System;

namespace DataSerialization.Utilities.BuiltInSerializers
{
  public interface IParameterSerializer<T>
  {
    Func<string, T> Deserialize { get; set; }
    Func<T, string> Serialize { get; set; }
  }
}