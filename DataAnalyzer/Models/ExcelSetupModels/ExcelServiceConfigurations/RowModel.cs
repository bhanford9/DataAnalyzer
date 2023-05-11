using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;

internal class RowModel : BasePropertyChanged, IRowModel
{
    public ICollection<ICellModel> Cells { get; set; } = new List<ICellModel>();

    public ICollection<IExcelAction> RowActions { get; set; } = new List<IExcelAction>();
}
