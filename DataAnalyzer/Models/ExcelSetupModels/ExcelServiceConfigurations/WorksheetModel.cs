using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;

internal class WorksheetModel : BasePropertyChanged, IWorksheetModel
{
    public string WorksheetName { get; set; } = string.Empty;

    public ICollection<IExcelAction> WorksheetActions { get; set; } = new List<IExcelAction>();

    public ICollection<IDataClusterModel> DataClusters { get; set; } = new List<IDataClusterModel>();
}
