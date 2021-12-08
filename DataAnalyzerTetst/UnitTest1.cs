using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;
using Xunit;
using DataSerialization;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using ExcelService.CellDataFormats.NumericFormat;

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

      string result2 = serializationExecutive.JsonSerialize(testParameter);

      IntegerBooleanTypeParameter deserializedParameter = serializationExecutive.JsonDeserialize<IntegerBooleanTypeParameter>(result2);
    }
  }
}
