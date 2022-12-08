using ClosedXML.Excel;
using ExcelService.DataActions.ActionParameters;
using ExcelService.ReturnMessages;
using System;

namespace ExcelService.DataActions
{
    public class ActionExecutive
    {
        private readonly ActionLibrary actionLibrary = new ActionLibrary();

        public bool PerformActions(IXLWorkbook workbook, IExcelEntity excelEntity, out ActionStatus result)
        {
            result = this.PerformActions(workbook, excelEntity);
            return result.Successful;
        }

        public void PerformActions(
          IXLWorkbook workbook,
          IExcelEntity excelEntity,
          Action<ActionStatus> onFailure,
          Action<ActionStatus> onSuccess = null)
        {
            if (!this.PerformActions(workbook, excelEntity, out ActionStatus result))
            {
                onFailure(result);
            }
            else
            {
                onSuccess?.Invoke(result);
            }
        }

        public ActionStatus PerformActions(IXLWorkbook workbook, IExcelEntity excelEntity)
        {
            try
            {
                foreach (IActionParameters actionParameters in excelEntity.ActionDefinitions)
                {
                    IDataAction action = this.actionLibrary.GetAction(actionParameters);

                    if (action == default)
                    {
                        return new ActionStatus()
                        {
                            Successful = false,
                            FailureLayer = FailureLayer.Exception,
                            Message = $"{excelEntity.Name}s do not have a registered action for the parameters, {actionParameters.Name}. " +
                            $"Actions and their parameters must be registered within the Action Library"
                        };
                    }

                    if (!action.CanExecute(excelEntity, actionParameters, out string canExecuteMessage))
                    {
                        return new ActionStatus()
                        {
                            Successful = false,
                            FailureLayer = FailureLayer.CanExecute,
                            Message = $"The supplied parameters within {actionParameters.Name}, cannot be used on a {excelEntity.Name} for the specified action.",
                            InternalMessage = canExecuteMessage
                        };
                    }

                    if (!action.Execute(workbook, excelEntity, actionParameters, out string executeMessage))
                    {
                        return new ActionStatus()
                        {
                            Successful = false,
                            FailureLayer = FailureLayer.Execute,
                            Message = $"A failure occurred while trying to execute the specified action with {actionParameters.Name} parameters on a {excelEntity.Name}.",
                            InternalMessage = executeMessage
                        };
                    }

                    if (!action.PostExecution(workbook, excelEntity, actionParameters, out string postExecutionMessage))
                    {
                        return new ActionStatus()
                        {
                            Successful = false,
                            FailureLayer = FailureLayer.PostExecution,
                            Message = $"{excelEntity.Name}s do not have a registered action for the parameters, {actionParameters.Name}. ",
                            InternalMessage = postExecutionMessage
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ActionStatus()
                {
                    Successful = false,
                    FailureLayer = FailureLayer.Exception,
                    Message = ex.Message,
                    InternalMessage = ex.StackTrace
                };
            }

            return new ActionStatus();
        }
    }
}
