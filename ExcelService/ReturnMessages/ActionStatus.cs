namespace ExcelService.ReturnMessages;

public class ActionStatus : IActionStatus
{
    private string message = "Success";

    public bool Successful { get; set; } = true;

    public FailureLayer FailureLayer { get; set; } = FailureLayer.None;

    public string Message
    {
        get => this.message;
        set
        {
            if (value != this.message)
            {
                this.message = value + Environment.NewLine + "See InternalMessage for more details.";
            }
        }
    }

    public string InternalMessage { get; set; } = string.Empty;
}
