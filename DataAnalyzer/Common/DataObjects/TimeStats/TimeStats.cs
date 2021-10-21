using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataObjects.TimeStats
{
  public abstract class TimeStats : Stats, ITimeStats
  {
    private readonly List<string> parameterNames = new List<string>();

    public TimeStats()
    {
      parameterNames.Add(nameof(this.Iterations));
      parameterNames.Add(nameof(this.ContainerSize));
      parameterNames.Add(nameof(this.TotalTimeMillis));
      parameterNames.Add(nameof(this.AverageTimeMillis));
      parameterNames.Add(nameof(this.FastestTimeMillis));
      parameterNames.Add(nameof(this.SlowestTimeMillis));
      parameterNames.Add(nameof(this.RangeTimeMillis));
      parameterNames.Add(nameof(this.ExecuterName));
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
