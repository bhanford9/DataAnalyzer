using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class EmptyParameters : ActionParameters
  {
    public override ActionCategory ActionCategory => ActionCategory.Unknown;

    public override string SerializedParameters => string.Empty;

    public override void Deserialize()
    {
    }
  }
}
