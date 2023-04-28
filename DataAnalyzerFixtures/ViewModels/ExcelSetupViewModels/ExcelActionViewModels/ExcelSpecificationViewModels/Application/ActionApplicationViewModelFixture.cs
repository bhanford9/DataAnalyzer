using DataAnalyzer.Models;
using Moq;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application;
using System.ComponentModel;

namespace DataAnalyzerFixtures.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application
{
    public class ActionApplicationViewModelFixture : BaseFixture
    {
        public ActionApplicationViewModelFixture()
        {
            // one time setup
        }

        internal Mock<IStatsModel> MockStatsModel { get; set; }

        internal Mock<IEditActionLibrary> MockEditActionLibrary { get; set; }

        internal Mock<IActionApplicationModel> MockActionApplicationModel { get; set; }

        internal Mock<IExcelEntitySpecification> MockExcelEntitySpecification { get; set; }

        internal Mock<IEmptyEditViewModel> MockEmptyEditViewModel { get; set; }

        internal string HeirarchalStatsPropName => nameof(this.MockStatsModel.Object.HeirarchalStats);

        internal PropertyChangedEventArgs HeirarchalStatsChangeArgs => this.GetNamedEventArgs(this.HeirarchalStatsPropName);

        internal string LoadedActionNamePropName => nameof(this.MockActionApplicationModel.Object.LoadedActionName);

        internal PropertyChangedEventArgs LoadedActionNameChangeArgs => this.GetNamedEventArgs(this.LoadedActionNamePropName);

        internal ActionApplicationViewModel ViewModel { get; set; }
    }
}
