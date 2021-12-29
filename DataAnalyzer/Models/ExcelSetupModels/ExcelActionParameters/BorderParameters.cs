using DataAnalyzer.Services;
using DataAnalyzer.Services.Serializations.ExcelSerializations.Actions;
using DataSerialization.CustomSerializations;
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

    public override void FromSerializable(ISerializationData serializable)
    {
      BorderParameters parameters = (serializable as BorderParametersSerialization).DiscreteValue;
      this.Name = parameters.Name;
      this.LeftColor = parameters.LeftColor;
      this.LeftStyle = parameters.LeftStyle;
      this.TopColor = parameters.TopColor;
      this.TopStyle = parameters.TopStyle;
      this.RightColor = parameters.RightColor;
      this.RightStyle = parameters.RightStyle;
      this.BottomColor = parameters.BottomColor;
      this.BottomStyle = parameters.BottomStyle;
      this.AllColor = parameters.AllColor;
      this.AllStyle = parameters.AllStyle;
      this.DiagonalUpColor = parameters.DiagonalUpColor;
      this.DiagonalUpStyle = parameters.DiagonalUpStyle;
      this.DiagonalDownColor = parameters.DiagonalDownColor;
      this.DiagonalDownStyle = parameters.DiagonalDownStyle;
      this.Nth = parameters.Nth;
    }

    public override bool IsValidSerializable(ISerializationData serializable)
    {
      return serializable is BorderParametersSerialization;
    }

    public override ISerializationData GetSerialization()
    {
      return new BorderParametersSerialization();
    }
  }
}