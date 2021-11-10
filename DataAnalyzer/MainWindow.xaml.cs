using DataAnalyzer.ViewModels;
using System.Windows;

namespace DataAnalyzer
{
  public partial class MainWindow : Window
  {
    private readonly MainViewModel viewModel = new MainViewModel();

    public MainWindow()
    {
      this.InitializeComponent();
      this.DataContext = this.viewModel;
    }
  }
}
