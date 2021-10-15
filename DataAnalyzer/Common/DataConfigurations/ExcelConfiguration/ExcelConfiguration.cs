using DataAnalyzer.Common.DataConfigurations.GroupingConfigurations;
using DataAnalyzer.Common.DataObjects;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataConfigurations.ExcelConfiguration
{
  public class ExcelConfiguration : DataConfigurations
  {
    private int groupingLevels = 3;

    public ExcelConfiguration()
    {
    }

    // Workbook, Worksheet, Clusters
    public override int GroupingLevels
    { 
      get => groupingLevels;
      protected set => groupingLevels = value;
    }
  }
}
