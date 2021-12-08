using System;

namespace DataSerialization.Utilities.BuiltInSerializers
{
  public class IntegerSerializer : BuiltInSerializer<int>
  {
    public override Func<string, int> Deserialize { get; set; }
      = (str) => int.Parse(str);
  }
}
