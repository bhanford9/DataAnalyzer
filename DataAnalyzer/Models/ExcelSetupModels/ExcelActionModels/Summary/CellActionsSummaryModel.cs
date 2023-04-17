using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal class CellActionsSummaryModel : ActionsSummaryModel, ICellActionsSummaryModel
    {
        public CellActionsSummaryModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
            : base(statsModel, excelSetupModel)
        {
        }

        public override ObservableCollection<IExcelAction> GetActionCollection() => throw new NotImplementedException();
        public override void LoadHierarchicalSummariesFromModel(IActionSummaryTreeViewItem baseItem) => throw new NotImplementedException();
        protected override void InternalLoadWhereToApply(IActionSummaryTreeViewItem baseItem, ICollection<HeirarchalStats> hierarchalStats) => throw new NotImplementedException();
    }
}
