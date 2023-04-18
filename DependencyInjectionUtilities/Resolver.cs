using Autofac;

namespace DependencyInjectionUtilities
{
    public class Resolver
    {
        static Resolver() { }

        public static IContainer Container { get; set; }

        public static T Resolve<T>() => Container.Resolve<T>();

        public static object Resolve(Type type) => Container.Resolve(type);
    }
}
