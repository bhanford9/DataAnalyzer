namespace ExcelService.DataActions.ActionParameters.WorkbookParameters
{
    public class DisplayWorkbookParameters : ActionParameters, IDisplayWorkbookParameters
    {
        public bool DisplayAfter { get; set; } = true;

        public override string Name => "Open Active Workbook";

        public override ActionPerformer Performer { get; set; } = ActionPerformer.Workbook;

        public override ActionCategory Category => ActionCategory.BooleanOperation;
    }
}
