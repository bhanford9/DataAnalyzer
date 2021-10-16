namespace DataAnalyzer.Common.DataParameters
{
  public class DataParameter : IDataParameter
  {
    public string Name { get; set; } = string.Empty;

    public bool CanGroupBy { get; set; } = true;

    public bool CanSortBy { get; set; } = true;
  }
}
