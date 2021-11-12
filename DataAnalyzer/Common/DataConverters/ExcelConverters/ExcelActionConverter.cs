using DataAnalyzer.Models.ExcelSetupModels;
using ExcelService.DataActions;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
  public class ExcelActionConverter
  {
    public static ExcelAction FromExcelActionInfo(ActionInfo actionInfo)
    {
      return new ExcelAction()
      {
        Description = actionInfo.Description,
        IsBuiltIn = true,
        Name = actionInfo.Name
      };
    }
  }
}
