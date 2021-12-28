using DataSerialization.Utilities;
using System;
using System.IO;

namespace DataSerialization.Serializers
{
  internal class CustomSerializer : Serializer<ISerializable>
  {
    public override ISerializable Deserialize(string content)
    {
      using StringReader reader = new StringReader(content);
      string classInfo = reader.ReadLine();
      string fullyQualifiedClassName = classInfo.Trim();
      string serialization = content[classInfo.Length..];

      object obj = Activator.CreateInstance(Type.GetType(fullyQualifiedClassName));
      ISerializable result = obj as ISerializable;
      result.FullyQualifiedClassName = fullyQualifiedClassName;
      result.Serialization = serialization.Trim();
      result.Deserialize();

      return result;
    }

    public override string Serialize(ISerializable data)
    {
      return data.Serialize();
    }
  }
}
