using DataAnalyzer.Services;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  class AlignmentParameters : ActionParameters
  {
    private HorizontalAlignment horizontalAlignment = HorizontalAlignment.General;
    private VerticalAlignment verticalAlignment = VerticalAlignment.Top;

    public HorizontalAlignment HorizontalAlignment
    {
      get => this.horizontalAlignment;
      set => this.NotifyPropertyChanged(nameof(this.HorizontalAlignment), ref this.horizontalAlignment, value);
    }

    public VerticalAlignment VerticalAlignment
    {
      get => this.VerticalAlignment;
      set => this.NotifyPropertyChanged(nameof(this.VerticalAlignment), ref this.verticalAlignment, value);
    }
  }
}
