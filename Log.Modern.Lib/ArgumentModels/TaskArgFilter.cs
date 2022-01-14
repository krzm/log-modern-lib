using CommandDotNet;
using System.ComponentModel.DataAnnotations;

namespace Log.Modern.Lib;

public class TaskArgFilter : IArgumentModel
{
    [Option(
        'c'
        , "categoryId")
        , Range(1, int.MaxValue, ErrorMessage = "Id must be greater than zero")]
    public int? CategoryId { get; set; }
}