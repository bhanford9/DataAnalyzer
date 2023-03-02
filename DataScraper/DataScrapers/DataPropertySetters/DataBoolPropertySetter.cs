using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal class DataBoolPropertySetter<TData> : DataPropertySetter<TData, bool>
        where TData : IData, new()
    {
        public DataBoolPropertySetter(Action<TData, bool> todo) : base(todo) { }

        protected override bool ToConcrete(string value) => bool.Parse(value);
    }
}
