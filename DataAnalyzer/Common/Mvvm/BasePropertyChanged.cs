using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataAnalyzer.Common.Mvvm
{
    internal class BasePropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void NotifyPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (property == null || !property.Equals(value))
            {
                property = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void NotifyPropertyChangedThen<T>(ref T property, T value, Action then, [CallerMemberName] string propertyName = null)
        {
            if (property == null || !property.Equals(value))
            {
                property = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                then();
            }
        }
    }
}
