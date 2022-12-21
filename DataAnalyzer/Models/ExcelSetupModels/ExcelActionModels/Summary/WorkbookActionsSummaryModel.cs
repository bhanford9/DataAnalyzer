using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal class WorkbookActionsSummaryModel : ActionsSummaryModel
    {
        public override ObservableCollection<ExcelAction> GetActionCollection()
        {
            return this.excelSetupModel.AvailableWorkbookActions;
        }

        public override void LoadHierarchicalSummariesFromModel(ActionSummaryTreeViewItem baseItem)
        {
            foreach (ActionSummaryTreeViewItem workbookItem in baseItem.Children)
            {
                WorkbookModel workbook = this.excelSetupModel.ExcelConfiguration.WorkbookModels.FirstOrDefault(x => x.Name.Equals(workbookItem.Name));

                if (workbook != default && workbook.WorkbookActions.Count > 0)
                {
                    workbookItem.SummaryViewModels.Clear();

                    foreach (ExcelAction action in workbook.WorkbookActions)
                    {
                        workbookItem.SummaryViewModels.Add(new ActionSummaryExpandableViewModel
                        {
                            PathId = $"{workbookItem.Name}",
                            ActionName = $"{action.Name}",
                            ActionDescription = $"{action.Description}",
                            DescriptionPreview = $"{action.ActionParameters.Name}", // TBD
                            DetailedDescription = $"{action.ActionParameters}",
                        });
                    }

                    workbookItem.Description = workbook.WorkbookActions.Select(x => x.ActionParameters.ToString()).Aggregate((a, b) => a + Environment.NewLine + b);
                }
            }
        }

        protected override void InternalLoadWhereToApply(ActionSummaryTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
        {
            foreach (HeirarchalStats workbookStats in heirarchalStats)
            {
                baseItem.Children.Add(new ActionSummaryTreeViewItem
                {
                    IsLeaf = true,
                    Name = workbookStats.Key.ToString(),
                    Id = "Workbook"
                });
            }
        }
    }
}
