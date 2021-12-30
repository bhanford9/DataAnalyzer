using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;
using Xunit;
using DataSerialization;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using ExcelService.CellDataFormats.NumericFormat;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using System.Collections.Generic;
using DataAnalyzer.Services.Serializations.ExcelSerializations.DataTypes;

namespace DataAnalyzerTetst
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      SerializationExecutive serializationExecutive = new SerializationExecutive();
      IActionParameters testParams = new AlignmentParameters()
      {
        HorizontalAlignment = DataAnalyzer.Services.HorizontalAlignment.Distributed,
        VerticalAlignment = DataAnalyzer.Services.VerticalAlignment.Bottom
      };

      string result = serializationExecutive.JsonSerialize(testParams);

      IActionParameters deserializedParameters = serializationExecutive.JsonDeserialize<AlignmentParameters>(result);

      Type type = deserializedParameters.GetType();

      //deserializedParameters.Deserialize();

      IntegerBooleanTypeParameter testParameter = new IntegerBooleanTypeParameter(
        "Hello World",
        "Goodbye World",
        new FloatingSeparatorParensCellDataFormat(4, true),
        (param) => new FloatingSeparatorParensCellDataFormat((param as IntegerBooleanTypeParameter).IntegerValue, (param as IntegerBooleanTypeParameter).BooleanValue));

      ExcelActionParametersSerialization actions = new ExcelActionParametersSerialization(
        new List<IActionParameters>()
        {
          new AlignmentParameters()
          {
            HorizontalAlignment = DataAnalyzer.Services.HorizontalAlignment.Right,
            VerticalAlignment = DataAnalyzer.Services.VerticalAlignment.Bottom,
            Name = "My First ALignment Serializaiton Project",
            Nth = 2
          },
          new BackgroundParameters()
          {
            BackgroundColor = System.Drawing.Color.Magenta,
            FillPattern = DataAnalyzer.Services.FillPattern.DarkTrellis,
            PatternColor = System.Drawing.Color.Turquoise,
            Name = "MY FIrst Background Serialation Project",
            Nth = 7
          }
        },
        "My Excel Actions");
      string customResult = serializationExecutive.CustomSerialize(actions);
      ExcelActionParametersSerialization actions2 = serializationExecutive.CustomDeserialize(customResult) as ExcelActionParametersSerialization;

      ExcelDataTypesSerialization types = new ExcelDataTypesSerialization(
        new List<ITypeParameter>()
        {
          new IntegerTypeParameter() { DataName = "Hello" },
          new NoTypeParameter() { DataName  = "World" }
        },
        "My Excel Types");
      string typeResult = serializationExecutive.CustomSerialize(types);
      //ExcelDataTypesSerialization types2 = serializationExecutive.CustomDeserialize(typeResult) as ExcelDataTypesSerialization;
    }
  }
}
