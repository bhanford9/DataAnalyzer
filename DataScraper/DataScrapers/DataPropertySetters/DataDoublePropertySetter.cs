using DataScraper.Data;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal interface IDataDoublePropertySetter : IDataPropertySetter { }
    internal class DataDoublePropertySetter<TData> : DataPropertySetter<TData, double>, IDataDoublePropertySetter
        where TData : IData
    {
        public DataDoublePropertySetter(Action<TData, double> todo) : base(todo) { }

        protected override double ToConcrete(string value) => double.Parse(value);
    }
}
