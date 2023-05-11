using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters;

internal interface IDataStringPropertySetter : IDataPropertySetter { }
internal class DataStringPropertySetter<TData> : DataPropertySetter<TData, string>, IDataStringPropertySetter
    where TData : IData
{
    public DataStringPropertySetter(Action<TData, string> todo) : base(todo) { }

    protected override string ToConcrete(string value) => value;
}
