using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;

internal class WorkbookActionApplicationModel : ActionApplicationModel, IWorkbookActionApplicationModel
{
    private const string PATH_DELIMITER = "~~";

    public const string ACTION_APPLIED_KEY = "Workbook Action Applied";

    public WorkbookActionApplicationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
        : base(statsModel, excelSetupModel)
    {
    }

    protected override void InternalApplyAction(ICheckableTreeViewItem item, IEditActionViewModel action)
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
            workbook.WorkbookActions.Add(new ExcelAction
            {
                ActionParameters = action.ActionParameters.Clone(),
                Description = action.Description,
                Name = action.ActionName
            });

            this.excelSetupModel.BroadcastExcelActionApplied(ACTION_APPLIED_KEY);
        }
        else
        {
            throw new Exception($"Failed to find workbook model with name: {item.Name}");
        }
    }

    protected override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableWorkbookActions;

    protected override void InternalLoadWhereToApply(ICheckableTreeViewItem baseItem, ICollection<IHeirarchalStats> heirarchalStats)
    {
        foreach (IHeirarchalStats workbookStats in heirarchalStats)
        {
            string path = workbookStats.Key.ToString();

            baseItem.Children.Add(new CheckableTreeViewItem
            {
                IsChecked = true,
                IsLeaf = true,
                Name = workbookStats.Key.ToString(),
                Path = path,
            });
        }
    }
}
