using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  public class BackgroundEditViewModel : EditActionViewModel
  {
    private string selectedPattern = string.Empty;

    public BackgroundEditViewModel()
    {
    }

    public BackgroundEditViewModel(IActionCreationModel actionCreationModel, IEditActionViewModel toCopy)
      : base(actionCreationModel, toCopy)
    {
    }

    public ObservableCollection<string> Patterns { get; }
      = new ObservableCollection<string>();

    public ColorsComboBoxViewModel BackgroundColors { get; }
      = new ColorsComboBoxViewModel();

    public ColorsComboBoxViewModel PatternColors { get; }
      = new ColorsComboBoxViewModel();

    public string SelectedPattern
    {
      get => this.selectedPattern;
      set => this.NotifyPropertyChanged(nameof(this.SelectedPattern), ref this.selectedPattern, value);
    }

    public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
    {
      BackgroundEditViewModel viewModel = new BackgroundEditViewModel(this.actionCreationModel, this);
      BackgroundParameters backgroundParameters = parameters as BackgroundParameters;
      viewModel.BackgroundColors.SelectedColor = backgroundParameters.BackgroundColor.Name;
      viewModel.PatternColors.SelectedColor = backgroundParameters.PatternColor.Name;
      viewModel.selectedPattern = backgroundParameters.FillPattern.ToString();
      return viewModel;
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return parameters is BackgroundParameters;
    }

    protected override void DoAct()
    {
      throw new NotImplementedException();
    }

    protected override void InternalInit(IEditActionViewModel toCopy)
    {
      foreach (string pattern in Enum.GetNames(typeof(FillPattern)))
      {
        this.Patterns.Add(pattern);
      }
    }
  }
}
