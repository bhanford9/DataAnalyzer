namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal interface IBooleanOperationParameters : IActionParameters
    {
        bool DoPerform { get; set; }
    }
}