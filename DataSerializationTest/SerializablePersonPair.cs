using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataSerializationTest
{
  public class SerializablePersonPair : SerializationAggregate<PersonPair>
  {
    public SerializablePersonPair() : base() { }

    public SerializablePersonPair(PersonPair personPair, string parameterName)
      : base(personPair, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Person1 = this.GetParameter<Person>(nameof(this.DiscreteValue.Person1));
      this.DiscreteValue.Person2 = this.GetParameter<Person>(nameof(this.DiscreteValue.Person2));
    }

    protected override ICollection<ISerializationData> InitializeSelf(PersonPair value)
    {
      SerializablePerson person1 = new SerializablePerson(value.Person1, nameof(value.Person1));
      SerializablePerson person2 = new SerializablePerson(value.Person2, nameof(value.Person2));
      return new List<ISerializationData>() { person1, person2 };
    }
  }
}
