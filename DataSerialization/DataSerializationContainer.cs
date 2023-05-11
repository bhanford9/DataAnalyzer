using Autofac;
using DataSerialization.Serializers;
using DependencyInjectionUtilities;

namespace DataSerialization;

public class DataSerializationContainer
{
    public static void Register(ContainerBuilder builder)
    {
        // DataSerialization.Serializers
        builder.RegisterGeneric(typeof(JsonSerializer<>)).As(typeof(IJsonSerializer<>));

        // DataSerialization
        builder.RegisterType<ISerializationExecutive, SerializationExecutive>();
    }
}
