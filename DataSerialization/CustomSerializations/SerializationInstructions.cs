using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSerialization.CustomSerializations
{
  public class SerializationInstructions
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

        if (serialization.EndsWith(','))
        {
          serialization = serialization.TrimEnd()[..^1];
        }

        serialization += this.GetTabbedCurlyEnd(childTabs);
        serialization += this.GetTabbedCurlyEnd(baseTabs);
      }
      else if (data is ISerializationCollection collectionData)
      {
        serialization += childTabs + collectionData.ParameterName + ": [" + Environment.NewLine;

        foreach (ISerializationData item in collectionData.Items)
        {
          serialization += this.Serialize(item, level + 2) + this.COMMA_END[1..];
        }

        serialization = serialization.TrimEnd();
        serialization = serialization.EndsWith('[') ? serialization : serialization[..^1];
        serialization += this.GetTabbedSquareEnd(childTabs);
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
        this.HandleCollection(collectionData, serializationSplit);
      }
      else
      {
        serialization.SetValueFromString(nameAndValue.Value);
      }

      return serialization;
    }

    private void HandleCollection(ISerializationCollection collectionData, string[] serializationSplit)
    {
      int collectionStartOffset = VALUE_LINE_INDEX;
      int collectionLineCount = this.LinesUntilCollectionClose(serializationSplit[collectionStartOffset..]);
      int collectionEndLineIndex = VALUE_LINE_INDEX + collectionLineCount;
      string serializedCollectionData = this.JoinOnNewLines(serializationSplit[VALUE_LINE_INDEX..collectionEndLineIndex]).TrimStart();

      int collectionStartIndex = collectionData.ParameterName.Length + 3;
      int trimEnd = serializedCollectionData.EndsWith(',') ? 2 : 1;
      string trimmedData = serializedCollectionData.Length > collectionStartIndex ? serializedCollectionData[collectionStartIndex..^trimEnd].Trim() : string.Empty;

      string[] collectionDataLines = this.SplitNewLines(trimmedData);

      while (collectionDataLines.Length > 1)
      {
        int aggregateLineCount = this.LinesUntilAggregateClose(collectionDataLines);

        ISerializationData innerDeserialized = this.Deserialize(this.JoinOnNewLines(collectionDataLines[0..aggregateLineCount]));
        collectionData.Items.Add(innerDeserialized);
        collectionDataLines = collectionDataLines[aggregateLineCount..];
      }

      collectionData.ApplyToValue();
    }

    private void HandleAggregate(ISerializationAggregate aggregateData, string[] serializationSplit)
    {
      int aggregateStartOffset = VALUE_LINE_INDEX - 1;
      int aggregateLineCount = this.LinesUntilAggregateClose(serializationSplit[aggregateStartOffset..]);
      int aggregateEndLineIndex = VALUE_LINE_INDEX + aggregateLineCount;
      string serializedAggregateData = this.JoinOnNewLines(serializationSplit[VALUE_LINE_INDEX..aggregateEndLineIndex]).TrimStart();

      int aggregateStartIndex = aggregateData.ParameterName.Length + 3;
      int trimEnd = serializedAggregateData.EndsWith(',') ? 2 : 1;
      string trimmedData = serializedAggregateData.Length > aggregateStartIndex ? serializedAggregateData[aggregateStartIndex..^trimEnd].Trim() : string.Empty;

      string[] aggregateDataLines = this.SplitNewLines(trimmedData);
      if (aggregateDataLines.Length >= VALUE_BLOCK_LINE_COUNT)
      {
        while (aggregateDataLines.Length > VALUE_BLOCK_LINE_COUNT)
        {
          if (aggregateDataLines.First().Trim().StartsWith('}'))
          {
            // TODO --> Don't like this, should be fixed somewhere else
            aggregateDataLines = aggregateDataLines[1..];
          }

          if (aggregateDataLines[VALUE_LINE_INDEX].TrimEnd().EndsWith("{"))
          {
            int innerAggregateLineCount = this.LinesUntilAggregateClose(aggregateDataLines);
            string innerData = this.JoinOnNewLines(aggregateDataLines[..innerAggregateLineCount]);

            ISerializationData innerDeserialzied = this.Deserialize(innerData);
            aggregateData.SetParameter(innerDeserialzied);
            aggregateDataLines = aggregateDataLines[innerAggregateLineCount..];
          }
          else if (aggregateDataLines[VALUE_LINE_INDEX].TrimEnd().EndsWith("["))
          {
            ISerializationData innerDeserialzied = this.Deserialize(this.JoinOnNewLines(aggregateDataLines));
            if (aggregateData.Items.Any(x => x.ParameterName.Equals(innerDeserialzied.ParameterName)))
            {
              aggregateData.SetParameter(innerDeserialzied);
            }

            int innerCollectionLineCount = this.LinesUntilCollectionClose(aggregateDataLines);
            int innerCollectionEndLineIndex = VALUE_LINE_INDEX + innerCollectionLineCount;
            aggregateDataLines = aggregateDataLines[innerCollectionEndLineIndex..];
          }
          else
          {
            string[] localSplitData = aggregateDataLines[..VALUE_BLOCK_LINE_COUNT];
            ISerializationData localDeserialzied = this.Deserialize(this.JoinOnNewLines(localSplitData));
            aggregateData.SetParameter(localDeserialzied);
            aggregateDataLines = aggregateDataLines[VALUE_BLOCK_LINE_COUNT..];
          }
        }
      }
      else if (aggregateDataLines.Length > 0)
      {
        this.HandleSimpleAggregate(aggregateData, aggregateDataLines);
      }

      aggregateData.ApplyToValue();
    }

    private void HandleSimpleAggregate(ISerializationAggregate aggregateData, string[] aggregateDataLines)
    {
      int skipFront = 0;
      int endIndex = VALUE_BLOCK_LINE_COUNT;

      while (true)
      {
        if (endIndex > aggregateDataLines.Length)
        {
          break;
        }
        else if (aggregateDataLines[endIndex - 1].EndsWith(']'))
        {
          endIndex++;
        }

        string[] localSplitData = aggregateDataLines[skipFront..endIndex];
        ISerializationData localDeserialzied = this.Deserialize(this.JoinOnNewLines(localSplitData));
        aggregateData.SetParameter(localDeserialzied);

        skipFront = endIndex;
        endIndex = skipFront + VALUE_BLOCK_LINE_COUNT;
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
      return this.LinesUntilBraceClose(lines, '{', '}');
    }

    private int LinesUntilCollectionClose(ICollection<string> lines)
    {
      return this.LinesUntilBraceClose(lines, '[', ']');
    }

    private int LinesUntilBraceClose(ICollection<string> lines, char openBrace, char closeBrace)
    {
      int opens = 0;
      int count = 0;
      int indexOfFirst = -1;

      if (lines.Count == 14)
      {

      }

      foreach (string line in lines.Select(line => line.Trim()))
      {
        if (line.StartsWith(openBrace) || line.EndsWith(openBrace))
        {
          indexOfFirst = indexOfFirst < 0 ? count : indexOfFirst;
          opens++;
        }
        else if (line.StartsWith(closeBrace))
        {
          opens--;
        }

        if (count > 190)
        {

        }

        count++;

        if (indexOfFirst >= 0 && opens == 0)
        {
          break;
        }
      }

      if (indexOfFirst >= 0 && opens > 0)
      {
        throw new Exception("Invalid serialized content");
      }

      if (indexOfFirst > 1)
      {
        count -= indexOfFirst;
      }

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

      int valueStartIndex = separatorIndex + 3;
      string value = line.Length > valueStartIndex ? line[(separatorIndex + 3)..].Trim() : string.Empty;

      if (value.Length > 1)
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
