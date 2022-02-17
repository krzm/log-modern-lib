using CommandDotNet;
using System.ComponentModel.DataAnnotations;

namespace Log.Modern.Lib;

public class TaskArgFilter : IArgumentModel
{
    private const string IdError = "Id must be greater than zero";

    [Option(
        'c'
        , nameof(CategoryId))
        , Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }

    [Option(
        'n'
        , nameof(Name))
        , MaxLength(25)]
    public string? Name { get; set; }
}