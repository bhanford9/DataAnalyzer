using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  class BorderEditViewModel : EditActionViewModel
  {
    //private string selectedLeftStyle = string.Empty;
    //private string selectedTopStyle = string.Empty;
    //private string selectedRightStyle = string.Empty;
    //private string selectedBottomStyle = string.Empty;
    //private string selectedAllStyle = string.Empty;
    //private string selectedDiagonalUpStyle = string.Empty;
    //private string selectedDiagonalDownStyle = string.Empty;
    private int nth = 0;


    public BorderEditViewModel()
    {
    }

    public BorderEditViewModel(IActionCreationModel actionCreationModel, IEditActionViewModel toCopy)
      : base(actionCreationModel, toCopy)
    {
    }

    public ObservableCollection<BorderSettingsViewModel> BorderSettings { get; }
      = new ObservableCollection<BorderSettingsViewModel>();

    public BorderSettingsViewModel LeftBorderSettings { get; }
      = new BorderSettingsViewModel();
    public BorderSettingsViewModel TopBorderSettings { get; }
      = new BorderSettingsViewModel();
    public BorderSettingsViewModel RightBorderSettings { get; }
      = new BorderSettingsViewModel();
    public BorderSettingsViewModel BottomBorderSettings { get; }
      = new BorderSettingsViewModel();
    public BorderSettingsViewModel AllBorderSettings { get; }
      = new BorderSettingsViewModel();
    public BorderSettingsViewModel DiagonalUpBorderSettings { get; }
      = new BorderSettingsViewModel();
    public BorderSettingsViewModel DiagonalDownBorderSettings { get; }
      = new BorderSettingsViewModel();

    //public ColorsComboBoxViewModel LeftColors { get; }
    //  = new ColorsComboBoxViewModel();

    //public ColorsComboBoxViewModel TopColors { get; }
    //  = new ColorsComboBoxViewModel();

    //public ColorsComboBoxViewModel RightColors { get; }
    //  = new ColorsComboBoxViewModel();

    //public ColorsComboBoxViewModel BottomColors { get; }
    //  = new ColorsComboBoxViewModel();

    //public ColorsComboBoxViewModel AllColors { get; }
    //  = new ColorsComboBoxViewModel();

    //public ColorsComboBoxViewModel DiagonalUpColors { get; }
    //  = new ColorsComboBoxViewModel();

    //public ColorsComboBoxViewModel DiagonalDownColors { get; }
    //  = new ColorsComboBoxViewModel();

    //public string SelectedLeftStyle
    //{
    //  get => this.selectedLeftStyle;
    //  set => this.NotifyPropertyChanged(nameof(this.SelectedLeftStyle), ref this.selectedLeftStyle, value);
    //}

    //public string SelectedTopStyle
    //{
    //  get => this.selectedTopStyle;
    //  set => this.NotifyPropertyChanged(nameof(this.SelectedTopStyle), ref this.selectedTopStyle, value);
    //}

    //public string SelectedRightStyle
    //{
    //  get => this.selectedRightStyle;
    //  set => this.NotifyPropertyChanged(nameof(this.SelectedRightStyle), ref this.selectedRightStyle, value);
    //}

    //public string SelectedBottomStyle
    //{
    //  get => this.selectedBottomStyle;
    //  set => this.NotifyPropertyChanged(nameof(this.SelectedBottomStyle), ref this.selectedBottomStyle, value);
    //}

    //public string SelectedAllStyle
    //{
    //  get => this.selectedAllStyle;
    //  set => this.NotifyPropertyChanged(nameof(this.SelectedAllStyle), ref this.selectedAllStyle, value);
    //}

    //public string SelectedDiagonalUpStyle
    //{
    //  get => this.selectedDiagonalUpStyle;
    //  set => this.NotifyPropertyChanged(nameof(this.SelectedDiagonalUpStyle), ref this.selectedDiagonalUpStyle, value);
    //}

    //public string SelectedDiagonalDownStyle
    //{
    //  get => this.selectedDiagonalDownStyle;
    //  set => this.NotifyPropertyChanged(nameof(this.SelectedDiagonalDownStyle), ref this.selectedDiagonalDownStyle, value);
    //}

    public int Nth
    {
      get => this.nth;
      set => this.NotifyPropertyChanged(nameof(this.Nth), ref this.nth, value);
    }

    public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
    {
      BorderEditViewModel viewModel = new BorderEditViewModel(this.actionCreationModel, this);
      BorderParameters borderParameters = parameters as BorderParameters;
      viewModel.LeftBorderSettings.ComboBoxColors.SelectedColor = borderParameters.LeftColor.Name;
      viewModel.TopBorderSettings.ComboBoxColors.SelectedColor = borderParameters.TopColor.Name;
      viewModel.RightBorderSettings.ComboBoxColors.SelectedColor = borderParameters.RightColor.Name;
      viewModel.BottomBorderSettings.ComboBoxColors.SelectedColor = borderParameters.BottomColor.Name;
      viewModel.AllBorderSettings.ComboBoxColors.SelectedColor = borderParameters.AllColor.Name;
      viewModel.DiagonalUpBorderSettings.ComboBoxColors.SelectedColor = borderParameters.DiagonalUpColor.Name;
      viewModel.DiagonalDownBorderSettings.ComboBoxColors.SelectedColor = borderParameters.DiagonalDownColor.Name;

      viewModel.LeftBorderSettings.SelectedStyle = borderParameters.LeftStyle.ToString();
      viewModel.TopBorderSettings.SelectedStyle = borderParameters.TopStyle.ToString();
      viewModel.RightBorderSettings.SelectedStyle = borderParameters.RightStyle.ToString();
      viewModel.BottomBorderSettings.SelectedStyle = borderParameters.BottomStyle.ToString();
      viewModel.AllBorderSettings.SelectedStyle = borderParameters.AllStyle.ToString();
      viewModel.DiagonalUpBorderSettings.SelectedStyle = borderParameters.DiagonalUpStyle.ToString();
      viewModel.DiagonalDownBorderSettings.SelectedStyle = borderParameters.DiagonalDownStyle.ToString();

      viewModel.LeftBorderSettings.BorderName = "Left Border";
      viewModel.TopBorderSettings.BorderName = "Top Border";
      viewModel.RightBorderSettings.BorderName = "Right Border";
      viewModel.BottomBorderSettings.BorderName = "Bottom Border";
      viewModel.AllBorderSettings.BorderName = "Perimeter Border";
      viewModel.DiagonalUpBorderSettings.BorderName = "Diagonal Up Border";
      viewModel.DiagonalDownBorderSettings.BorderName = "Diagonal Down Border";

      viewModel.Nth = borderParameters.Nth;

      viewModel.BorderSettings.Add(viewModel.LeftBorderSettings);
      viewModel.BorderSettings.Add(viewModel.TopBorderSettings);
      viewModel.BorderSettings.Add(viewModel.RightBorderSettings);
      viewModel.BorderSettings.Add(viewModel.BottomBorderSettings);
      viewModel.BorderSettings.Add(viewModel.AllBorderSettings);
      viewModel.BorderSettings.Add(viewModel.DiagonalUpBorderSettings);
      viewModel.BorderSettings.Add(viewModel.DiagonalDownBorderSettings);

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
    }
  }
}
