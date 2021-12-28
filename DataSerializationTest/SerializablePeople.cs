using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataSerializationTest
{
  public class SerializablePeople : SerializationCollection<Person>
  {
    public SerializablePeople() : base() { }

    public SerializablePeople(ICollection<Person> people, string parameterName)
      : base(people, parameterName) { }

    public override void RegisterTypes()
    {
      this.RegisterType(typeof(Adult), new SerializableAdult());
      this.RegisterType(typeof(Child), new SerializableChild());
    }
  }
}
