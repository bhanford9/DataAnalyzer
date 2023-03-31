using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.ViewModels.Utilities;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.SubModelConversions
{
    internal static class RowSpecificationConversion
    {
        public static IRowSpecificationParameters ToModel(IRowSpecificationViewModel viewModel) =>
            new RowSpecificationParameters()
            {
                AllRows = viewModel.AllRows,
                NthRow = viewModel.NthRow,
                UseNthRow = viewModel.UseNthRow
            };

        public static IRowSpecificationViewModel ToViewModel(IRowSpecificationParameters model) =>
            new RowSpecificationViewModel()
            {
                AllRows = model.AllRows,
                NthRow = model.NthRow,
                UseNthRow = model.UseNthRow
            };
    }
}
