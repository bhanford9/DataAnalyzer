namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation
{
    internal abstract class ActionCreationModel : ExcelActionModel, IActionCreationModel
    {
        protected ActionCreationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
            : base(statsModel, excelSetupModel)
        {
        }
    }
}
