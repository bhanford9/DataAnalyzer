using DataAnalyzer.Services;
using System;
using System.Drawing;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
  public class BorderParameters : ActionParameters
  {
    private Color leftColor = Color.Transparent;
    private Color topColor = Color.Transparent;
    private Color rightColor = Color.Transparent;
    private Color bottomColor = Color.Transparent;
    private Color allColor = Color.Transparent;
    private Color diagonalUpColor = Color.Transparent;
    private Color diagonalDownColor = Color.Transparent;

    private BorderStyle leftStyle = BorderStyle.None;
    private BorderStyle topStyle = BorderStyle.None;
    private BorderStyle rightStyle = BorderStyle.None;
    private BorderStyle bottomStyle = BorderStyle.None;
    private BorderStyle allStyle = BorderStyle.None;
    private BorderStyle diagonalUpStyle = BorderStyle.None;
    private BorderStyle diagonalDownStyle = BorderStyle.None;

    public Color LeftColor
    {
      get => this.leftColor;
      set => this.NotifyPropertyChanged(nameof(this.LeftColor), ref this.leftColor, value);
    }

    public BorderStyle LeftStyle
    {
      get => this.leftStyle;
      set => this.NotifyPropertyChanged(nameof(this.LeftStyle), ref this.leftStyle, value);
    }

    public Color TopColor
    {
      get => this.topColor;
      set => this.NotifyPropertyChanged(nameof(this.TopColor), ref this.topColor, value);
    }

    public BorderStyle TopStyle
    {
      get => this.topStyle;
      set => this.NotifyPropertyChanged(nameof(this.TopStyle), ref this.topStyle, value);
    }

    public Color RightColor
    {
      get => this.rightColor;
      set => this.NotifyPropertyChanged(nameof(this.RightColor), ref this.rightColor, value);
    }

    public BorderStyle RightStyle
    {
      get => this.rightStyle;
      set => this.NotifyPropertyChanged(nameof(this.RightStyle), ref this.rightStyle, value);
    }

    public Color BottomColor
    {
      get => this.bottomColor;
      set => this.NotifyPropertyChanged(nameof(this.BottomColor), ref this.bottomColor, value);
    }

    public BorderStyle BottomStyle
    {
      get => this.bottomStyle;
      set => this.NotifyPropertyChanged(nameof(this.BottomStyle), ref this.bottomStyle, value);
    }

    public Color AllColor
    {
      get => this.allColor;
      set => this.NotifyPropertyChanged(nameof(this.AllColor), ref this.allColor, value);
    }

    public BorderStyle AllStyle
    {
      get => this.allStyle;
      set => this.NotifyPropertyChanged(nameof(this.AllStyle), ref this.allStyle, value);
    }

    public Color DiagonalUpColor
    {
      get => this.diagonalUpColor;
      set => this.NotifyPropertyChanged(nameof(this.DiagonalUpColor), ref this.allColor, value);
    }

    public BorderStyle DiagonalUpStyle
    {
      get => this.diagonalUpStyle;
      set => this.NotifyPropertyChanged(nameof(this.DiagonalUpStyle), ref this.diagonalUpStyle, value);
    }

    public Color DiagonalDownColor
    {
      get => this.diagonalDownColor;
      set => this.NotifyPropertyChanged(nameof(this.DiagonalDownColor), ref this.diagonalDownColor, value);
    }

    public BorderStyle DiagonalDownStyle
    {
      get => this.diagonalDownStyle;
      set => this.NotifyPropertyChanged(nameof(this.DiagonalDownStyle), ref this.diagonalDownStyle, value);
    }

    public override string SerializedParameters => this.Serialize(
      this.leftColor,
      this.leftStyle,
      this.topColor,
      this.topStyle,
      this.rightColor,
      this.rightStyle,
      this.bottomColor,
      this.bottomStyle,
      this.allColor,
      this.allStyle,
      this.diagonalUpColor,
      this.diagonalUpStyle,
      this.diagonalDownColor,
      this.diagonalDownStyle);

    public override void Deserialize()
    {
      string[] parameters = this.SerializedParameters.Split(this.Delimiter);

      this.LeftColor = ColorParser.Parse(parameters[0]);
      this.LeftStyle = Enum.Parse<BorderStyle>(parameters[1]);
      this.TopColor = ColorParser.Parse(parameters[2]);
      this.TopStyle = Enum.Parse<BorderStyle>(parameters[3]);
      this.RightColor = ColorParser.Parse(parameters[4]);
      this.RightStyle = Enum.Parse<BorderStyle>(parameters[5]);
      this.BottomColor = ColorParser.Parse(parameters[6]);
      this.BottomStyle = Enum.Parse<BorderStyle>(parameters[7]);
      this.AllColor = ColorParser.Parse(parameters[8]);
      this.AllStyle = Enum.Parse<BorderStyle>(parameters[9]);
      this.DiagonalUpColor = ColorParser.Parse(parameters[10]);
      this.DiagonalUpStyle = Enum.Parse<BorderStyle>(parameters[11]);
      this.DiagonalDownColor = ColorParser.Parse(parameters[12]);
      this.DiagonalDownStyle = Enum.Parse<BorderStyle>(parameters[13]);
    }
  }
}