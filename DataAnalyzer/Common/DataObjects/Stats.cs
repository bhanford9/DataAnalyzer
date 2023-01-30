using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects
{
    internal abstract class Stats : IStats
    {
        private readonly string uid = Guid.NewGuid().ToString();

        public string Uid => this.uid;

        public abstract IReadOnlyCollection<string> ParameterNames { get; }

        public abstract T GetEnumeratedParameters<T>();
    }
}
