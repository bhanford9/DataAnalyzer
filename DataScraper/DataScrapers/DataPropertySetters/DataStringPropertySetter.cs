﻿using DataScraper.Data;
using System;

namespace DataScraper.DataScrapers.DataPropertySetters
{
    internal class DataStringPropertySetter<TData> : DataPropertySetter<TData, string>
        where TData : IData, new()
    {
        public DataStringPropertySetter(Action<TData, string> todo) : base(todo) { }

        protected override string ToConcrete(string value) => value;
    }
}
