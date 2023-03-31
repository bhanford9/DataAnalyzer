using DataAnalyzer.Common.Mvvm;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class SelectableRemoveableRowViewModel : RowViewModel, ISelectableRemoveableRowViewModel
    {
        private readonly BaseCommand remove;
        private readonly BaseCommand select;

        public SelectableRemoveableRowViewModel()
        {
            this.remove = new BaseCommand(obj => this.DoRemove());
            this.select = new BaseCommand(obj => this.DoSelect());
        }

        public ICommand Remove => this.remove;
        public ICommand Select => this.select;

        private void DoRemove()
        {

        }

        private void DoSelect()
        {

        }
    }
}
