namespace DataAnalyzer.ViewModels.Utilities;

internal interface IFilePathAndNamePair
{
    string FileName { get; }
    string FilePath { get; set; }
}