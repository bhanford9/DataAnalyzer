using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views;

public partial class ImportConfigurationView : UserControl
{
    public ImportConfigurationView() : this(Resolver.Resolve<IImportConfigurationViewModel>()) { }

    internal ImportConfigurationView(IImportConfigurationViewModel viewModel)
    {
        this.InitializeComponent();
        this.DataContext = viewModel;
    }
}
