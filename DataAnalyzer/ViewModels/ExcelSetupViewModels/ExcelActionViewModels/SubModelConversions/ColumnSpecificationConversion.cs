using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.SubModelConversions
{
    internal static class ColumnSpecificationConversion
    {
        public static ColumnSpecificationParameters ToModel(ColumnSpecificationViewModel viewModel) =>
            new()
            {
                AllColumns = viewModel.AllColumns,
                ColumnName = viewModel.ColumnName,
                DataName = viewModel.DataName,
                NthColumn = viewModel.NthColumn,
                UseColumnName = viewModel.UseColumnName,
                UseDataName = viewModel.UseDataName,
                UseNthColumn = viewModel.UseNthColumn
            };

        public static ColumnSpecificationViewModel ToViewModel(ColumnSpecificationParameters model) =>
            new()
            {
                AllColumns = model.AllColumns,
                ColumnName = model.ColumnName,
                DataName = model.DataName,
                NthColumn = model.NthColumn,
                UseColumnName = model.UseColumnName,
                UseDataName = model.UseDataName,
                UseNthColumn = model.UseNthColumn
            };
    }
}
