using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  class BorderEditViewModel : EditActionViewModel
  {
    private string selectedLeftStyle = string.Empty;
    private string selectedTopStyle = string.Empty;
    private string selectedRightStyle = string.Empty;
    private string selectedBottomStyle = string.Empty;
    private string selectedAllStyle = string.Empty;
    private string selectedDiagonalUpStyle = string.Empty;
    private string selectedDiagonalDownStyle = string.Empty;
    private int nth = 0;

    public BorderEditViewModel()
    {
    }

    public BorderEditViewModel(IActionCreationModel actionCreationModel, IEditActionViewModel toCopy)
      : base(actionCreationModel, toCopy)
    {
    }

    public ObservableCollection<string> BorderStyles { get; }
      = new ObservableCollection<string>();

    public ColorsComboBoxViewModel LeftColors { get; }
      = new ColorsComboBoxViewModel();

    public ColorsComboBoxViewModel TopColors { get; }
      = new ColorsComboBoxViewModel();

    public ColorsComboBoxViewModel RightColors { get; }
      = new ColorsComboBoxViewModel();

    public ColorsComboBoxViewModel BottomColors { get; }
      = new ColorsComboBoxViewModel();

    public ColorsComboBoxViewModel AllColors { get; }
      = new ColorsComboBoxViewModel();

    public ColorsComboBoxViewModel DiagonalUpColors { get; }
      = new ColorsComboBoxViewModel();

    public ColorsComboBoxViewModel DiagonalDownColors { get; }
      = new ColorsComboBoxViewModel();

    public string SelectedLeftStyle
    {
      get => this.selectedLeftStyle;
      set => this.NotifyPropertyChanged(nameof(this.SelectedLeftStyle), ref this.selectedLeftStyle, value);
    }

    public string SelectedTopStyle
    {
      get => this.selectedTopStyle;
      set => this.NotifyPropertyChanged(nameof(this.SelectedTopStyle), ref this.selectedTopStyle, value);
    }

    public string SelectedRightStyle
    {
      get => this.selectedRightStyle;
      set => this.NotifyPropertyChanged(nameof(this.SelectedRightStyle), ref this.selectedRightStyle, value);
    }

    public string SelectedBottomStyle
    {
      get => this.selectedBottomStyle;
      set => this.NotifyPropertyChanged(nameof(this.SelectedBottomStyle), ref this.selectedBottomStyle, value);
    }

    public string SelectedAllStyle
    {
      get => this.selectedAllStyle;
      set => this.NotifyPropertyChanged(nameof(this.SelectedAllStyle), ref this.selectedAllStyle, value);
    }

    public string SelectedDiagonalUpStyle
    {
      get => this.selectedDiagonalUpStyle;
      set => this.NotifyPropertyChanged(nameof(this.SelectedDiagonalUpStyle), ref this.selectedDiagonalUpStyle, value);
    }

    public string SelectedDiagonalDownStyle
    {
      get => this.selectedDiagonalDownStyle;
      set => this.NotifyPropertyChanged(nameof(this.SelectedDiagonalDownStyle), ref this.selectedDiagonalDownStyle, value);
    }

    public int Nth
    {
      get => this.nth;
      set => this.NotifyPropertyChanged(nameof(this.Nth), ref this.nth, value);
    }

    public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
    {
      BorderEditViewModel viewModel = new BorderEditViewModel(this.actionCreationModel, this);
      BorderParameters borderParameters = parameters as BorderParameters;
      viewModel.LeftColors.SelectedColor = borderParameters.LeftColor.Name;
      viewModel.TopColors.SelectedColor = borderParameters.TopColor.Name;
      viewModel.RightColors.SelectedColor = borderParameters.RightColor.Name;
      viewModel.BottomColors.SelectedColor = borderParameters.BottomColor.Name;
      viewModel.AllColors.SelectedColor = borderParameters.AllColor.Name;
      viewModel.DiagonalUpColors.SelectedColor = borderParameters.DiagonalUpColor.Name;
      viewModel.DiagonalDownColors.SelectedColor = borderParameters.DiagonalDownColor.Name;

      viewModel.SelectedLeftStyle = borderParameters.LeftStyle.ToString();
      viewModel.SelectedTopStyle = borderParameters.TopStyle.ToString();
      viewModel.SelectedRightStyle = borderParameters.RightStyle.ToString();
      viewModel.SelectedBottomStyle = borderParameters.BottomStyle.ToString();
      viewModel.SelectedAllStyle = borderParameters.AllStyle.ToString();
      viewModel.SelectedDiagonalUpStyle = borderParameters.DiagonalUpStyle.ToString();
      viewModel.SelectedDiagonalDownStyle = borderParameters.DiagonalDownStyle.ToString();

      viewModel.Nth = borderParameters.Nth;

      return viewModel;
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return parameters is BorderParameters;
    }

    protected override void DoAct()
    {
      throw new NotImplementedException();
    }

    protected override void InternalInit(IEditActionViewModel toCopy)
    {
      foreach (string name in Enum.GetNames(typeof(BorderStyle)))
      {
        this.BorderStyles.Add(name);
      }
    }
  }
}
