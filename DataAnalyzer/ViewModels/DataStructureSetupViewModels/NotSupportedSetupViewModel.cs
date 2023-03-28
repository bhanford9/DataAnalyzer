using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class NotSupportedSetupViewModel : DataStructureSetupViewModel<NotSupportedDataConfiguration>
    {
        public NotSupportedSetupViewModel(NotSupportedSetupModel model) : base(model) { }

        public override bool IsValidSetup(out string reason)
        {
            reason = "Configuration not supported";
            return false;
        }
        public override void ClearConfiguration() { }
        public override void LoadViewModelFromConfiguration() { }
        public override void ApplyConfiguration() { }
        public override void SaveConfiguration() { }
        public override void Initialize() { }
        public override string GetDisplayStringName() => nameof(StructureExecutiveCommissioner.DisplayNotSupported);
    }
}
