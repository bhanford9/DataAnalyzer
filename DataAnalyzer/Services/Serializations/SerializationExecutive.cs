using DataAnalyzer.Common.Mvvm;
using DataSerialization.Utilities;
using System;

namespace DataAnalyzer.Services.Serializations
{
  public class SerializationExecutive
  {
    private readonly SerializationService serializationService = new SerializationService();

    public void JsonSerializeToFile(ISerializablePropertyChanged model, ISerializable serializable, string filePath)
    {
      if (model.IsValidSerializable(serializable))
      {
        this.serializationService.JsonSerializeToFile(model.ToSerializable(), filePath);
      }

      // TODO -->provide better information specific to the two types
      throw new Exception("Invalid serializable type attempting to be used");
    }

    public void JsonDeserializeFromFile<T>(ISerializablePropertyChanged model, string filePath)
      where T : ISerializable
    {
      T result = this.serializationService.JsonDeserializeFromFile<T>(filePath);

      if (model.IsValidSerializable(result))
      {
        model.FromSerializable(result);
      }

      // TODO -->provide better information specific to the two types
      throw new Exception("Invalid serializable type attempting to be used");
    }
  }
}
