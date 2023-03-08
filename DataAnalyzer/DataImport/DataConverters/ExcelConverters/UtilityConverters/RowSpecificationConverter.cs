using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.Utilities;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.UtilityConverters
{
    internal class RowSpecificationConverter
    {
        public static RowSpecificationParameters ToLocalRowSpecification(IRowSpecification spec) =>
            new()
            {
                AllRows = spec.AllRows,
                NthRow = spec.NthRow,
                UseNthRow = spec.UseNthRow,
            };

        public static IRowSpecification ToExcelRowSpecification(RowSpecificationParameters spec) =>
            new RowSpecification
            {
                AllRows = spec.AllRows,
                NthRow = spec.NthRow,
                UseNthRow = spec.UseNthRow,
            };
    }
}
