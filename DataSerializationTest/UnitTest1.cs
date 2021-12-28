using DataSerialization.CustomSerializations;
using System.Collections.Generic;
using Xunit;

namespace DataSerializationTest
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      SerializationInstructions serializationInstructions = new SerializationInstructions();

      Person person1 = new Person()
      {
        Name = "Jerry",
        HeightInches = 82.43
      };

      Person person2 = new Person()
      {
        Name = "Ben",
        HeightInches = 75.71
      };

      SerializablePersonPair serializablePersonPair = new SerializablePersonPair(new PersonPair(person1, person2), "My Person Pair");

      string serializedPersonPair = serializationInstructions.Serialize(serializablePersonPair);

      SerializablePersonPair serializablePersonPair1 = serializationInstructions.Deserialize(serializedPersonPair) as SerializablePersonPair;

      Adult adult = new Adult()
      {
        Name = "Adult Person",
        HeightInches = 81.4,
        OverTwentyOne = true,
        Vehicle = "Motorcycle"
      };

      Child child = new Child()
      {
        Name = "Child Person",
        HeightInches = 52.3,
        School = "My School Elementary"
      };

      SerializablePeople serializablePeople = new SerializablePeople(new List<Person>() { adult, child }, "My People");
      serializablePeople.AddItem(new Adult() { HeightInches = 79.9, Name = "Added Adult", OverTwentyOne = true, Vehicle = "Truck" });

      string serializedPeople = serializationInstructions.Serialize(serializablePeople);
      SerializablePeople serializablePeople1 = serializationInstructions.Deserialize(serializedPeople) as SerializablePeople;
    }
  }
}
