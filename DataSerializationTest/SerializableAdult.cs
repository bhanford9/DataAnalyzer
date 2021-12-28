using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataSerializationTest
{
  public class SerializableAdult : SerializationAggregate<Adult>
  {
    public SerializableAdult() : base() { }

    public SerializableAdult(Adult adult, string parameterName)
      : base(adult, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.HeightInches = this.GetParameter<double>(nameof(this.DiscreteValue.HeightInches));
      this.DiscreteValue.OverTwentyOne = this.GetParameter<bool>(nameof(this.DiscreteValue.OverTwentyOne));
      this.DiscreteValue.Vehicle = this.GetParameter<string>(nameof(this.DiscreteValue.Vehicle));
    }

    protected override ICollection<ISerializationData> InitializeSelf(Adult value)
    {
      StringSerialization name = new StringSerialization();
      name.Initialize(nameof(value.Name), value.Name);

      DoubleSerialization height = new DoubleSerialization();
      height.Initialize(nameof(value.HeightInches), value.HeightInches);

      BooleanSerialization overTwentyOne = new BooleanSerialization();
      overTwentyOne.Initialize(nameof(value.OverTwentyOne), value.OverTwentyOne);

      StringSerialization vehicle = new StringSerialization();
      vehicle.Initialize(nameof(value.Vehicle), value.Vehicle);

      return new List<ISerializationData>() { name, height, overTwentyOne, vehicle };
    }
  }
}
