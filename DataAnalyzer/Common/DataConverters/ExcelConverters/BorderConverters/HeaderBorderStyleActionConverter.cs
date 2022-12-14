using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters.BorderConverters
{
    internal class HeaderBorderStyleActionConverter : BorderStyleConverter
    {
        public HeaderBorderStyleActionConverter() : base(new HeaderBorderStyleParameters()) { }
    }
}
