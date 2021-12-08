using System;

namespace DataSerialization.Utilities.BuiltInSerializers
{
  public class StringSerializer : BuiltInSerializer<string>
  {
    public override Func<string, string> Deserialize { get; set; }
      = (str) => str;
  }
}
