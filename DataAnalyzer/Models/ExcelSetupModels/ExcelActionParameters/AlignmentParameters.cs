﻿using DataAnalyzer.Services;

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

    public override ActionCategory ActionCategory => ActionCategory.AlignmentStyle;
  }
}