using System.Collections.Generic;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;

internal interface IWorkbookModel : INotifyPropertyChanged
{
    string FilePath { get; set; }
    string Name { get; set; }
    ICollection<IExcelAction> WorkbookActions { get; set; }
    ICollection<IWorksheetModel> Worksheets { get; set; }
}