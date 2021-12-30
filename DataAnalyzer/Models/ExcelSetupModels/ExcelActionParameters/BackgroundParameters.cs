using DataAnalyzer.Services;
using System.Drawing;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class BackgroundParameters : ActionParameters
  {
    private Color backgroundColor;
    private Color patternColor;
    private FillPattern fillPattern;

    private int nth = -1;

    public Color BackgroundColor
    {
      get => this.backgroundColor;
      set => this.NotifyPropertyChanged(nameof(this.BackgroundColor), ref this.backgroundColor, value);
    }

    public Color PatternColor
    {
      get => this.patternColor;
      set => this.NotifyPropertyChanged(nameof(this.PatternColor), ref this.patternColor, value);
    }

    public FillPattern FillPattern
    {
      get => this.fillPattern;
      set => this.NotifyPropertyChanged(nameof(this.FillPattern), ref this.fillPattern, value);
    }

    public int Nth
    {
      get => this.nth;
      set => this.NotifyPropertyChanged(nameof(this.Nth), ref this.nth, value);
    }

    public override ActionCategory ActionCategory => ActionCategory.BackgroundStyle;
  }
}
