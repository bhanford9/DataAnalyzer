using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views;

public partial class ApplicationConfigurationView : UserControl
{
    public ApplicationConfigurationView() : this(Resolver.Resolve<IApplicationConfigurationViewModel>()) { }

    internal ApplicationConfigurationView(IApplicationConfigurationViewModel viewModel)
    {
        this.InitializeComponent();
        this.DataContext = viewModel;
    }
}
