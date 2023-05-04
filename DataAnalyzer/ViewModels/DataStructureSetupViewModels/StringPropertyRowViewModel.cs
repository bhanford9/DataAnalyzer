using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.ClassGenerationServices;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class StringPropertyRowViewModel : BasePropertyChanged, IStringPropertyRowViewModel
    {
        private bool include = true;
        private string serializedName = string.Empty;
        private string propertyName = string.Empty;
        private PropertyType propertyType = PropertyType.Simple;

        public bool Include
        {
            get => this.include;
            set => this.NotifyPropertyChanged(ref this.include, value);
        }

        public string SerializedName
        {
            get => this.serializedName;
            set => this.NotifyPropertyChanged(ref this.serializedName, value);
        }

        public string PropertyName
        {
            get => this.propertyName;
            set => this.NotifyPropertyChanged(ref this.propertyName, value);
        }

        public PropertyType PropertyType
        {
            get => this.propertyType;
            set => this.NotifyPropertyChanged(ref this.propertyType, value);
        }
    }
}
