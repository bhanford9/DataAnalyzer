using ExcelService.DataActions.ActionParameters;

namespace ExcelService.DataActions
{
    public class ActionInfo : IActionInfo
    {
        public string Name { get; internal set; } = string.Empty;

        public string Description { get; internal set; } = string.Empty;

        public IActionParameters DefaultParameters { get; internal set; }
    }
}
