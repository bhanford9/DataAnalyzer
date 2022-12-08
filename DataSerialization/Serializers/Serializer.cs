namespace DataSerialization.Serializers
{
    internal abstract class Serializer<T>
    {
        public abstract T Deserialize(string content);

        public abstract string Serialize(T data);
    }
}
