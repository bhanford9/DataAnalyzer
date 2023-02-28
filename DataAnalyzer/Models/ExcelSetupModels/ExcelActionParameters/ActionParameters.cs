using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal abstract class ActionParameters : BasePropertyChanged, IActionParameters
    {
        private ExcelEntityType excelEntityType;
        private string name = string.Empty;

        public abstract ActionCategory ActionCategory { get; }

        public ExcelEntityType ExcelEntityType
        {
            get => this.excelEntityType;
            set => this.NotifyPropertyChanged(ref this.excelEntityType, value);
        }

        public string Name
        {
            get => this.name;
            set => this.NotifyPropertyChanged(ref this.name, value);
        }

        public IActionParameters WithExcelEntity(ExcelEntityType excelEntityType)
        {
            this.excelEntityType = excelEntityType;
            return this;
        }

        public abstract override string ToString();

        public abstract IActionParameters Clone();
    }
}
