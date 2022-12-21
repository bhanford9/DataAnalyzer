using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation
{
    internal class RowActionCreationModel : ActionCreationModel
    {
        protected override ObservableCollection<ExcelAction> GetActionCollection()
        {
            return this.excelSetupModel.AvailableRowActions;
        }
    }
}
