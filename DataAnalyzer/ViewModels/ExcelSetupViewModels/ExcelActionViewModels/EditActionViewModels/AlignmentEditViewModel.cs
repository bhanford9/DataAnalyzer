using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services;
using System;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  public class AlignmentEditViewModel : EditActionViewModel
  {
    private string selectedHorizontalAlignment = string.Empty;
    private string selectedVerticalAlignment = string.Empty;
    private int nth = 0;
    private EnumUtilities EnumUtilities = new EnumUtilities();

    public AlignmentEditViewModel()
    {
    }

    public AlignmentEditViewModel(IActionCreationModel actionCreationModel, IEditActionViewModel toCopy)
      : base(actionCreationModel, toCopy)
    {
    }

    public ObservableCollection<string> HorizontalAlignments { get; }
      = new ObservableCollection<string>();

    public ObservableCollection<string> VerticalAlignments { get; }
      = new ObservableCollection<string>();

    public string SelectedHorizontalAlignment
    {
      get => this.selectedHorizontalAlignment;
      set => this.NotifyPropertyChanged(nameof(this.SelectedHorizontalAlignment), ref this.selectedHorizontalAlignment, value);
    }

    public string SelectedVerticalAlignment
    {
      get => this.selectedVerticalAlignment;
      set => this.NotifyPropertyChanged(nameof(this.SelectedVerticalAlignment), ref this.selectedVerticalAlignment, value);
    }

    public int Nth
    {
      get => this.nth;
      set => this.NotifyPropertyChanged(nameof(this.Nth), ref this.nth, value);
    }

    public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
    {
      AlignmentEditViewModel viewModel = new AlignmentEditViewModel(this.actionCreationModel, this);
      AlignmentParameters alignmentParameters = parameters as AlignmentParameters;
      viewModel.SelectedHorizontalAlignment = alignmentParameters.HorizontalAlignment.ToString();
      viewModel.SelectedVerticalAlignment = alignmentParameters.VerticalAlignment.ToString();
      viewModel.Nth = alignmentParameters.Nth;
      return viewModel;
    }

    public override bool IsApplicable(IActionParameters parameters)
    {
      return parameters is AlignmentParameters;
    }

    protected override void DoAct()
    {
      throw new NotImplementedException();
    }

    protected override void InternalInit(IEditActionViewModel toCopy)
    {
      this.EnumUtilities.LoadNames(typeof(HorizontalAlignment), this.HorizontalAlignments);
      this.EnumUtilities.LoadNames(typeof(VerticalAlignment), this.VerticalAlignments);
    }
  }
}
