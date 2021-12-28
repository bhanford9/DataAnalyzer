using System;

namespace DataSerialization.CustomSerializations
{
  public interface ISerializationData
  {
    string SelfAssemblyName { get; set; }
    string ParameterName { get; set; }
    Type ValueType { get; }
    object Value { get; }

    void Initialize(string name, object value);
    void SetValueFromString(string valueAsString);
    string ToString();
  }
}