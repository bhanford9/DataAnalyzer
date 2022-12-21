using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

namespace DataAnalyzer.Models.ExcelSetupModels
{
    internal class ExcelAction : BasePropertyChanged
    {
        private string name = string.Empty;
        private string description = string.Empty;
        private bool isBuiltIn = true;
        private IActionParameters actionParameters;
        private string actionParameterType = string.Empty;

        public string Name
        {
            get => this.name;
            set => this.NotifyPropertyChanged(ref this.name, value);
        }

        public string Description
        {
            get => this.description;
            set => this.NotifyPropertyChanged(ref this.description, value);
        }

        public bool IsBuiltIn
        {
            get => this.isBuiltIn;
            set => this.NotifyPropertyChanged(ref this.isBuiltIn, value);
        }

        public IActionParameters ActionParameters
        {
            get => this.actionParameters;
            set => this.NotifyPropertyChanged(ref this.actionParameters, value);
        }

        public string ActionParameterType
        {
            get => this.actionParameterType;
            set => this.NotifyPropertyChanged(ref this.actionParameterType, value);
        }

        public ExcelAction Clone() =>
            new()
            {
                Name = this.name,
                Description = this.description,
                IsBuiltIn = this.isBuiltIn,
                ActionParameters = this.actionParameters.Clone(),
                ActionParameterType = this.actionParameterType,
            };
    }
}
