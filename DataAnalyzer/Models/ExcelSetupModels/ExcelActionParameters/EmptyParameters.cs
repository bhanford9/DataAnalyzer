using DataAnalyzer.Services;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using DataSerialization.CustomSerializations;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class EmptyParameters : ActionParameters
  {
    public override ActionCategory ActionCategory => ActionCategory.Unknown;

    public override void FromSerializable(ISerializationData serializable)
    {
      this.Name = (serializable as EmptyParametersSerialization).DiscreteValue.Name;
    }

    public override bool IsValidSerializable(ISerializationData serializable)
    {
      return serializable is EmptyParametersSerialization;
    }

    public override ISerializationData GetSerialization()
    {
      return new EmptyParametersSerialization();
    }
  }
}
