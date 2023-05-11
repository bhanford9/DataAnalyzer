using DataAnalyzer.ViewModels;
using System.Windows;

namespace DataAnalyzer;

public partial class MainWindow : Window
{
    internal MainWindow(IMainViewModel viewModel)
    {
        this.InitializeComponent();
        this.DataContext = viewModel;
    }
}
