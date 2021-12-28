using DataSerialization.CustomSerializations;
using DataSerialization.Utilities;

namespace DataAnalyzer.Common.Mvvm
{
  public abstract class SerializablePropertyChanged : BasePropertyChanged, ISerializablePropertyChanged
  {
    public abstract ISerializationData ToSerializable();

    public abstract bool IsValidSerializable(ISerializationData serializable);

    public abstract void FromSerializable(ISerializationData serializable);
  }
}
