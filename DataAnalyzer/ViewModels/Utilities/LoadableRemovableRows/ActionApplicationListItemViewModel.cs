using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
    internal class ActionApplicationListItemViewModel : LoadableRemovableRowViewModel, IActionApplicationListItemViewModel
    {
        private readonly IActionApplicationModel actionApplicationModel;

        public ActionApplicationListItemViewModel(IActionApplicationModel model)
        {
            this.actionApplicationModel = model;
        }

        protected override void DoLoad() => this.actionApplicationModel.LoadAction(this.Value);

        protected override void InternalDoRemove()
        {
            // Not Applicable
        }
    }
}
