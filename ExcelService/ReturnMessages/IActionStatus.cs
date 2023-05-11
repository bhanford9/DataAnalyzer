namespace ExcelService.ReturnMessages;

public interface IActionStatus
{
    FailureLayer FailureLayer { get; set; }
    string InternalMessage { get; set; }
    string Message { get; set; }
    bool Successful { get; set; }
}