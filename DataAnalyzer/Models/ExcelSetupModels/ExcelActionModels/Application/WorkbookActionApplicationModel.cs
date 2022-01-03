using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
  public class WorkbookActionApplicationModel : ActionApplicationModel
  {
    private const string PATH_DELIMITER = "~~";

    public const string ACTION_APPLIED_KEY = "Workbook Action Applied";

    protected override void InternalApplyAction(CheckableTreeViewItem item, IEditActionViewModel action)
    {
      string[] pathSplit = item.Path.Split(PATH_DELIMITER);
      if (pathSplit.Length < 1 || pathSplit[0].Length == 0)
      {
        return;
      }

      string workbookName = pathSplit[0];
      WorkbookModel workbook = this.excelSetupModel.ExcelConfiguration.WorkbookModels.FirstOrDefault(x => x.Name.Equals(workbookName));

      if (workbook != default)
      {
        workbook.WorkbookActions.Add(new ExcelAction()
        {
          ActionParameters = action.ActionParameters,
          Description = action.Description,
          Name = action.ActionName
        });

        this.excelSetupModel.NotiyExcelActionApplied(ACTION_APPLIED_KEY);
      }
      else
      {
        throw new System.Exception($"Failed to find workbook model with name: {item.Name}");
      }
    }

    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.AvailableWorkbookActions;
    }

    protected override void InternalLoadWhereToApply(CheckableTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
    {
      foreach (HeirarchalStats workbookStats in heirarchalStats)
      {
        string path = workbookStats.Key.ToString();

        baseItem.Children.Add(new CheckableTreeViewItem()
        {
          IsChecked = true,
          IsLeaf = true,
          Name = workbookStats.Key.ToString(),
          Path = path,
        });
      }
    }
  }
}
