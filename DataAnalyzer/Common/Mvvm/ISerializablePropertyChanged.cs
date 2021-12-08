using DataSerialization.Utilities;

namespace DataAnalyzer.Common.Mvvm
{
  public interface ISerializablePropertyChanged
  {
    void FromSerializable(ISerializable serializable);
    bool IsValidSerializable(ISerializable serializable);
    ISerializable ToSerializable();
  }
}