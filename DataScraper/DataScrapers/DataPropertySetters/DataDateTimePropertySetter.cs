using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal interface IDataDateTimePropertySetter : IDataPropertySetter { }
    internal class DataDateTimePropertySetter<TData> : DataPropertySetter<TData, DateTime>, IDataDateTimePropertySetter
        where TData : IData
    {
        public DataDateTimePropertySetter(Action<TData, DateTime> todo) : base(todo) { }

        protected override DateTime ToConcrete(string value) => DateTime.Parse(value);
    }
}
