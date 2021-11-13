using DataAnalyzer.Services;
using System;

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

    public override string SerializedParameters => this.Serialize(this.horizontalAlignment, this.VerticalAlignment);

    public override void Deserialize()
    {
      string[] parameters = this.SerializedParameters.Split(this.Delimiter);
      this.HorizontalAlignment = Enum.Parse<HorizontalAlignment>(parameters[0]);
      this.VerticalAlignment = Enum.Parse<VerticalAlignment>(parameters[1]);
    }
  }
}
