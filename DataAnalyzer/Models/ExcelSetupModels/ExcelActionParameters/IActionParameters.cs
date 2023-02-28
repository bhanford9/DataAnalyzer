using DataAnalyzer.Services.Enums;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal interface IActionParameters : INotifyPropertyChanged
    {
        string Name { get; set; }

        ActionCategory ActionCategory { get; }

        ExcelEntityType ExcelEntityType { get; set; }

        string ToString();

        IActionParameters WithExcelEntity(ExcelEntityType excelEntityType);

        IActionParameters Clone();
    }
}