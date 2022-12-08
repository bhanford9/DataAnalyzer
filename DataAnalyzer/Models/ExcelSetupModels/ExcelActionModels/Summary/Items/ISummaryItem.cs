using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items
{
    internal interface ISummaryItem
    {
        string Description { get; set; }
        string Name { get; set; }
        int Level { get; set; }

        bool IsApplicable(IActionParameters actionParameters);
        void SetDescription(IActionParameters actionParameters);
    }
}