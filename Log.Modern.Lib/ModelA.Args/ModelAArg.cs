using System.ComponentModel.DataAnnotations;
using CommandDotNet;

namespace Log.Modern.Lib;

public abstract class  ModelAArg : IArgumentModel
{
    [Operand(nameof(Name)), Required, MaxLength(25)]
    public string? Name { get; set; }

    [Operand(nameof(Description)), Required, MaxLength(70)]
    public string? Description { get; set; }
}