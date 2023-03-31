using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
    internal abstract class ExcelActionModel : BasePropertyChanged, IExcelActionModel
    {
        private string loadedActionName = string.Empty;

        protected readonly IExcelSetupModel excelSetupModel;
        protected readonly IStatsModel statsModel;

        public ExcelActionModel(
            IStatsModel statsModel,
            IExcelSetupModel excelSetupModel)
        {
            this.statsModel = statsModel;
            this.excelSetupModel = excelSetupModel;
        }

        public string LoadedActionName
        {
            get => this.loadedActionName;
            set => this.NotifyPropertyChanged(ref this.loadedActionName, value);
        }

        public void LoadAction(string name) => this.LoadedActionName = name;

        public IExcelAction GetLoadedAction() => this.GetActionCollection().First(x => x.Name.Equals(this.loadedActionName)).Clone();

        protected abstract ObservableCollection<IExcelAction> GetActionCollection();
    }
}
