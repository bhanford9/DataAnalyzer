using DataAnalyzer.Services;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using DataSerialization.Utilities;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class EmptyParameters : ActionParameters
  {
    public override ActionCategory ActionCategory => ActionCategory.Unknown;

    public override void FromSerializable(ISerializable serializable)
    {
      this.Name = (serializable as EmptyParametersSerialization).Name;
    }

    public override bool IsValidSerializable(ISerializable serializable)
    {
      return serializable is EmptyParametersSerialization;
    }

    public override ISerializable ToSerializable()
    {
      return new EmptyParametersSerialization() { Name = this.Name };
    }
  }
}
