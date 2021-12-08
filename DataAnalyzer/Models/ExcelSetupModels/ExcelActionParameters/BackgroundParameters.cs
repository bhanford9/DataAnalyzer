using DataAnalyzer.Services;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using DataSerialization.Utilities;
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

    public override void FromSerializable(ISerializable serializable)
    {
      BackgroundParametersSerialization serialization = serializable as BackgroundParametersSerialization;
      this.Name = serialization.Name;
      this.BackgroundColor = serialization.BackgroundColor;
      this.PatternColor = serialization.PatternColor;
      this.FillPattern = serialization.FillPattern;
      this.Nth = serialization.Nth;
    }

    public override bool IsValidSerializable(ISerializable serializable)
    {
      return serializable is BackgroundParametersSerialization;
    }

    public override ISerializable ToSerializable()
    {
      return new BackgroundParametersSerialization()
      {
        Nth = this.Nth,
        Name = this.Name,
        BackgroundColor = this.BackgroundColor,
        PatternColor = this.PatternColor,
        FillPattern = this.FillPattern
      };
    }
  }
}
