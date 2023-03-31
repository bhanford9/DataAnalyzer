using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
    public partial class ConfigurationCreationTabView : UserControl
    {
        public ConfigurationCreationTabView() : this(Resolver.Resolve<IConfigurationCreationViewModel>()) { }

        internal ConfigurationCreationTabView(IConfigurationCreationViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
