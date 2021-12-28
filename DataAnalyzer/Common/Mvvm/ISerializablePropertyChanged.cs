using DataSerialization.CustomSerializations;
using DataSerialization.Utilities;

namespace DataAnalyzer.Common.Mvvm
{
  public interface ISerializablePropertyChanged
  {
    void FromSerializable(ISerializationData serializable);
    bool IsValidSerializable(ISerializationData serializable);
    ISerializationData ToSerializable();
  }
}