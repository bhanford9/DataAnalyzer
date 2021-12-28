using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;
using Xunit;
using DataSerialization;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using ExcelService.CellDataFormats.NumericFormat;
using DataAnalyzer.Services.Serializations.ExcelSerializations;
using DataAnalyzer.Services.Serializations;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;

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



      AlignmentParametersSerialization alignmentParametersSerialization = new AlignmentParametersSerialization()
      {
        HorizontalAlignment = DataAnalyzer.Services.HorizontalAlignment.Justify,
        VerticalAlignment = DataAnalyzer.Services.VerticalAlignment.Bottom,
        Name = "My Alignment",
      };

      BackgroundParametersSerialization backgroundParametersSerialization = new BackgroundParametersSerialization()
      {
        BackgroundColor = System.Drawing.Color.Green,
        FillPattern = DataAnalyzer.Services.FillPattern.DarkTrellis,
        Name = "My Background",
        PatternColor = System.Drawing.Color.Magenta
      };


      WorkbookSerialization workbookSerialization = new WorkbookSerialization();
      workbookSerialization.Name = "Hello World";
      workbookSerialization.WorkbookActions = new SerializationCollection();
      workbookSerialization.WorkbookActions.Serializations.Add(alignmentParametersSerialization);
      workbookSerialization.WorkbookActions.Serializations.Add(backgroundParametersSerialization);
      string serializedWorkbook = workbookSerialization.Serialize();

      WorkbookSerialization deserialziedWorkbook = new WorkbookSerialization();
      deserialziedWorkbook.Serialization = serializedWorkbook;
      deserialziedWorkbook.Deserialize();
    }
  }
}
