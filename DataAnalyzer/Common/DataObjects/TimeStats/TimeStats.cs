using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataObjects.TimeStats
{
    internal abstract class TimeStats : Stats, ITimeStats
    {
        private readonly List<string> parameterNames = new();

        public TimeStats()
        {
            this.parameterNames.Add(nameof(this.Iterations));
            this.parameterNames.Add(nameof(this.ContainerSize));
            this.parameterNames.Add(nameof(this.TotalTimeMillis));
            this.parameterNames.Add(nameof(this.AverageTimeMillis));
            this.parameterNames.Add(nameof(this.FastestTimeMillis));
            this.parameterNames.Add(nameof(this.SlowestTimeMillis));
            this.parameterNames.Add(nameof(this.RangeTimeMillis));
            this.parameterNames.Add(nameof(this.ExecuterName));
        }

        public int Iterations { get; set; }

        public int ContainerSize { get; set; }

        public double TotalTimeMillis { get; set; }

        public double AverageTimeMillis { get; set; }

        public double FastestTimeMillis { get; set; }

        public double SlowestTimeMillis { get; set; }

        public double RangeTimeMillis { get; set; }

        public string ExecuterName { get; set; } = string.Empty;

        public override ICollection<string> ParameterNames => this.parameterNames.Union(this.InternalParameterNames).ToList();

        protected abstract ICollection<string> InternalParameterNames { get; }
    }
}
