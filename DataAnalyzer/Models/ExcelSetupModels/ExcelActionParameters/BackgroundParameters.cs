using DataAnalyzer.Services;
using System;
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

    public override string SerializedParameters => this.Serialize(
      this.backgroundColor,
      this.patternColor,
      this.fillPattern,
      this.nth != -1 ? this.nth.ToString() : string.Empty);

    public override ActionCategory ActionCategory => ActionCategory.BackgroundStyle;

    public override void Deserialize()
    {
      string[] parameters = this.SerializedParameters.Split(this.Delimiter, StringSplitOptions.RemoveEmptyEntries);

      this.BackgroundColor = ColorParser.Parse(parameters[0]);
      this.PatternColor = ColorParser.Parse(parameters[1]);
      this.FillPattern = Enum.Parse<FillPattern>(parameters[2]);

      if (parameters.Length > 3)
      {
        this.nth = int.Parse(parameters[3]);
      }
    }
  }
}
