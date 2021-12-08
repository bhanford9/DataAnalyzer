using System;

namespace DataSerialization.Utilities.BuiltInSerializers
{
  public class DoubleSerializer : BuiltInSerializer<double>
  {
    public override Func<string, double> Deserialize { get; set; }
      = (str) => double.Parse(str);
  }
}
