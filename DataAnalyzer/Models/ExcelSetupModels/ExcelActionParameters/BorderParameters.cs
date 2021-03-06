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

    private int nth = -1;

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
      set => this.NotifyPropertyChanged(nameof(this.DiagonalUpColor), ref this.diagonalUpColor, value);
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

    public int Nth
    {
      get => this.nth;
      set => this.NotifyPropertyChanged(nameof(this.Nth), ref this.nth, value);
    }

    public override ActionCategory ActionCategory => ActionCategory.BorderStyle;

    public override string ToString()
    {
      string str =
        $"Left Color: {this.LeftColor.Name}{Environment.NewLine}" +
        $"Left Style: {this.LeftStyle}{Environment.NewLine}" +
        $"Top Color: {this.TopColor.Name}{Environment.NewLine}" +
        $"Top Style: {this.TopStyle}{Environment.NewLine}" +
        $"Right Color: {this.RightColor.Name}{Environment.NewLine}" +
        $"Right Style: {this.RightStyle}{Environment.NewLine}" +
        $"Bottom Color: {this.BottomColor.Name}{Environment.NewLine}" +
        $"Bottom Style: {this.BottomStyle}{Environment.NewLine}" +
        $"All Color: {this.AllColor.Name}{Environment.NewLine}" +
        $"All Style: {this.AllStyle}{Environment.NewLine}" +
        $"Diagonal Up Color: {this.DiagonalUpColor.Name}{Environment.NewLine}" +
        $"Diagonal Up Style: {this.DiagonalUpStyle}{Environment.NewLine}" +
        $"Diagonal Down Color: {this.DiagonalDownColor.Name}{Environment.NewLine}" +
        $"Diagonal Down Style: {this.DiagonalDownStyle}{Environment.NewLine}";

      return str + (this.Nth >= 0 ? $"Nth: {this.Nth}{Environment.NewLine}" : "");
    }
  }
}