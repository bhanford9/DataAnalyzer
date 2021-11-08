﻿namespace ExcelService.DataActions.ActionParameters
{
  public abstract class ActionParameters : IActionParameters
  {
    public abstract string Name { get; }

    public string WorksheetName { get; set; } = string.Empty;

    public abstract ActionPerformer Performer { get; set; }
  }
}
