using DataAnalyzer.Common.Mvvm;
using DataSerialization.Utilities;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class Deserializer
  {
    public Deserializer(ISerializablePropertyChanged serializablePropertyChanged)
    {
      this.SerializablePropertyChanged = serializablePropertyChanged;
    }

    public ISerializablePropertyChanged SerializablePropertyChanged { get; set; }

    public Action<string> DeserializePath { get; set; }
  }

  public class ExcelActionSerializationLibrary
  {
    private SerializationExecutive serializationExecutive = new SerializationExecutive();
    ICollection<Deserializer> deserializers = new List<Deserializer>();

    public ExcelActionSerializationLibrary()
    {
      this.LoadDeserializers();
    }

    public ISerializable Deserialize(string filePath)
    {
      // pass in the type and check it against Serializable Property CHanged?
      //this.deserializers.First(x => x.SerializablePropertyChanged.IsValidSerializable()
      return null;
    }

    private void LoadDeserializers()
    {
      //this.deserializers.Add(new Deserializer(new AlignmentParameters()));
      //this.deserializers.Last().DeserializePath = 
      //  (path) => this.serializationExecutive.JsonDeserializeFromFile<AlignmentParametersSerialization>(
      //    this.deserializers.Last().SerializablePropertyChanged,
      //    path);
    }
  }
}
