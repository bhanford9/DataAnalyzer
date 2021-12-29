using DataAnalyzer.Common.Mvvm;
using DataSerialization.CustomSerializations;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations
{
  public class WorkbookModel : SerializablePropertyChanged
  {
    public override void FromSerializable(ISerializationData serializable)
    {
      throw new NotImplementedException();
    }

    public override bool IsValidSerializable(ISerializationData serializable)
    {
      throw new NotImplementedException();
    }

    public override ISerializationData GetSerialization()
    {
      throw new NotImplementedException();
    }
  }
}
