using Autofac;
using Autofac.Builder;

namespace DependencyInjectionUtilities
{
    public static class ContainerExtensions
    {
        public static IRegistrationBuilder<TClass, SimpleActivatorData, SingleRegistrationStyle> RegisterAs<TInterface, TClass>(
            this ContainerBuilder builder,
            Func<IComponentContext, TClass> creator)
            where TClass : TInterface
            => builder.Register(creator).As<TInterface>();

        public static IRegistrationBuilder<TClass, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType<TInterface, TClass>(
            this ContainerBuilder builder)
            where TClass : TInterface
            => builder.RegisterType<TClass>().As<TInterface>();

        public static IRegistrationBuilder<TClass, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterTypeAncestors<TParent, TInterface, TClass>(
            this ContainerBuilder builder)
            where TClass : TInterface
            where TInterface : TParent
            => builder.RegisterType<TClass>().As<TInterface>().As<TParent>();

        public static IRegistrationBuilder<TClass, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterTypeAncestors<TGrandParent, TParent, TInterface, TClass>(
            this ContainerBuilder builder)
            where TClass : TInterface
            where TInterface : TParent
            where TParent : TGrandParent
            => builder.RegisterType<TClass>().As<TInterface>().As<TParent>().As<TGrandParent>();

        public static IRegistrationBuilder<TClass, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterTypeInstance<TInterface, TClass>(
            this ContainerBuilder builder)
            where TClass : TInterface
            => builder.RegisterType<TInterface, TClass>().SingleInstance();

        public static IRegistrationBuilder<TClass, SimpleActivatorData, SingleRegistrationStyle> RegisterInstance<TInterface, TClass>(
            this ContainerBuilder builder,
            Func<IComponentContext, TClass> creator)
            where TClass : TInterface
            => RegisterAs<TInterface, TClass>(builder, creator).SingleInstance();

        public static IRegistrationBuilder<TClass, SimpleActivatorData, SingleRegistrationStyle> RegisterDefaultInstance<TInterface, TClass>(
            this ContainerBuilder builder)
            where TClass : class, TInterface, new()
            => RegisterAs<TInterface, TClass>(builder, x => new TClass()).SingleInstance();
    }
}
