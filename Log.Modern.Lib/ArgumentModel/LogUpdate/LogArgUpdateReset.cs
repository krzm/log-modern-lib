using CommandDotNet;

namespace Log.Modern.Lib;

public class LogArgUpdateReset
    : LogArgUpdateToNow
{
    private bool? resetStart;
    private bool? resetEnd;

    [Option(
        "rstart")]
    public bool? ResetStart
    {
        get => resetStart;
        set
        {
            resetStart = value;
            if (resetStart.HasValue && resetStart.Value)
                Start = default;
        }
    }

    [Option(
        "rend")]
    public bool? ResetEnd
    { 
        get => resetEnd; 
        set 
        {
            resetEnd = value;
            if(resetEnd.HasValue && resetEnd.Value)
                End = default;
        } 
    }
}