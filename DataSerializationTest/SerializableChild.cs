using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataSerializationTest
{
  public class SerializableChild : SerializationAggregate<Child>
  {
    public SerializableChild() : base() { }

    public SerializableChild(Child child, string parameterName)
      : base(child, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.HeightInches = this.GetParameter<double>(nameof(this.DiscreteValue.HeightInches));
      this.DiscreteValue.School = this.GetParameter<string>(nameof(this.DiscreteValue.School));
    }

    protected override ICollection<ISerializationData> InitializeSelf(Child value)
    {
      StringSerialization name = new StringSerialization();
      name.Initialize(nameof(value.Name), value.Name);

      DoubleSerialization height = new DoubleSerialization();
      height.Initialize(nameof(value.HeightInches), value.HeightInches);

      StringSerialization school = new StringSerialization();
      school.Initialize(nameof(value.School), value.School);

      return new List<ISerializationData>() { name, height, school };
    }
  }
}
