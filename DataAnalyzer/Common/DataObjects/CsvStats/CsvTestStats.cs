using DataAnalyzer.Services.Enums;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects.CsvStats
{
    internal class CsvTestStats : Stats
    {
        public CsvTestStats()
        {
            this.ParameterNames = new[]
            {
                nameof(this.Date),
                nameof(this.Name),
                nameof(this.Age),
                nameof(this.Gender),
            };
        }

        public override IReadOnlyCollection<string> ParameterNames { get; }

        public DateTime Date { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public override T GetEnumeratedParameters<T>() => (T)(object)StatType.Queryable;
    }
}
