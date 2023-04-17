using DataAnalyzer.Services.Enums;
using DataAnalyzer.Services.ExcelUtilities;
using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal interface IActionParameters : INotifyPropertyChanged
    {
        string Name { get; set; }

        ActionCategory ActionCategory { get; }

        IExcelEntitySpecification ExcelEntityType { get; set; }

        string ToString();

        IActionParameters WithExcelEntity(IExcelEntitySpecification excelEntityType);

        IActionParameters Clone();
    }
}