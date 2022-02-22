using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using DotNetExtension;
using ModelHelper;

namespace Log.Modern.Lib;

[AtLeastOneProperty(
    "TaskId", "Start", "End", "Description", "PlaceId", "TimeTicks"
    , "ResetStart", "ResetEnd"
    , ErrorMessage = "You must supply TaskId or Start or End or Description or PlaceId or TimeTicks")]
public class LogArgUpdate 
    : IArgumentModel
        , IId
{
    private const string IdError = "Id must be greater than zero";

    [Operand(
        "id")
        , Required
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int Id { get; set; }

    [Option(
        't'
        , "taskId")
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? TaskId { get; set; }

    [Option(
        's'
        , "start")]
    public DateTime? Start { get; set; }

    [Option(
        'e'
        , "end")]
    public DateTime? End { get; set; }

    [Option(
        'd'
        , "description")]
    public string? Description { get; set; }

    [Option(
        'p'
        , "placeId")
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? PlaceId { get; set; }

    [Option(
        'i'
        , "ticks")]
    public int? TimeTicks { get; set; }
}