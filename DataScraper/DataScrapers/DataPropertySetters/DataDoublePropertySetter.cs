using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal class DataDoublePropertySetter<TData> : DataPropertySetter<TData, double>
        where TData : IData, new()
    {
        public DataDoublePropertySetter(Action<TData, double> todo) : base(todo) { }

        protected override double ToConcrete(string value) => double.Parse(value);
    }
}
