﻿namespace DataAnalyzer.Services
{
    internal interface ISerializationService
    {
        T JsonDeserialize<T>(string json);
        T JsonDeserializeFromFile<T>(string filePath);
        string JsonSerialize<T>(T data);
        void JsonSerializeToFile<T>(T data, string filePath);
    }
}