using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.DataStructureSetupViewModels;

namespace DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

internal interface IDataStructureSetupViewModelRepository : IImportExecutionDataRepository<IDataStructureSetupViewModel>
{
    void Initialize();
}