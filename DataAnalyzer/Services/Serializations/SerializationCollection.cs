using DataSerialization.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataAnalyzer.Services.Serializations
{
  public class SerializationCollection
  {
    private const string DELIMITER_BASE = "`~`";

    private string Delimiter => $"{this.DelimiterSalt}{DELIMITER_BASE}{this.DelimiterSalt}";

    public SerializationCollection(string delimiterSalt = "")
    {
      this.DelimiterSalt = delimiterSalt;
    }

    public string DelimiterSalt { get; set; } = string.Empty;

    public ICollection<ISerializable> Serializations { get; set; } = new List<ISerializable>();

    public string Serialize(string filePath = null)
    {
      string serializedCollection = string.Empty;

      foreach (ISerializable serializable in this.Serializations)
      {
        serializable.FullyQualifiedClassName = serializable.GetType().AssemblyQualifiedName;
        serializedCollection += serializable.Serialize() + this.Delimiter;
      }

      if (!string.IsNullOrEmpty(filePath))
      {
        File.WriteAllText(filePath, serializedCollection);
      }

      return serializedCollection;
    }

    public SerializationCollection Deserialize(string content)
    {
      string[] splitSerializations = content.Split(this.Delimiter, StringSplitOptions.RemoveEmptyEntries);

      foreach (string serialization in splitSerializations)
      {
        using StringReader reader = new StringReader(serialization);
        string classInfo = reader.ReadLine();
        string fullyQualifiedClassName = classInfo.Trim();
        string serializedContent = serialization[classInfo.Length..];

        object obj = Activator.CreateInstance(Type.GetType(fullyQualifiedClassName));
        ISerializable result = obj as ISerializable;
        result.FullyQualifiedClassName = fullyQualifiedClassName;
        result.Serialization = serializedContent.Trim();
        result.Deserialize();

        this.Serializations.Add(result);
      }

      return this;
    }

    public void DeserializeFromFile(string filePath)
    {
      if (File.Exists(filePath))
      {
        this.Deserialize(File.ReadAllText(filePath));
      }
    }
  }
}
