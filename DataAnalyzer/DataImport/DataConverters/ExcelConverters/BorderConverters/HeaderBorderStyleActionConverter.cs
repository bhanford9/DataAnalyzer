using ExcelService.DataActions.ActionParameters.ClusterHeaderStyleParameters;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.BorderConverters
{
    internal class HeaderBorderStyleActionConverter : BorderStyleConverter
    {
        public HeaderBorderStyleActionConverter() : base(new HeaderBorderStyleParameters()) { }
    }
}
