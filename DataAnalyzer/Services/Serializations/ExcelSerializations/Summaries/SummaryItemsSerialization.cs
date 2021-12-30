using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary.Items;
using DataSerialization.CustomSerializations;
using System.Collections.Generic;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations.Summaries
{
  public class SummaryItemsSerialization : SerializationCollection<ISummaryItem>
  {
    // probably don't really need to save summaries
    public SummaryItemsSerialization() : base() { }

    public SummaryItemsSerialization(ICollection<ISummaryItem> dataItems, string parameterName)
      : base(dataItems, parameterName)
    {
    }

    public override void RegisterTypes()
    {
      this.RegisterType(typeof(AlignmentSummaryItem), new SummaryItemSerialization());
      this.RegisterType(typeof(BackgroundSummaryItem), new SummaryItemSerialization());
      this.RegisterType(typeof(BooleanOperationSummaryItem), new SummaryItemSerialization());
      this.RegisterType(typeof(BorderSummaryItem), new SummaryItemSerialization());
    }
  }
}
