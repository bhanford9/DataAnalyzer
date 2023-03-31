using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class StringPropertyRowViewModel : BasePropertyChanged, IStringPropertyRowViewModel
    {
        private bool include = true;
        private string csvName = string.Empty;
        private string propertyName = string.Empty;

        public bool Include
        {
            get => this.include;
            set => this.NotifyPropertyChanged(ref this.include, value);
        }

        public string CsvName
        {
            get => this.csvName;
            set => this.NotifyPropertyChanged(ref this.csvName, value);
        }

        public string PropertyName
        {
            get => this.propertyName;
            set => this.NotifyPropertyChanged(ref this.propertyName, value);
        }
    }
}
