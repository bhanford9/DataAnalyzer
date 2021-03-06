using DataAnalyzer.ViewModels;
using System.Windows.Controls;

namespace DataAnalyzer.Views
{
  public partial class ConfigurationCreationTabView : UserControl
  {
    private readonly ConfigurationCreationViewModel viewModel = new ConfigurationCreationViewModel();

    public ConfigurationCreationTabView()
    {
      this.InitializeComponent();
      this.DataContext = this.viewModel;
    }
  }
}
