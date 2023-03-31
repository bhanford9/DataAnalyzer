using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.ClassGenerationServices;
using System.Collections.Generic;

namespace DataAnalyzer.ViewModels.Utilities
{
    class PropertyData : BasePropertyChanged, IPropertyData
    {
        private string name = string.Empty;
        private string selectedType = string.Empty;
        private string selectedAccessibility = string.Empty;

        public IReadOnlyCollection<string> Types { get; } = new[]
        {
            ClassCreationConstants.BOOL_TYPE,
            ClassCreationConstants.INT_TYPE,
            ClassCreationConstants.DOUBLE_TYPE,
            ClassCreationConstants.STRING_TYPE,
            ClassCreationConstants.DATE_TIME_TYPE,
        };

        public IReadOnlyCollection<string> Accessibilities { get; } = new[]
        {
            ClassCreationConstants.READ_ONLY,
            ClassCreationConstants.READ_INIT,
            ClassCreationConstants.READ_PRIVATE_WRITE,
            ClassCreationConstants.READ_PROTECTED_WRITE,
            ClassCreationConstants.READ_WRITE,
        };

        public string Name
        {
            get => this.name;
            set => this.NotifyPropertyChanged(ref this.name, value);
        }

        public string SelectedType
        {
            get => this.selectedType;
            set => this.NotifyPropertyChanged(ref this.selectedType, value);
        }

        public string SelectedAccessibility
        {
            get => this.selectedAccessibility;
            set => this.NotifyPropertyChanged(ref this.selectedAccessibility, value);
        }
    }
}
