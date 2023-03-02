using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal class DataDateTimePropertySetter<TData> : DataPropertySetter<TData, DateTime>
        where TData : IData, new()
    {
        public DataDateTimePropertySetter(Action<TData, DateTime> todo) : base(todo) { }

        protected override DateTime ToConcrete(string value) => DateTime.Parse(value);
    }
}
