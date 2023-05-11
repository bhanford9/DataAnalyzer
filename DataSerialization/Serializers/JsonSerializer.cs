﻿using Newtonsoft.Json;

namespace DataSerialization.Serializers;

internal class JsonSerializer<T> : Serializer<T>, IJsonSerializer<T>
{
    private readonly JsonSerializerSettings options = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto,
        Formatting = Formatting.Indented,
    };

    public override T Deserialize(string content) => JsonConvert.DeserializeObject<T>(content, this.options);

    public override string Serialize(T data) => JsonConvert.SerializeObject(data, data.GetType(), this.options);
}
