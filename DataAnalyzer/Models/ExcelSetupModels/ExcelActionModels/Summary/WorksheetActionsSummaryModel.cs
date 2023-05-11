using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;

internal class WorksheetActionsSummaryModel : ActionsSummaryModel, IWorksheetActionsSummaryModel
{
    private const string PATH_DELIMITER = "~~";

    public WorksheetActionsSummaryModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
        : base(statsModel, excelSetupModel)
    {
    }

    public override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableWorksheetActions;

    public override void LoadHierarchicalSummariesFromModel(IActionSummaryTreeViewItem baseItem)
    {
        foreach (IActionSummaryTreeViewItem workbookItem in baseItem.Children)
        {
            IWorkbookModel workbook = this.excelSetupModel.ExcelConfiguration.WorkbookModels.FirstOrDefault(x => x.Name.Equals(workbookItem.Name));

            if (workbook != default)
            {
                foreach (IActionSummaryTreeViewItem worksheetItem in workbookItem.Children)
                {
                    IWorksheetModel worksheet = workbook.Worksheets.FirstOrDefault(x => x.WorksheetName.Equals(worksheetItem.Name));

                    if (worksheet != default && worksheet.WorksheetActions.Count > 0)
                    {
                        worksheetItem.SummaryViewModels.Clear();

                        foreach (IExcelAction action in worksheet.WorksheetActions)
                        {
                            worksheetItem.SummaryViewModels.Add(new ActionSummaryExpandableViewModel
                            {
                                PathId = $"{workbookItem.Name}.{worksheetItem.Name}",
                                ActionName = $"{action.Name}",
                                ActionDescription = $"{action.Description}",
                                DescriptionPreview = $"{action.ActionParameters.Name}", // TBD
                                DetailedDescription = $"{action.ActionParameters}",
                            });
                        }

                        worksheetItem.Description = worksheet.WorksheetActions
                            .Select(x => x.ActionParameters.ToString())
                            .Aggregate((a, b) => a + Environment.NewLine + b);
                    }
                }
            }
        }
    }

    protected override void InternalLoadWhereToApply(IActionSummaryTreeViewItem baseItem, ICollection<IHeirarchalStats> heirarchalStats)
    {
        foreach (IHeirarchalStats workbookStats in heirarchalStats)
        {
            string path = workbookStats.Key.ToString();

            baseItem.Children.Add(new ActionSummaryTreeViewItem
            {
                IsLeaf = false,
                Name = workbookStats.Key.ToString(),
                Id = "Workbook"
            });

            foreach (IHeirarchalStats worksheetStats in workbookStats.Children)
            {
                path += PATH_DELIMITER + worksheetStats.Key.ToString();

                baseItem.Children.Last().Children.Add(new ActionSummaryTreeViewItem
                {
                    IsLeaf = true,
                    Name = worksheetStats.Key.ToString(),
                    Id = "Worksheet"
                });
            }
        }
    }
}
