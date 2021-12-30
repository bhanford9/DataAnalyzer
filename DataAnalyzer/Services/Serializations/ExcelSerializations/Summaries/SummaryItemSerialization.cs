using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items;
using DataSerialization.CustomSerializations;
using DataSerialization.CustomSerializations.BuiltInSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Summaries
{
  public class SummaryItemSerialization : SerializationAggregate<ISummaryItem>
  {
    public SummaryItemSerialization() : base() { }

    public SummaryItemSerialization(ISummaryItem value, string parameterName)
      : base(value, parameterName)
    {
    }

    public override void ApplyToValue()
    {
      this.DiscreteValue.Level = this.GetParameter<int>(nameof(this.DiscreteValue.Level));
      this.DiscreteValue.Name = this.GetParameter<string>(nameof(this.DiscreteValue.Name));
      this.DiscreteValue.Description = this.GetParameter<string>(nameof(this.DiscreteValue.Description));
    }

    protected override ICollection<ISerializationData> InitializeSelf(ISummaryItem value)
    {
      IntegerSerialization level = new IntegerSerialization(value.Level, nameof(value.Level));
      StringSerialization name = new StringSerialization(value.Name, nameof(value.Name));
      StringSerialization description = new StringSerialization(value.Description, nameof(value.Description));

      return new List<ISerializationData>() { level, name, description };
    }
  }
}
