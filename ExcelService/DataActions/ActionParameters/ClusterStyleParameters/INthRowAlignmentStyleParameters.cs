using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.ActionParameters.ClusterStyleParameters
{
    public interface INthRowAlignmentStyleParameters : IAlignmentStyleParameters
    {
        int NthRow { get; set; }
    }
}