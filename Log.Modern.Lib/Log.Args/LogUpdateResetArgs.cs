using CommandDotNet;
using DotNetExtension;

namespace Log.Modern.Lib;

[AtLeastOneProperty(
    nameof(ResetStart)
    , nameof(ResetEnd)
    , ErrorMessage = UpdateError)]
public class LogUpdateResetArgs
    : LogUpdateToNowArgs
{
    private const string UpdateError = "You must supply ResetStart or ResetEnd";

    [Option(
        "rstart")]
    public bool? ResetStart { get; set; }

    [Option(
        "rend")]
    public bool? ResetEnd { get; set; }
}