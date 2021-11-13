namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public interface IActionParameters
  {
    string Name { get; set; }

    string SerializedParameters { get; }

    void Deserialize();
  }
}