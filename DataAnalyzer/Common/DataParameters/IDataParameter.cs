namespace DataAnalyzer.Common.DataParameters
{
  public interface IDataParameter
  {
    bool CanGroupBy { get; set; }
    bool CanSortBy { get; set; }
    string Name { get; set; }
  }
}