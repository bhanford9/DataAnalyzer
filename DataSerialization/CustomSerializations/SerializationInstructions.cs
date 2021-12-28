using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSerialization.CustomSerializations
{
  public class SerializationInstructions : ISerializationInstructions
  {
    private const string CLASS_KEY = "HELPER_ID";
    private const string VALUE_KEY = "VALUE_ID";
    private const int START_BRACE_LINE_INDEX = 0;
    private const int HELPER_ID_LINE_INDEX = 1;
    private const int VALUE_ID_LINE_INDEX = 2;
    private const int VALUE_LINE_INDEX = 3;
    private const int VALUE_BLOCK_LINE_COUNT = 5;

    private string COMMA_END => $"\",{Environment.NewLine}";

    public string Serialize(ISerializationData data, int level = 0)
    {
      string baseTabs = this.GetTabs(level);
      string childTabs = this.GetTabs(level + 1);

      string serialization = baseTabs + "{" + Environment.NewLine +
          childTabs + CLASS_KEY + ": \"" + data.SelfAssemblyName + this.COMMA_END +
          childTabs + VALUE_KEY + ": \"" + data.ValueType.AssemblyQualifiedName + this.COMMA_END;

      if (data is ISerializationAggregate aggregateData)
      {
        serialization += childTabs + aggregateData.ParameterName + ": {" + Environment.NewLine;

        foreach (ISerializationData item in aggregateData.Items)
        {
          serialization += this.Serialize(item, level + 2) + this.COMMA_END[1..];
        }

        serialization = serialization.TrimEnd()[..^1] + this.GetTabbedCurlyEnd(childTabs);
        serialization += this.GetTabbedCurlyEnd(baseTabs);
      }
      else if (data is ISerializationCollection collectionData)
      {
        serialization += childTabs + collectionData.ParameterName + ": [" + Environment.NewLine;

        foreach (ISerializationData item in collectionData.Items)
        {
          serialization += this.Serialize(item, level + 2) + this.COMMA_END[1..];
        }

        serialization = serialization.TrimEnd()[..^1] + this.GetTabbedSquareEnd(childTabs);
        serialization += this.GetTabbedCurlyEnd(baseTabs);
      }
      else
      {
        serialization += childTabs + this.GetKeyValueString(data);
        serialization += this.GetTabbedCurlyEnd(baseTabs);
      }

      return serialization;
    }

    public ISerializationData Deserialize(string serialized)
    {
      string[] serializationSplit = this.SplitNewLines(serialized);
      string serializationClassName = this.ParseValue(serializationSplit[HELPER_ID_LINE_INDEX]);

      ISerializationData serialization = Activator.CreateInstance(Type.GetType(serializationClassName)) as ISerializationData;

      KeyValuePair<string, string> nameAndValue = this.ParseKeyValue(serializationSplit[VALUE_LINE_INDEX]);
      if (serialization.ValueType == typeof(string))
      {
        serialization.Initialize(nameAndValue.Key, "");
      }
      else
      {
        serialization.Initialize(nameAndValue.Key, Activator.CreateInstance(serialization.ValueType));
      }

      if (serialization is ISerializationAggregate aggregateData)
      {
        this.HandleAggregate(aggregateData, serializationSplit);
      }
      else if (serialization is ISerializationCollection collectionData)
      {
        int innerCollectionLineCount = this.LinesUntilCollectionClose(serializationSplit[VALUE_LINE_INDEX..]);
        int innerCollectionEndLineIndex = VALUE_LINE_INDEX + innerCollectionLineCount;
        string innerData = this.JoinOnNewLines(serializationSplit[(VALUE_LINE_INDEX + 1)..innerCollectionEndLineIndex]);

        string[] innerDataSplit = this.SplitNewLines(innerData);
        do
        {
          int aggregateLineCount = this.LinesUntilAggregateClose(innerDataSplit[1..]);

          ISerializationData innerDeserialized = this.Deserialize(this.JoinOnNewLines(innerDataSplit[0..aggregateLineCount]));
          collectionData.Items.Add(innerDeserialized);
          innerDataSplit = innerDataSplit[(aggregateLineCount + 1)..];
        } while (innerDataSplit.Length > 1);

        collectionData.ApplyToValue();
      }
      else
      {
        serialization.SetValueFromString(nameAndValue.Value);
      }

      return serialization;
    }

    private void HandleAggregate(ISerializationAggregate aggregateData, string[] serializationSplit)
    {
      int aggregateLineCount = this.LinesUntilAggregateClose(serializationSplit[VALUE_LINE_INDEX..]);
      int aggregateEndLineIndex = VALUE_LINE_INDEX + aggregateLineCount;
      string serializedAggregateData = this.JoinOnNewLines(serializationSplit[VALUE_LINE_INDEX..aggregateEndLineIndex]).TrimStart();
      int trimEnd = serializedAggregateData.EndsWith(',') ? 2 : 1;
      string trimmedData = serializedAggregateData[(aggregateData.ParameterName.Length + 3)..^trimEnd].Trim();

      string[] aggregateDataLines = this.SplitNewLines(trimmedData);
      if (aggregateDataLines.Length >= VALUE_BLOCK_LINE_COUNT)
      {
        if (aggregateDataLines[VALUE_LINE_INDEX].TrimEnd().EndsWith("{"))
        {
          int startIndex = 0;
          while (true)
          {
            int innerAggregateLineCount = this.LinesUntilAggregateClose(aggregateDataLines[(startIndex + VALUE_LINE_INDEX)..]);
            int innerAggregateEndLineIndex = startIndex + VALUE_LINE_INDEX + innerAggregateLineCount;
            string innerData = this.JoinOnNewLines(aggregateDataLines[startIndex..innerAggregateEndLineIndex]);
            startIndex = innerAggregateEndLineIndex;

            ISerializationData innerDeserialzied = this.Deserialize(innerData);
            aggregateData.SetParameter(innerDeserialzied);

            if (!innerData.EndsWith(','))
            {
              break;
            }
          }
        }
        else if (aggregateDataLines[VALUE_LINE_INDEX].TrimEnd().EndsWith("["))
        {
          throw new Exception("not sure what to do here yet or if its even possible to hit");
        }
        else
        {
          this.HandleSimpleAggregate(aggregateData, aggregateDataLines);
        }
      }
      else
      {
        this.HandleSimpleAggregate(aggregateData, aggregateDataLines);
      }

      aggregateData.ApplyToValue();
    }

    private void HandleSimpleAggregate(ISerializationAggregate aggregateData, string[] aggregateDataLines)
    {
      int index = 0;

      while (true)
      {
        int skipFront = index++ * VALUE_BLOCK_LINE_COUNT;
        int endIndex = skipFront + VALUE_BLOCK_LINE_COUNT;

        if (endIndex > aggregateDataLines.Length)
        {
          break;
        }

        string[] localSplitData = aggregateDataLines[skipFront..endIndex];
        ISerializationData localDeserialzied = this.Deserialize(this.JoinOnNewLines(localSplitData));
        aggregateData.SetParameter(localDeserialzied);
      }
    }

    private int LinesUntilAggregateClose(string data)
    {
      return this.LinesUntilAggregateClose(this.SplitNewLines(data));
    }

    private int LinesUntilCollectionClose(string data)
    {
      return this.LinesUntilCollectionClose(this.SplitNewLines(data));
    }

    private int LinesUntilAggregateClose(ICollection<string> lines)
    {
      int opens = 1;
      int count = 0;

      foreach (string line in lines.Select(line => line.Trim()))
      {
        if (line.StartsWith('{') || line.EndsWith('{'))
        {
          opens++;
        }
        else if (line.StartsWith('}'))
        {
          opens--;
        }

        count++;

        if (opens == 0)
        {
          break;
        }
      }

      return count;
    }

    private int LinesUntilCollectionClose(ICollection<string> lines)
    {
      int count = 0;
      while (!lines.ElementAt(count++).TrimStart().StartsWith(']')) ;
      return count;
    }

    private string JoinOnNewLines(string[] strs)
    {
      return string.Join($"{Environment.NewLine}", strs);
    }

    private string[] SplitNewLines(string str)
    {
      return str.Split($"{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
    }

    private string GetKeyValueString(ISerializationData data, bool withComma = false)
    {
      return this.GetKeyValueString(data.ParameterName, data.ToString(), withComma);
    }

    private string GetKeyValueString(string key, string value, bool withComma = false)
    {
      string comma = withComma ? "," : "";
      return $"{key}: \"{value}\"{comma}";
    }

    private KeyValuePair<string, string> ParseKeyValue(string line)
    {
      int separatorIndex = line.IndexOf(':');
      string key = line[..separatorIndex].Trim();
      string value = line[(separatorIndex + 3)..].Trim();

      if (value.Length > 2)
      {
        value = value.EndsWith(',') ? value[..^2] : value[..^1];
      }

      return new KeyValuePair<string, string>(key, value);
    }

    private string ParseKey(string keyValuePair)
    {
      return this.ParseKeyValue(keyValuePair).Key;
    }

    private string ParseValue(string keyValuePair)
    {
      return this.ParseKeyValue(keyValuePair).Value;
    }

    private string GetTabs(int level)
    {
      return new string('\t', level);
    }

    private string GetTabbedCurlyEnd(string tabs)
    {
      return this.GetTabbedEnding(tabs, "}");
    }

    private string GetTabbedSquareEnd(string tabs)
    {
      return this.GetTabbedEnding(tabs, "]");
    }

    private string GetTabbedEnding(string tabs, string ending)
    {
      return Environment.NewLine + tabs + ending;
    }
  }
}
