using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters;

internal interface IDataBoolPropertySetter : IDataPropertySetter { }
internal class DataBoolPropertySetter<TData> : DataPropertySetter<TData, bool>, IDataBoolPropertySetter
    where TData : IData
{
    public DataBoolPropertySetter(Action<TData, bool> todo) : base(todo) { }

    protected override bool ToConcrete(string value) => bool.Parse(value);
}
