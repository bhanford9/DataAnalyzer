using DataSerialization.Utilities;

namespace DataAnalyzer.Common.Mvvm
{
  public abstract class SerializablePropertyChanged : BasePropertyChanged, ISerializablePropertyChanged
  {
    public abstract ISerializable ToSerializable();

    public abstract bool IsValidSerializable(ISerializable serializable);

    public abstract void FromSerializable(ISerializable serializable);
  }
}
