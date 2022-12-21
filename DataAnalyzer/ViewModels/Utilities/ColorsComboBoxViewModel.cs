using DataAnalyzer.Common.Mvvm;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class ColorsComboBoxViewModel : BasePropertyChanged
    {
        private string selectedColor;

        public ColorsComboBoxViewModel()
        {
            // ordering is an attempt to get like-colors next to each other in the combo box.
            // its not perfect, but its better for people who are trying to pick a specific shade without knowing its name
            typeof(Color)
              .GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
              .OrderBy(info => Color.FromName(info.Name).GetHue())
              .ThenBy(info => Color.FromName(info.Name).R * 3 + Color.FromName(info.Name).G * 2 + Color.FromName(info.Name).B)
              .ToList()
              .ForEach(info => this.Colors.Add(info.Name));
        }

        public ObservableCollection<string> Colors { get; } = new();

        public string SelectedColor
        {
            get => this.selectedColor;
            set => this.NotifyPropertyChanged(ref this.selectedColor, value);
        }
    }
}
