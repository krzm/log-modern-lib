using CommandDotNet;

namespace Log.Modern.Lib;

public class LogArgFilter : IArgumentModel
{
    [Option(
        's'
        , "start")]
    public DateTime? Start { get; set; }
}