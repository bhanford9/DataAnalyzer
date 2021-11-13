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

    public override string SerializedParameters => this.Serialize(this.backgroundColor, this.patternColor, this.fillPattern);

    public override void Deserialize()
    {
      string[] parameters = this.SerializedParameters.Split(this.Delimiter);

      this.BackgroundColor = ColorParser.Parse(parameters[0]);
      this.PatternColor = ColorParser.Parse(parameters[1]);
      this.FillPattern = Enum.Parse<FillPattern>(parameters[2]);
    }
  }
}
