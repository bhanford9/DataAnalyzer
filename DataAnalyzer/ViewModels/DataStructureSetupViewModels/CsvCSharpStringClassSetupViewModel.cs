using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.Services;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class CsvCSharpStringClassSetupViewModel : DataStructureSetupViewModel<CsvNamesDataConfiguration>
    {
        private string className = string.Empty;

        // optionally may want to move this into the parent as the interface
        private readonly CsvCSharpStringClassSetupModel model;

        public CsvCSharpStringClassSetupViewModel(
            ObservableCollection<string> dataTypes,
            CsvCSharpStringClassSetupModel model)
            : base(dataTypes, model)
        {
            this.model = model;
            this.model.PropertyChanged += this.ModelPropertyChanged;
        }

        public ObservableCollection<StringPropertyRowViewModel> CsvPropertyRows { get; set; } = new();

        public string ClassName
        {
            get => this.className;
            set => this.NotifyPropertyChanged(ref this.className, value);
        }

        public override bool CanSave(out string reason)
        {
            reason = string.Empty;

            if (string.IsNullOrEmpty(this.ClassName))
            {
                reason = "Class Name cannot be left empty";
                return false;
            }

            return true;
        }

        public override void ClearConfiguration()
        {
            this.SelectedDataType = StatType.NotApplicable.ToString();
        }

        public override void LoadViewModelFromConfiguration()
        {
            // TODO
            throw new System.NotImplementedException();
        }

        public override void SaveConfiguration()
        {
            // TODO
            throw new System.NotImplementedException();
        }

        private void ModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
