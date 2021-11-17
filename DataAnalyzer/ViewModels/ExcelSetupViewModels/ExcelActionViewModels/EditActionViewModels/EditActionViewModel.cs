﻿using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  public abstract class EditActionViewModel : BasePropertyChanged, IEditActionViewModel
  {
    protected IActionCreationModel actionCreationModel;

    private string actionName = string.Empty;
    private string description = string.Empty;
    private IActionParameters actionParameters;

    private readonly BaseCommand saveAs;

    public EditActionViewModel(
      IActionCreationModel actionCreationModel)
    {
      this.actionCreationModel = actionCreationModel;

      this.saveAs = new BaseCommand((obj) => this.DoSaveAs());
    }

    public EditActionViewModel(
      IActionCreationModel actionCreationModel,
      IEditActionViewModel toCopy)
      : this(actionCreationModel)
    {
      this.ActionName = toCopy.ActionName;
      this.Description = toCopy.Description;

      this.InternalInit(toCopy);

      // TODO --> Setup events
      //   This will make sure the original does not have events, but children do
    }

    protected EditActionViewModel() { }

    public ICommand SaveAs => this.saveAs;

    public string ActionName
    {
      get => this.actionName;
      set => this.NotifyPropertyChanged(nameof(this.ActionName), ref this.actionName, value);
    }

    public string Description
    {
      get => this.description;
      set => this.NotifyPropertyChanged(nameof(this.Description), ref this.description, value);
    }

    public IActionParameters ActionParameters
    {
      get => this.actionParameters;
      set => this.NotifyPropertyChanged(nameof(this.ActionParameters), ref this.actionParameters, value);
    }

    public abstract bool IsApplicable(IActionParameters parameters);

    public abstract IEditActionViewModel GetNewInstance(IActionParameters parameters);

    protected abstract void InternalInit(IEditActionViewModel toCopy);

    private void DoSaveAs()
    {

    }
  }
}
