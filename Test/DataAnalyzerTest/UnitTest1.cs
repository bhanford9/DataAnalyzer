using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;
using Xunit;
using DataSerialization;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using ExcelService.CellDataFormats.NumericFormat;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzerTetst
{
    public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      //SerializationExecutive serializationExecutive = new SerializationExecutive();
      //IActionParameters testParams = new AlignmentParameters
      //{
      //  HorizontalAlignment = HorizontalAlignment.Distributed,
      //  VerticalAlignment = VerticalAlignment.Bottom
      //};

      //string result = serializationExecutive.JsonSerialize(testParams);

      //IActionParameters deserializedParameters = serializationExecutive.JsonDeserialize<AlignmentParameters>(result);

      //Type type = deserializedParameters.GetType();

      ////deserializedParameters.Deserialize();

      //IntegerBooleanTypeParameter testParameter = new IntegerBooleanTypeParameter(
      //  "Hello World",
      //  "Goodbye World",
      //  new FloatingSeparatorParensCellDataFormat(4, true),
      //  param => new FloatingSeparatorParensCellDataFormat((param as IntegerBooleanTypeParameter).IntegerValue, (param as IntegerBooleanTypeParameter).BooleanValue));

      //ExcelActionParametersSerialization actions = new ExcelActionParametersSerialization(
      //  new List<IActionParameters>()
      //  {
      //    new AlignmentParameters()
      //    {
      //      HorizontalAlignment = DataAnalyzer.Services.HorizontalAlignment.Right,
      //      VerticalAlignment = DataAnalyzer.Services.VerticalAlignment.Bottom,
      //      ExcelTypeName = "My First ALignment Serializaiton Project",
      //      NthRow = 2
      //    },
      //    new BackgroundParameters()
      //    {
      //      BackgroundColor = System.Drawing.Color.Magenta,
      //      FillPattern = DataAnalyzer.Services.FillPattern.DarkTrellis,
      //      PatternColor = System.Drawing.Color.Turquoise,
      //      ExcelTypeName = "MY FIrst Background Serialation Project",
      //      NthRow = 7
      //    }
      //  },
      //  "My Excel Actions");
      //string customResult = serializationExecutive.CustomSerialize(actions);
      //ExcelActionParametersSerialization actions2 = serializationExecutive.CustomDeserialize(customResult) as ExcelActionParametersSerialization;

      //ExcelDataTypesSerialization types = new ExcelDataTypesSerialization(
      //  new List<ITypeParameter>()
      //  {
      //    new IntegerTypeParameter() { DataName = "Hello" },
      //    new NoTypeParameter() { DataName  = "World" }
      //  },
      //  "My Excel Types");
      //string typeResult = serializationExecutive.CustomSerialize(types);
      //ExcelDataTypesSerialization types2 = serializationExecutive.CustomDeserialize(typeResult) as ExcelDataTypesSerialization;
    }
  }
}
