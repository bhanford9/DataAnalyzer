using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal class DataIntPropertySetter<TData> : DataPropertySetter<TData, int>
        where TData : IData, new()
    {
        public DataIntPropertySetter(Action<TData, int> todo) : base(todo) { }

        protected override int ToConcrete(string value) => int.Parse(value);
    }
}
