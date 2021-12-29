using DataSerialization.CustomSerializations;

namespace DataAnalyzer.Common.Mvvm
{
  public abstract class SerializablePropertyChanged : BasePropertyChanged, ISerializablePropertyChanged
  {
    public abstract ISerializationData GetSerialization();

    public abstract bool IsValidSerializable(ISerializationData serializable);

    public abstract void FromSerializable(ISerializationData serializable);
  }
}
