using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application
{
    internal class DataClusterActionApplicationViewModel : ActionApplicationViewModel, IDataClusterActionApplicationViewModel
    {
        public DataClusterActionApplicationViewModel(
            IStatsModel statsModel,
            ICollection<IExcelAction> actions,
            IDataClusterActionApplicationModel actionApplicationModel,
            IEditActionLibrary editActionLibrary,
            IExcelDataClusterSpecification specification)
            : base(statsModel, editActionLibrary, actions, actionApplicationModel, specification)
        {
        }
    }
}
