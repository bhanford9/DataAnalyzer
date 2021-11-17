using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class AlignmentParameters : ActionParameters
  {
    private HorizontalAlignment horizontalAlignment = HorizontalAlignment.General;
    private VerticalAlignment verticalAlignment = VerticalAlignment.Top;
    private int nth = -1;

    public HorizontalAlignment HorizontalAlignment
    {
      get => this.horizontalAlignment;
      set => this.NotifyPropertyChanged(nameof(this.HorizontalAlignment), ref this.horizontalAlignment, value);
    }

    public VerticalAlignment VerticalAlignment
    {
      get => this.verticalAlignment;
      set => this.NotifyPropertyChanged(nameof(this.VerticalAlignment), ref this.verticalAlignment, value);
    }

    public int Nth
    {
      get => this.nth;
      set => this.NotifyPropertyChanged(nameof(this.Nth), ref this.nth, value);
    }

    public override string SerializedParameters
    {
      get
      {
        if (this.nth != -1)
        {
          return this.Serialize(this.horizontalAlignment, this.VerticalAlignment);
        }
        else
        {
          return this.Serialize(this.horizontalAlignment, this.VerticalAlignment, this.nth);
        }
      }
    }

    public override ActionCategory ActionCategory => ActionCategory.AlignmentStyle;

    public override void Deserialize()
    {
      string[] parameters = this.SerializedParameters.Split(this.Delimiter);
      this.HorizontalAlignment = Enum.Parse<HorizontalAlignment>(parameters[0]);
      this.VerticalAlignment = Enum.Parse<VerticalAlignment>(parameters[1]);

      if (parameters.Length > 2)
      {
        this.nth = int.Parse(parameters[2]);
      }
    }
  }
}
