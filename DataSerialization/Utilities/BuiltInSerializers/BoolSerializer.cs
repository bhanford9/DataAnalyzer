using System;

namespace DataSerialization.Utilities.BuiltInSerializers
{
  public class BoolSerializer : BuiltInSerializer<bool>
  {
    public override Func<string, bool> Deserialize { get; set; }
      = (str) => bool.Parse(str);
  }
}
