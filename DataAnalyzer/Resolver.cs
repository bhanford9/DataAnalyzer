using Autofac;
using System;
using System.Windows.Markup;

namespace DataAnalyzer
{
    internal class Resolver : MarkupExtension
    {
        public static IContainer Container { get; set; }

        public static T Resolve<T>() => Container.Resolve<T>();

        public static object Resolve(Type type) => Container.Resolve(type);

        // Together, these allow XAML dependency injection setting of ViewModels ot DataContext
        public Type Type { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider) => Resolve(this.Type);
    }
}
