using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using DotNetExtension;
using ModelHelper;

namespace Log.Modern.Lib;

[AtLeastOneProperty("TaskId", "Start", "End", "Description", "PlaceId", "TimeTicks"
    , ErrorMessage = "You must supply TaskId or Start or End or Description or PlaceId or TimeTicks")]
public class LogArgUpdate : IArgumentModel, IId
{
    private const string IdError = "Id must be greater than zero";
    private bool? endNow;
    private bool? startNow;

    [Operand(
        "id")
        , Required
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int Id { get; set; }

    [Option(
        't'
        , "taskId"
        , Description = "Task Id")
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
        , "placeId"
        , Description = "Place Id")
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? PlaceId { get; set; }

    [Option(
        'i'
        , "ticks"
        , Description = "TimeTicks")]
    public int? TimeTicks { get; set; }

    [Option(
        'n'
        , "endnow")]
    public bool? EndNow
    { 
        get => endNow; 
        set 
        {
            endNow = value;
            if(endNow.HasValue && endNow.Value)
                End = DateTime.Now;
        } 
    }

    [Option(
        'a'
        , "startnow")]
    public bool? StartNow
    {
        get => startNow;
        set
        {
            startNow = value;
            if (startNow.HasValue && startNow.Value)
                Start = DateTime.Now;
        }
    }
}