using System.Windows;
using System.Windows.Controls;

namespace DataAnalyzer.Views.DataStructureSetupViews;

public partial class PropertyBoxView : UserControl
{
    public PropertyBoxView()
    {
        this.InitializeComponent();
    }

    public bool IsScrollable
    {
        get { return (bool)GetValue(IsScrollableProperty); }
        set { SetValue(IsScrollableProperty, value); }
    }

    public static readonly DependencyProperty IsScrollableProperty =
        DependencyProperty.Register(
            "IsScrollable",
            typeof(bool),
            typeof(PropertyBoxView),
            new PropertyMetadata(false));
}
