using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;

internal interface IRowModel : INotifyPropertyChanged
{
    ICollection<ICellModel> Cells { get; set; }
    ICollection<IExcelAction> RowActions { get; set; }
}