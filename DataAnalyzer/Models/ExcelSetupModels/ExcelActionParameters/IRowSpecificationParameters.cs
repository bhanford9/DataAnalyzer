using System.ComponentModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

internal interface IRowSpecificationParameters : INotifyPropertyChanged
{
    bool AllRows { get; set; }
    int NthRow { get; set; }
    bool UseNthRow { get; set; }

    IRowSpecificationParameters Clone();
    string ToString();
}