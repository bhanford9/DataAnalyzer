using DataSerialization.Utilities;
using DataSerialization.Utilities.BuiltInSerializers;
using System;

namespace DataAnalyzer.Services.Serializations.ExcelSerializations
{
  public class WorkbookSerialization : DefaultSerializable
  {
    private const string ACTIONS_DELIMITER = "WKBK_ACTS";
    private const string WORKSHEETS_DELIMITER = "WKSHTS";

    private SerializationCollection workbookActions = new SerializationCollection(ACTIONS_DELIMITER);
    private SerializationCollection worksheets = new SerializationCollection(WORKSHEETS_DELIMITER);

    public string Name { get; set; } = string.Empty;

    // LETS TEST THIS IN A TEST CASE TO MAKE SURE IT ACTUALLY WORKS
    // Actions gets to be a simple collection of Serializable Actions
    public SerializationCollection WorkbookActions
    {
      get => this.workbookActions;
      set
      {
        this.workbookActions = value;
        this.workbookActions.DelimiterSalt = ACTIONS_DELIMITER;
      }
    }

    // Worksheets will be similar to this workbook where it is a name and a collection of actions
    public SerializationCollection Worksheets
    {
      get => this.worksheets;
      set
      {
        this.worksheets = value;
        this.worksheets.DelimiterSalt = WORKSHEETS_DELIMITER;
      }
    }

    public override string DelimiterKey => "Workbook";

    protected override bool IsCorrectType(Type type)
    {
      return type.IsAssignableFrom(this.GetType());
    }

    protected override void RegisterSerializations()
    {
      this.RegisterSerializableParameter(
        0,
        (obj) => (obj as WorkbookSerialization).Name,
        (obj, name) => (obj as WorkbookSerialization).Name = name,
        new StringSerializer());

      this.RegisterSerializableParameter(
        1,
        (obj) => (obj as WorkbookSerialization).WorkbookActions,
        (obj, workbookActions) => (obj as WorkbookSerialization).WorkbookActions = workbookActions,
        (str) => this.WorkbookActions.Deserialize(str),
        (obj) => this.WorkbookActions.Serialize());

      this.RegisterSerializableParameter(
        2,
        (obj) => (obj as WorkbookSerialization).Worksheets,
        (obj, Worksheets) => (obj as WorkbookSerialization).Worksheets = Worksheets,
        (str) => this.Worksheets.Deserialize(str),
        (obj) => this.Worksheets.Serialize());
    }
  }
}
