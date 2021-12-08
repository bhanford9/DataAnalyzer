using DataSerialization;
using DataSerialization.Utilities;
using Xunit;

namespace DataSerializationTest
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      SerializableData serializableData = new SerializableData()
      {
        Age = 27,
        FullyQualifiedClassName = typeof(SerializableData).AssemblyQualifiedName,
        HeightInches = 74.2,
        Name = "Some Guy",
      };


      SerializationExecutive serializationExecutive = new SerializationExecutive();
      string serializedData = serializationExecutive.CustomSerialize(serializableData);

      ISerializable serializable = serializationExecutive.CustomDeserialize(serializedData);
    }
  }
}
