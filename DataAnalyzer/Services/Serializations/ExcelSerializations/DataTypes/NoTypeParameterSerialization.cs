﻿namespace DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes
{
  public class NoTypeParameterSerialization : TypeParameterSerialization
  {
    public override object[] GetParameterNameValuePairs()
    {
      return new object[] { };
    }

    protected override void InternalRegisterSerializations()
    {
    }
  }
}
