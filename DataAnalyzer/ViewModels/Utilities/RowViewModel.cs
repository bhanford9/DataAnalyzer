using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class RowViewModel : BasePropertyChanged, IRowViewModel
    {
        private string value = string.Empty;

        public string Value
        {
            get => this.value;
            set => this.NotifyPropertyChanged(ref this.value, value);
        }
    }
}
