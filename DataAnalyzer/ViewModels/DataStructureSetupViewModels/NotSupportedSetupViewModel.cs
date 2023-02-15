using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models.DataStructureSetupModels;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class NotSupportedSetupViewModel : DataStructureSetupViewModel<NotSupportedDataConfiguration>
    {
        public NotSupportedSetupViewModel(
            ObservableCollection<string> dataTypes,
            NotSupportedSetupModel model)
            : base(dataTypes, model) { }

        public override bool CanSave(out string reason)
        {
            reason = "Configuration not supported";
            return false;
        }
        public override void ClearConfiguration() { }
        public override void LoadViewModelFromConfiguration() { }
        public override void ApplyConfiguration() { }
        public override void SaveConfiguration() { }
        public override void Initialize() { }
    }
}
