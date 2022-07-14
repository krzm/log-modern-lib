using CommandDotNet;
using DotNetExtension;

namespace Log.Modern.Lib;

[AtLeastOneProperty(
    nameof(EndNow)
    , nameof(StartNow)
    , ErrorMessage = UpdateError)]
public class LogUpdateToNowArgs
    : LogUpdateArgs
{
    private const string UpdateError = "You must supply EndNow or StartNow";

    private bool? endNow;
    private bool? startNow;

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