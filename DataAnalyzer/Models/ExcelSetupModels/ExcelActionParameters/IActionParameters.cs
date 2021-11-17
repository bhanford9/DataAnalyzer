using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public interface IActionParameters
  {
    string Name { get; set; }

    string SerializedParameters { get; }

    ActionCategory ActionCategory { get; }

    void Deserialize();
  }
}