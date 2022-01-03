using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
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
    private int nth = 0;
    private readonly EnumUtilities EnumUtilities = new EnumUtilities();

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

    public int Nth
    {
      get => this.nth;
      set => this.NotifyPropertyChanged(nameof(this.Nth), ref this.nth, value);
    }

    public override void ApplyParameterSettings()
    {
      BackgroundParameters backgroundParameters = this.ActionParameters as BackgroundParameters;
      backgroundParameters.BackgroundColor = Color.FromName(this.BackgroundColors.SelectedColor);
      backgroundParameters.PatternColor = Color.FromName(this.PatternColors.SelectedColor);
      backgroundParameters.FillPattern = Enum.Parse<FillPattern>(this.SelectedPattern);
      backgroundParameters.Nth = this.Nth;
    }

    public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
    {
      BackgroundEditViewModel viewModel = new BackgroundEditViewModel(this.actionCreationModel, this);
      BackgroundParameters backgroundParameters = parameters as BackgroundParameters;
      viewModel.BackgroundColors.SelectedColor = backgroundParameters.BackgroundColor.Name;
      viewModel.PatternColors.SelectedColor = backgroundParameters.PatternColor.Name;
      viewModel.SelectedPattern = backgroundParameters.FillPattern.ToString();
      viewModel.Nth = backgroundParameters.Nth;
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
      this.EnumUtilities.LoadNames(typeof(FillPattern), this.Patterns);
    }
  }
}
