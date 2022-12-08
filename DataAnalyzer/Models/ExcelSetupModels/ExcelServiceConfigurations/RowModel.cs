using DataAnalyzer.Common.Mvvm;
using System.Collections.Generic;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
    internal class RowModel : BasePropertyChanged
    {
        public ICollection<CellModel> Cells { get; set; } = new List<CellModel>();

        public ICollection<ExcelAction> RowActions { get; set; } = new List<ExcelAction>();
    }
}
