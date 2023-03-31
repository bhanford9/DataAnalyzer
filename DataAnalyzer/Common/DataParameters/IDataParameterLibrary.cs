using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.DataParameters
{
    internal interface IDataParameterLibrary
    {
        IDataParameterCollection this[StatType statType] { get; }

        IDataParameterCollection GetParameters(StatType statType);
    }
}