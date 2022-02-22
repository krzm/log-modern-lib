using CommandDotNet;

namespace Log.Modern.Lib;

public class LogArgUpdateReset
    : LogArgUpdateToNow
{
    [Option(
        "rstart")]
    public bool? ResetStart { get; set; }

    [Option(
        "rend")]
    public bool? ResetEnd { get; set; }
}