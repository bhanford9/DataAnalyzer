using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
    internal interface IWorksheetModel : INotifyPropertyChanged
    {
        ICollection<IDataClusterModel> DataClusters { get; set; }
        ICollection<IExcelAction> WorksheetActions { get; set; }
        string WorksheetName { get; set; }
    }
}