using System;

namespace DataAnalyzer.Common.Mvvm
{
    // unsafe and hacky, but very useful when used carefully
    // this permits the use of the same class as a singleton in some
    // cases while using it normally in other cases, but will usually only
    // be used for shared models/services within the MVVM structure
    internal class BaseSingleton<T>
      where T : class, new()
    {
        private BaseSingleton() { }

        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance => instance.Value;
    }
}
