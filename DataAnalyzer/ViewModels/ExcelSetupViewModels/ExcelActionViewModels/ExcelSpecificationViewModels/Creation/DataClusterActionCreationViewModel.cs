using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;

internal class DataClusterActionCreationViewModel : ActionCreationViewModel, IDataClusterActionCreationViewModel
{
    public DataClusterActionCreationViewModel(
        ICollection<IExcelAction> actions,
        IDataClusterActionCreationModel actionCreationModel,
        IExcelDataClusterSpecification excelEntityType,
        IEditActionLibrary editActionLibrary)
        : base(actions, actionCreationModel, excelEntityType, editActionLibrary)
    {
    }
}
