using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataSerializationTest
{
  public class SerializablePerson : SerializationAggregate<Person>
  {
    public SerializablePerson() : base() { }

    public SerializablePerson(Person person, string parameterName)
      : base(person, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.HeightInches = this.GetParameter<double>(nameof(this.DiscreteValue.HeightInches));
    }

    protected override ICollection<ISerializationData> InitializeSelf(Person value)
    {
      StringSerialization name = new StringSerialization();
      name.Initialize(nameof(value.Name), value.Name);

      DoubleSerialization height = new DoubleSerialization();
      height.Initialize(nameof(value.HeightInches), value.HeightInches);

      return new List<ISerializationData>() { name, height };
    }
  }
}
