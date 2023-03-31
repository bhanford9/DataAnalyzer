using System.Windows.Input;
using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels
{
    internal class ActionSummaryExpandableViewModel : BasePropertyChanged, IActionSummaryExpandableViewModel
    {
        private string pathId = string.Empty;
        private string actionName = string.Empty;
        private string actionDescription = string.Empty;
        private string descriptionPreview = string.Empty;
        private string detailedDescription = string.Empty;

        private bool removePopupVisible = false;

        private readonly BaseCommand removeOccurrence;
        private readonly BaseCommand removeAllOccurrences;
        private readonly BaseCommand cancelRemove;
        private readonly BaseCommand previewRemove;

        public ActionSummaryExpandableViewModel()
        {
            this.removeOccurrence = new BaseCommand(_ => this.DoRemoveOccurrence());
            this.removeAllOccurrences = new BaseCommand(_ => this.DoRemoveAllOccurrence());
            this.cancelRemove = new BaseCommand(_ => this.DoCancelRemove());
            this.previewRemove = new BaseCommand(_ => this.DoPreviewRemove());
        }

        public ICommand RemoveOccurrence => this.removeOccurrence;

        public ICommand RemoveAllOccurrences => this.removeAllOccurrences;

        public ICommand CancelRemove => this.cancelRemove;

        public ICommand PreviewRemove => this.previewRemove;

        public string PathId
        {
            get => this.pathId;
            set => this.NotifyPropertyChanged(ref this.pathId, value);
        }

        public string ActionName
        {
            get => this.actionName;
            set => this.NotifyPropertyChanged(ref this.actionName, value);
        }

        public string ActionDescription
        {
            get => this.actionDescription;
            set => this.NotifyPropertyChanged(ref this.actionDescription, value);
        }

        public string DescriptionPreview
        {
            get => this.descriptionPreview;
            set => this.NotifyPropertyChanged(ref this.descriptionPreview, value);
        }

        public string DetailedDescription
        {
            get => this.detailedDescription;
            set => this.NotifyPropertyChanged(ref this.detailedDescription, value);
        }

        public bool RemovePopupVisible
        {
            get => this.removePopupVisible;
            set => this.NotifyPropertyChanged(ref this.removePopupVisible, value);
        }

        private void DoRemoveOccurrence()
        {

        }

        private void DoRemoveAllOccurrence()
        {

        }

        private void DoCancelRemove()
        {

        }

        private void DoPreviewRemove()
        {

        }
    }
}
