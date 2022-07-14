using System.ComponentModel.DataAnnotations;
using CommandDotNet;

namespace Log.Modern.Lib;

public class LogFilterArgs 
    : IArgumentModel
{
    private const string IdError = "Id must be greater than zero";

    [Option(
        shortName: 's'
        , longName: "start")]
    public DateTime? Start { get; set; }

    [Option(
        shortName: 'c'
        , longName: "category")
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }

    [Option(
        shortName: 't'
        , longName: "task")
    , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? TaskId { get; set; }

    [Option(longName: "todo")]
    public bool ToDoLogs { get; set; }
}