using System.ComponentModel.DataAnnotations;
using CommandDotNet;

namespace Log.Modern.Lib;

public class  TaskArg : IArgumentModel
{
    private const string IdError = "Id must be greater than zero";
    
    [Operand(nameof(CategoryId)), Required, Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int CategoryId { get; set; }

    [Operand(nameof(Name)), Required, MaxLength(25)]
    public string? Name { get; set; }

    [Operand(nameof(Description)), Required, MaxLength(70)]
    public string? Description { get; set; }
}