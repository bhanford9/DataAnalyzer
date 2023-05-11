using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;

internal interface IDataClusterModel : INotifyPropertyChanged
{
    ICollection<IExcelAction> DataClusterActions { get; set; }
    string Name { get; set; }
    ICollection<IRowModel> Rows { get; set; }
    int StartColIndex { get; set; }
    int StartRowIndex { get; set; }
    IRowModel TitleRow { get; set; }
    bool UseClusterId { get; set; }
}