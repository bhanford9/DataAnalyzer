using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.Utilities;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.UtilityConverters
{
    internal class RowSpecificationConverter
    {
        public static IRowSpecificationParameters ToLocalRowSpecification(IRowSpecification spec) =>
            new RowSpecificationParameters()
            {
                AllRows = spec.AllRows,
                NthRow = spec.NthRow,
                UseNthRow = spec.UseNthRow,
            };

        public static IRowSpecification ToExcelRowSpecification(IRowSpecificationParameters spec) =>
            new RowSpecification
            {
                AllRows = spec.AllRows,
                NthRow = spec.NthRow,
                UseNthRow = spec.UseNthRow,
            };
    }
}
