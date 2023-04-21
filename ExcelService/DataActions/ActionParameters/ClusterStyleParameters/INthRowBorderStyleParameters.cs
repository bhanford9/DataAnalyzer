using ExcelService.DataActions.ActionParameters.RangeStyleParameters;

namespace ExcelService.DataActions.ActionParameters.ClusterStyleParameters
{
    public interface INthRowBorderStyleParameters : IBorderStyleParameters
    {
        int NthRow { get; set; }
    }
}