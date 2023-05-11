using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.DataImport.DataObjects.TimeStats;

internal abstract class TimeStats : Stats, ITimeStats
{
    private readonly List<string> parameterNames = new();

    public TimeStats()
    {
        parameterNames.Add(nameof(Iterations));
        parameterNames.Add(nameof(ContainerSize));
        parameterNames.Add(nameof(TotalTimeMillis));
        parameterNames.Add(nameof(AverageTimeMillis));
        parameterNames.Add(nameof(FastestTimeMillis));
        parameterNames.Add(nameof(SlowestTimeMillis));
        parameterNames.Add(nameof(RangeTimeMillis));
        parameterNames.Add(nameof(ExecuterName));
    }

    public int Iterations { get; set; }

    public int ContainerSize { get; set; }

    public double TotalTimeMillis { get; set; }

    public double AverageTimeMillis { get; set; }

    public double FastestTimeMillis { get; set; }

    public double SlowestTimeMillis { get; set; }

    public double RangeTimeMillis { get; set; }

    public string ExecuterName { get; set; } = string.Empty;

    public override IReadOnlyCollection<string> ParameterNames => parameterNames.Union(InternalParameterNames).ToList();

    protected abstract ICollection<string> InternalParameterNames { get; }
}
