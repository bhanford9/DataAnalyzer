using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Actions
{
  public class ExcelActionParametersSerialization : SerializationCollection<IActionParameters>
  {
    public ExcelActionParametersSerialization() : base() { }

    public ExcelActionParametersSerialization(ICollection<IActionParameters> dataItems, string parameterName)
      : base(dataItems, parameterName)
    {
    }

    public override void RegisterTypes()
    {
      this.RegisterType(typeof(AlignmentParameters), new AlignmentParametersSerialization());
      this.RegisterType(typeof(BackgroundParameters), new BackgroundParametersSerialization());
      this.RegisterType(typeof(BooleanOperationParameters), new BooleanOperationParametersSerialization());
      this.RegisterType(typeof(BorderParameters), new BorderParametersSerialization());
      this.RegisterType(typeof(EmptyParameters), new EmptyParametersSerialization());
    }
  }
}
