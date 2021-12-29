using DataAnalyzer.Services;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using DataSerialization.CustomSerializations;
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

    public override void FromSerializable(ISerializationData serializable)
    {
      BackgroundParameters parameters = (serializable as BackgroundParametersSerialization).DiscreteValue;
      this.Name = parameters.Name;
      this.BackgroundColor = parameters.BackgroundColor;
      this.PatternColor = parameters.PatternColor;
      this.FillPattern = parameters.FillPattern;
      this.Nth = parameters.Nth;
    }

    public override bool IsValidSerializable(ISerializationData serializable)
    {
      return serializable is BackgroundParametersSerialization;
    }

    public override ISerializationData GetSerialization()
    {
      return new BackgroundParametersSerialization();
    }
  }
}
