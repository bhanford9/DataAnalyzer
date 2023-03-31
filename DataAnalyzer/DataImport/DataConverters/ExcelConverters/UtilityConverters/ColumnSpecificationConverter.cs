using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using ExcelService.Utilities;

namespace DataAnalyzer.DataImport.DataConverters.ExcelConverters.UtilityConverters
{
    internal class ColumnSpecificationConverter
    {
        public static IColumnSpecificationParameters ToLocalColumnSpecification(IColumnSpecification spec) =>
            new ColumnSpecificationParameters()
            {
                AllColumns = spec.AllColumns,
                ColumnName = spec.ColumnAddress,
                DataName = spec.ColumnHeader,
                NthColumn = spec.NthColumn,
                UseColumnName = spec.UseColumnAddress,
                UseDataName = spec.UseColumnHeader,
                UseNthColumn = spec.UseNthColumn,
            };

        public static IColumnSpecification ToExcelColumnSpecification(IColumnSpecificationParameters spec) =>
            new ColumnSpecification
            {
                AllColumns = spec.AllColumns,
                ColumnAddress = spec.ColumnName,
                UseColumnAddress = spec.UseColumnName,
                NthColumn = spec.NthColumn,
                UseNthColumn = spec.UseNthColumn,
                UseColumnHeader = spec.UseDataName,
                ColumnHeader = spec.DataName,
            };
    }
}
