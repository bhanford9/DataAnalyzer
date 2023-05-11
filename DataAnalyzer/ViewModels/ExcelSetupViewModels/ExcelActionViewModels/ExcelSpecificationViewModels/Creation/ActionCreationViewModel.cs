using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Creation;

internal class ActionCreationViewModel : BasePropertyChanged, IActionCreationViewModel
{
    private readonly IActionCreationModel actionCreationModel;
    private readonly IEditActionLibrary editActionLibrary;

    private IEditActionViewModel currentAction;

    public ActionCreationViewModel(
        ICollection<IExcelAction> actions,
        IActionCreationModel actionCreationModel,
        IExcelEntitySpecification excelEntityType,
        IEditActionLibrary editActionLibrary)
    {
        this.actionCreationModel = actionCreationModel;
        ExcelEntityType = excelEntityType;
        this.editActionLibrary = editActionLibrary;

        EmptyParameters empty = new();
        currentAction = this.editActionLibrary.GetEditAction(new EmptyParameters { ExcelEntityType = excelEntityType }, ExcelEntityType);
        currentAction.ActionParameters = empty;

        actions.ToList().ForEach(action =>
        {
            Actions.Add(new ActionCreationListItemViewModel(actionCreationModel)
            {
                IsRemovable = !action.IsBuiltIn,
                Value = action.Name,
                ToolTipText = action.Description
            });
        });

        this.actionCreationModel.PropertyChanged += ActionCreationModelPropertyChanged;
    }

    public ObservableCollection<ILoadableRemovableRowViewModel> Actions { get; } = new();

    public IEditActionViewModel CurrentAction
    {
        get => currentAction;
        set => NotifyPropertyChanged(ref currentAction, value);
    }

    public IExcelEntitySpecification ExcelEntityType { get; }

    private void ActionCreationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(actionCreationModel.LoadedActionName):
                IExcelAction action = actionCreationModel.GetLoadedAction();
                CurrentAction = editActionLibrary.GetEditAction(action.ActionParameters, ExcelEntityType);
                CurrentAction.ActionName = action.Name;
                CurrentAction.Description = action.Description;
                CurrentAction.ActionParameters = action.ActionParameters;
                break;
        }
    }
}