using System.ComponentModel.DataAnnotations;
using CommandDotNet;

namespace Log.Modern.Lib;

public class LogArgFilter 
    : IArgumentModel
{
    private const string IdError = "Id must be greater than zero";

    [Option(
        's'
        , "start")]
    public DateTime? Start { get; set; }

    [Option(
        'c'
        , nameof(CategoryId))
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }

    [Option(
        't'
        , nameof(TaskId))
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? TaskId { get; set; }
}