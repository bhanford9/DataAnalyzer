using DataSerialization.CustomSerializations;

namespace DataAnalyzer.Common.Mvvm
{
  public interface ISerializablePropertyChanged
  {
    void FromSerializable(ISerializationData serializable);
    bool IsValidSerializable(ISerializationData serializable);
    ISerializationData GetSerialization();
  }
}