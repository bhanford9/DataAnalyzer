using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.SubModelConversions
{
    internal static class RowSpecificationConversion
    {
        public static RowSpecificationParameters ToModel(RowSpecificationViewModel viewModel) =>
            new()
            {
                AllRows = viewModel.AllRows,
                NthRow = viewModel.NthRow,
                UseNthRow = viewModel.UseNthRow
            };

        public static RowSpecificationViewModel ToViewModel(RowSpecificationParameters model) =>
            new()
            {
                AllRows = model.AllRows,
                NthRow = model.NthRow,
                UseNthRow = model.UseNthRow
            };
    }
}
