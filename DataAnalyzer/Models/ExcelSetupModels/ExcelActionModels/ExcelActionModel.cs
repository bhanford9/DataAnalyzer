using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
    internal abstract class ExcelActionModel : BasePropertyChanged, IExcelActionModel
    {
        private string loadedActionName = string.Empty;

        protected readonly ExcelSetupModel excelSetupModel = BaseSingleton<ExcelSetupModel>.Instance;
        protected readonly StatsModel statsModel = BaseSingleton<StatsModel>.Instance;

        public string LoadedActionName
        {
            get => this.loadedActionName;
            set => this.NotifyPropertyChanged(ref this.loadedActionName, value);
        }

        public void LoadAction(string name)
        {
            this.LoadedActionName = name;
        }

        public ExcelAction GetLoadedAction()
        {
            return this.GetActionCollection().First(x => x.Name.Equals(this.loadedActionName)).Clone();
        }

        protected abstract ObservableCollection<ExcelAction> GetActionCollection();
    }
}
