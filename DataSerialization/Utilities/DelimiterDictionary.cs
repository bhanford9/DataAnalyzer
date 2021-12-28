using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSerialization.Utilities
{
  public class DelimiterDictionary
  {
    private IDictionary<string, string> delimiters = new Dictionary<string, string>();

    private DelimiterDictionary() { }

    private static readonly Lazy<DelimiterDictionary> instance = new Lazy<DelimiterDictionary>(() => new DelimiterDictionary());

    public static DelimiterDictionary Instance => instance.Value;

    public void RegisterDelimiter(string fullyQualifiedClassName, string delimiter)
    {
      if (this.delimiters.Any(x => x.Value.Equals(delimiter) && x.Key != fullyQualifiedClassName))
      {
        throw new Exception($"Delimiter '{delimiter}' already exists for another class type. All Delimitiers must be unique.");
      }

      if (!this.delimiters.ContainsKey(fullyQualifiedClassName) || !this.delimiters[fullyQualifiedClassName].Equals(delimiter))
      {
        this.delimiters.Add(fullyQualifiedClassName, delimiter);
      }
    }
  }
}
