using System.ComponentModel;

namespace DataAnalyzerFixtures
{
    public class BaseFixture : IDisposable
    {
        public void Dispose() { }

        public Action<T> GetEventAction<T>()
            where T : INotifyPropertyChanged
            => (input) => input.PropertyChanged += null;

        public PropertyChangedEventArgs GetNamedEventArgs(string name) => new(name);

        public (Action<T> Event, PropertyChangedEventArgs Args) GetPropertyChangedArgs<T>(string name)
            where T : INotifyPropertyChanged
            => (this.GetEventAction<T>(), this.GetNamedEventArgs(name));
    }
}
