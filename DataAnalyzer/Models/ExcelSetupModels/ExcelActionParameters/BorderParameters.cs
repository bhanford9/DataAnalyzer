using DataAnalyzer.Services.Enums;
using System;
using System.Drawing;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

internal class BorderParameters : ActionParameters, IBorderParameters
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

    // TODO --> inject these
    private IColumnSpecificationParameters columnSpecification = new ColumnSpecificationParameters();
    private IRowSpecificationParameters rowSpecification = new RowSpecificationParameters();

    public Color LeftColor
    {
        get => this.leftColor;
        set => this.NotifyPropertyChanged(ref this.leftColor, value);
    }

    public BorderStyle LeftStyle
    {
        get => this.leftStyle;
        set => this.NotifyPropertyChanged(ref this.leftStyle, value);
    }

    public Color TopColor
    {
        get => this.topColor;
        set => this.NotifyPropertyChanged(ref this.topColor, value);
    }

    public BorderStyle TopStyle
    {
        get => this.topStyle;
        set => this.NotifyPropertyChanged(ref this.topStyle, value);
    }

    public Color RightColor
    {
        get => this.rightColor;
        set => this.NotifyPropertyChanged(ref this.rightColor, value);
    }

    public BorderStyle RightStyle
    {
        get => this.rightStyle;
        set => this.NotifyPropertyChanged(ref this.rightStyle, value);
    }

    public Color BottomColor
    {
        get => this.bottomColor;
        set => this.NotifyPropertyChanged(ref this.bottomColor, value);
    }

    public BorderStyle BottomStyle
    {
        get => this.bottomStyle;
        set => this.NotifyPropertyChanged(ref this.bottomStyle, value);
    }

    public Color AllColor
    {
        get => this.allColor;
        set => this.NotifyPropertyChanged(ref this.allColor, value);
    }

    public BorderStyle AllStyle
    {
        get => this.allStyle;
        set => this.NotifyPropertyChanged(ref this.allStyle, value);
    }

    public Color DiagonalUpColor
    {
        get => this.diagonalUpColor;
        set => this.NotifyPropertyChanged(ref this.diagonalUpColor, value);
    }

    public BorderStyle DiagonalUpStyle
    {
        get => this.diagonalUpStyle;
        set => this.NotifyPropertyChanged(ref this.diagonalUpStyle, value);
    }

    public Color DiagonalDownColor
    {
        get => this.diagonalDownColor;
        set => this.NotifyPropertyChanged(ref this.diagonalDownColor, value);
    }

    public BorderStyle DiagonalDownStyle
    {
        get => this.diagonalDownStyle;
        set => this.NotifyPropertyChanged(ref this.diagonalDownStyle, value);
    }

    public IColumnSpecificationParameters ColumnSpecification
    {
        get => this.columnSpecification;
        set => this.NotifyPropertyChanged(ref this.columnSpecification, value);
    }

    public IRowSpecificationParameters RowSpecification
    {
        get => this.rowSpecification;
        set => this.NotifyPropertyChanged(ref this.rowSpecification, value);
    }

    public override ActionCategory ActionCategory => ActionCategory.BorderStyle;

    public override string ToString() =>
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
        $"Diagonal Down Style: {this.DiagonalDownStyle}{Environment.NewLine}" +
        $"{ColumnSpecification}{Environment.NewLine}" +
        $"{RowSpecification}{Environment.NewLine}";

    public override IActionParameters Clone() =>
        new BorderParameters
        {
            ExcelEntityType = this.ExcelEntityType,
            Name = this.Name,
            LeftColor = this.leftColor,
            TopColor = this.topColor,
            RightColor = this.rightColor,
            BottomColor = this.bottomColor,
            AllColor = this.allColor,
            DiagonalUpColor = this.diagonalUpColor,
            DiagonalDownColor = this.diagonalDownColor,
            LeftStyle = this.leftStyle,
            TopStyle = this.topStyle,
            RightStyle = this.rightStyle,
            BottomStyle = this.bottomStyle,
            AllStyle = this.allStyle,
            DiagonalUpStyle = this.diagonalUpStyle,
            DiagonalDownStyle = this.diagonalDownStyle,
            ColumnSpecification = this.columnSpecification.Clone(),
            RowSpecification = this.rowSpecification.Clone(),
        };
}