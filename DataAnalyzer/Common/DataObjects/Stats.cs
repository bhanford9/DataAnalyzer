using System;
using System.Collections.Generic;
using System.Text;

namespace DataAnalyzer.Common.DataObjects
{
  public class Stats : IStats
  {
    private string uid = Guid.NewGuid().ToString();

    public string Uid => this.uid;
  }
}
