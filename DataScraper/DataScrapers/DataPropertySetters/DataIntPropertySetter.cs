using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal interface IDataIntPropertySetter : IDataPropertySetter { }
    internal class DataIntPropertySetter<TData> : DataPropertySetter<TData, int>, IDataIntPropertySetter
        where TData : IData
    {
        public DataIntPropertySetter(Action<TData, int> todo) : base(todo) { }

        protected override int ToConcrete(string value) => int.Parse(value);
    }
}
