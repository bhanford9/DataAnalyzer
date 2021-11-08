namespace DataAnalyzer.Common.DataConfigurations.ExcelConfiguration
{
  public class ExcelConfiguration : DataConfiguration
  {
    private int groupingLevels = 3;

    public ExcelConfiguration()
    {
    }

    // Workbook, Worksheet, Clusters
    public override int GroupingLevels
    {
      get => this.groupingLevels;
      protected set => this.groupingLevels = value;
    }
  }
}
