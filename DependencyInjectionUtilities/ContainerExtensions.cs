using Autofac;
using Autofac.Builder;

namespace DependencyInjectionUtilities
{
    public static class ContainerExtensions
    {
        public static IRegistrationBuilder<TClass, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType<TInterface, TClass>(
            this ContainerBuilder builder)
            where TInterface : notnull
            where TClass : notnull, TInterface
            => builder.RegisterType<TClass>().As<TInterface>();

        public static IRegistrationBuilder<TClass, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterTypeAncestors<TParent, TInterface, TClass>(
            this ContainerBuilder builder)
            where TParent : notnull
            where TInterface : notnull, TParent
            where TClass : notnull, TInterface
            => builder.RegisterType<TClass>().As<TInterface>().As<TParent>();

        public static IRegistrationBuilder<TClass, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterTypeAncestors<TGrandParent, TParent, TInterface, TClass>(
            this ContainerBuilder builder)
            where TGrandParent : notnull
            where TParent : notnull, TGrandParent
            where TInterface : notnull, TParent
            where TClass : notnull, TInterface
            => builder.RegisterType<TClass>().As<TInterface>().As<TParent>().As<TGrandParent>();

        public static IRegistrationBuilder<TClass, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterTypeInstance<TInterface, TClass>(
            this ContainerBuilder builder)
            where TInterface : notnull
            where TClass : notnull, TInterface
            => builder.RegisterType<TInterface, TClass>().SingleInstance();

        public static IRegistrationBuilder<TClass, SimpleActivatorData, SingleRegistrationStyle> RegisterInstance<TInterface, TClass>(
            this ContainerBuilder builder,
            Func<TInterface, TClass> creator)
            where TInterface : notnull
            where TClass : notnull, TInterface
            => builder.Register(creator).SingleInstance();

        public static IRegistrationBuilder<TClass, SimpleActivatorData, SingleRegistrationStyle> RegisterDefaultInstance<TInterface, TClass>(
            this ContainerBuilder builder)
            where TInterface : notnull
            where TClass : class, TInterface, new()
            => builder.Register<TInterface, TClass>(x => new TClass()).SingleInstance();
    }
}
