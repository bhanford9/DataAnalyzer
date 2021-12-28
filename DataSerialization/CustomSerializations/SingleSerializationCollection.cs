namespace DataSerialization.CustomSerializations
{
  public class SingleSerializationCollection<TData, TSerialization> : SerializationCollection<TData>
    where TSerialization : ISerializationData
  {
    private TSerialization serialization;

    public SingleSerializationCollection() : base() { }

    public SingleSerializationCollection(TSerialization serialization)
      : this()
    {
      this.serialization = serialization;
    }

    public override void RegisterTypes()
    {
      this.RegisterType(typeof(TData), this.serialization);
    }
  }
}
