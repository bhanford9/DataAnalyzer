using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal abstract class DataPropertySetter<TData, TProperty> : IDataPropertySetter
        where TData : IData
    {
        private Action<TData, TProperty> setProperty;

        public DataPropertySetter(Action<TData, TProperty> todo)
        {
            this.setProperty = todo;
        }

        public void Set(IData data, string value)
        {
            this.setProperty((TData)(object)data, this.ToConcrete(value));
        }

        protected abstract TProperty ToConcrete(string value);
    }
}
