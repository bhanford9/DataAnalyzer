using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal abstract class ActionParameters : BasePropertyChanged, IActionParameters
    {
        private string name = string.Empty;

        public abstract ActionCategory ActionCategory { get; }

        public string Name
        {
            get => this.name;
            set => this.NotifyPropertyChanged(ref this.name, value);
        }

        public abstract override string ToString();
    }
}
