using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;

internal class DataClusterModel : BasePropertyChanged, IDataClusterModel
{
    public ICollection<IRowModel> Rows { get; set; } = new List<IRowModel>();

    public IRowModel TitleRow { get; set; } = new RowModel();

    public ICollection<IExcelAction> DataClusterActions { get; set; } = new List<IExcelAction>();

    public string Name { get; set; } = string.Empty;

    public int StartRowIndex { get; set; }

    public int StartColIndex { get; set; }

    public bool UseClusterId { get; set; }
}
