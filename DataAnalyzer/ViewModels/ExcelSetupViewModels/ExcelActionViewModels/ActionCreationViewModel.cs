using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels
{
    internal class ActionCreationViewModel : BasePropertyChanged, IActionCreationViewModel
    {
        private readonly IActionCreationModel actionCreationModel;
        private readonly IEditActionLibrary editActionLibrary;

        private IEditActionViewModel currentAction;

        public ActionCreationViewModel(
            ICollection<IExcelAction> actions,
            IActionCreationModel actionCreationModel,
            ExcelEntityType excelEntityType,
            IEditActionLibrary editActionLibrary)
        {
            this.actionCreationModel = actionCreationModel;
            this.ExcelEntityType = excelEntityType;
            this.editActionLibrary = editActionLibrary;

            EmptyParameters empty = new();
            this.currentAction = this.editActionLibrary.GetEditAction(new EmptyParameters { ExcelEntityType = excelEntityType }, this.ExcelEntityType);
            this.currentAction.ActionParameters = empty;

            actions.ToList().ForEach(action =>
            {
                this.Actions.Add(new ActionCreationListItemViewModel(actionCreationModel)
                {
                    IsRemovable = !action.IsBuiltIn,
                    Value = action.Name,
                    ToolTipText = action.Description
                });
            });

            this.actionCreationModel.PropertyChanged += this.ActionCreationModelPropertyChanged;
        }

        public ObservableCollection<ILoadableRemovableRowViewModel> Actions { get; } = new();

        public IEditActionViewModel CurrentAction
        {
            get => this.currentAction;
            set => this.NotifyPropertyChanged(ref this.currentAction, value);
        }

        public ExcelEntityType ExcelEntityType { get; }

        private void ActionCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.actionCreationModel.LoadedActionName):
                    IExcelAction action = this.actionCreationModel.GetLoadedAction();
                    this.CurrentAction = this.editActionLibrary.GetEditAction(action.ActionParameters, this.ExcelEntityType);
                    this.CurrentAction.ActionName = action.Name;
                    this.CurrentAction.Description = action.Description;
                    this.CurrentAction.ActionParameters = action.ActionParameters;
                    break;
            }
        }
    }
}