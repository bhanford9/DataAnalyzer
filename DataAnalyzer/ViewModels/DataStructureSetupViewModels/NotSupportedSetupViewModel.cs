using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Models;
using DataAnalyzer.Models.DataStructureSetupModels;
using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;

namespace DataAnalyzer.ViewModels.DataStructureSetupViewModels
{
    internal class NotSupportedSetupViewModel : DataStructureSetupViewModel<NotSupportedDataConfiguration>, INotSupportedSetupViewModel
    {
        public NotSupportedSetupViewModel(
            IConfigurationModel configurationModel,
            IMainModel mainModel,
            INotSupportedSetupModel model)
            : base(configurationModel, mainModel, model) { }

        public override IDataStructureSetupViewModel Default => this;

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
