using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary;
using DataSerialization.CustomSerializations;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Summaries
{
  public class SummaryItemSerialization : SerializationAggregate<SummaryItem>
  {
    public override void ApplyToValue()
    {
      throw new NotImplementedException();
    }

    protected override ICollection<ISerializationData> InitializeSelf(SummaryItem value)
    {
      throw new NotImplementedException();
    }
  }
}
