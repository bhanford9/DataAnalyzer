using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
    internal class CellActionApplicationModel : ActionApplicationModel, ICellActionApplicationModel
    {
        public CellActionApplicationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
            : base(statsModel, excelSetupModel)
        {
        }

        protected override ObservableCollection<IExcelAction> GetActionCollection() => throw new NotImplementedException();
        protected override void InternalApplyAction(ICheckableTreeViewItem item, IEditActionViewModel action) => throw new NotImplementedException();
        protected override void InternalLoadWhereToApply(ICheckableTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats) => throw new NotImplementedException();
    }
}
