using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class EmptyParameters : ActionParameters
  {
    public override ActionCategory ActionCategory => ActionCategory.Unknown;

    public override string ToString()
    {
      return Environment.NewLine;
    }
  }
}
